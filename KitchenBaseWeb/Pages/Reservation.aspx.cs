using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace KitchenBaseWeb.Pages
{
    public partial class Reservation : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrReservation + "where ([KlientBronirovanie].[ID_InformationOKliente] = '" + DBConnection.idKlient + "')";
            if (!IsPostBack)
            {
                gvFill(QR);
                ddlTimeFill();
            }
        }
        private void gvFill(string qr)
        {
            sdsReserv.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsReserv.SelectCommand = qr;
            sdsReserv.DataSourceMode = SqlDataSourceMode.DataReader;
            gvReservation.DataSource = sdsReserv;
            gvReservation.DataBind();
        }
        private void ddlTimeFill()
        {
            sdsTime.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsTime.SelectCommand = DBConnection.qrTime;
            sdsTime.DataSourceMode = SqlDataSourceMode.DataReader;
            ddlTime.DataSource = sdsTime;
            ddlTime.DataTextField = "VremyaBronirovaniy";
            ddlTime.DataValueField = "ID_Vremeni_Bronirovaniy";
            ddlTime.DataBind();
        }

        protected void Cleaner()
        {
            tbComment.Text = string.Empty;
            tbDate.Text = string.Empty;
            tbQuantity.Text = string.Empty;
            ddlNumber.SelectedIndex = 0;
            ddlTime.SelectedIndex = 0;
            DBConnection.idRecord = 0;
        }
        protected void btInsert_Click(object sender, EventArgs e)
        {
            string Comment;
            if(DBConnection.idUser == 0)
            {
                Response.Redirect("Authorization.aspx");
            }
            else
            {

                if(tbComment.Text == "")
                {
                    Comment = Convert.ToString(DBNull.Value);
                }
                else
                {
                    Comment = tbComment.Text.ToString();
                }
                DBProcedures procedures = new DBProcedures();
                DateTime theDate = DateTime.ParseExact(tbDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                string dateToInsert = theDate.ToString("dd.MM.yyyy");
                procedures.InformationOBronirovanieInsert(Convert.ToInt32(ddlNumber.SelectedValue), dateToInsert, false, Convert.ToInt32(tbQuantity.Text),
                    Comment, Convert.ToInt32(ddlTime.SelectedValue));
                procedures.KlientBronirovanieInsert(DBConnection.idUser);
                Cleaner();
                gvFill(QR);
            }
        }

        protected void gvReservation_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Время бронирования"):
                    e.SortExpression = "[VremyaBronirovaniy]";
                    break;
                case ("Дата бронирования"):
                    e.SortExpression = "[DateBronirovaniy]";
                    break;
                case ("Количество гостей"):
                    e.SortExpression = "[KolichestvoGostey]";
                    break;
                case ("Номер стола"):
                    e.SortExpression = "[ID_Stola]";
                    break;
                case ("Номер бронирования"):
                    e.SortExpression = "[InformationOBronirovanie].[ID_Bronirovaniya]";
                    break;
                case ("Комментарий"):
                    e.SortExpression = "[Kommentariy]";
                    break;
            }
            sortGridView(gvReservation, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
        }
        private void sortGridView(GridView gridView,
         GridViewSortEventArgs e,
         out SortDirection sortDirection,
         out string strSortField)
        {
            strSortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null &&
                gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (strSortField ==
                    gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"]
                        == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }
            }
            gridView.Attributes["CurrentSortField"] = strSortField;
            gridView.Attributes["CurrentSortDirection"] =
                (sortDirection == SortDirection.Ascending ? "ASC"
                : "DESC");
        }

        protected void gvReservation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void gvReservation_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvReservation.SelectedRow;
            ddlNumber.SelectedValue = row.Cells[5].Text.ToString();
            ddlTime.SelectedIndex = Convert.ToInt32(row.Cells[1].Text.ToString()) - 1;
            tbComment.Text = row.Cells[7].Text;
            tbDate.Text = Convert.ToDateTime(row.Cells[3].Text.ToString()).ToString("yyyy-MM-dd");
            tbQuantity.Text = row.Cells[4].Text.ToString();
            DBConnection.idRecord = Convert.ToInt32(row.Cells[6].Text);
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            string Comment;
            if (tbComment.Text == "")
            {
                Comment = Convert.ToString(DBNull.Value);
            }
            else
            {
                Comment = tbComment.Text.ToString();
            }
            DBProcedures procedures = new DBProcedures();
            DateTime theDate = DateTime.ParseExact(tbDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            string dateToInsert = theDate.ToString("dd.MM.yyyy");
            procedures.InformationOBronirovanieUpdate(DBConnection.idRecord, Convert.ToInt32(ddlNumber.SelectedValue), dateToInsert, false, Convert.ToInt32(tbQuantity.Text),
                    Comment, Convert.ToInt32(ddlTime.SelectedValue));
            Cleaner();
            gvFill(QR);
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            DBProcedures procedures = new DBProcedures();
            procedures.KlientBronirovanieDelete(DBConnection.idRecord);
            procedures.InformationOBronirovanieDelete(DBConnection.idRecord);
            Cleaner();
            gvFill(QR);
        }
    }
}