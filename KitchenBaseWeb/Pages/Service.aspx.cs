using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace KitchenBaseWeb.Pages
{
    public partial class Service : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrService + "where [ID_Personala] = '" + DBConnection.idPersonal + "'";
            if (!IsPostBack)
            {
                gvFill(QR);
                ddlNameBludaFill();
            }
        }
        //Заполнение списка
        private void ddlNameBludaFill()
        {
            sdsNameBluda.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsNameBluda.SelectCommand = DBConnection.qrNameBluda;
            sdsNameBluda.DataSourceMode = SqlDataSourceMode.DataReader;
            ddlNameBluda.DataSource = sdsNameBluda;
            ddlNameBluda.DataTextField = "Название блюда";
            ddlNameBluda.DataValueField = "ID_Menu";
            ddlNameBluda.DataBind();
        }
        //Заполнение таблицы
        private void gvFill(string qr)
        {
            sdsService.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsService.SelectCommand = qr;
            sdsService.DataSourceMode = SqlDataSourceMode.DataReader;
            gvService.DataSource = sdsService;
            gvService.DataBind();
            tbTime.Text = DateTime.Now.ToString("HH:mm tt"); //Заполнение времени
        }
        //Заполнение данных о блюде
        private void BludaDataFill()
        {
            DataTable dt = new DataTable();
            DBConnection.connection.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select[ID_Menu], [TimePrigorovleniy] as 'Время приготовления', " +
                "[CenaBluda] as 'Цена блюда' from [Menu] where [ID_Menu] = '" + DBConnection.idBludaSelected + "'", DBConnection.connection);

            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                tbTimeCoocking.Text = (myReader["Время приготовления"].ToString());
                tbPrice.Text = (myReader["Цена блюда"].ToString());
            }
            DBConnection.connection.Close();
        }
        //Сортировка записей в таблице
        protected void gvService_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("ID"):
                    e.SortExpression = "[ID]";
                    break;
                case ("Название блюда"):
                    e.SortExpression = "[Название блюда]";
                    break;
                case ("Цена блюда"):
                    e.SortExpression = "[Цена блюда]";
                    break;
                case ("Время приготовления"):
                    e.SortExpression = "[Время приготовления]";
                    break;
                case ("Сумма заказа"):
                    e.SortExpression = "[Сумма заказа]";
                    break;
                case ("Время заказа"):
                    e.SortExpression = "[Время заказа]";
                    break;
                case ("Фамилия официанта"):
                    e.SortExpression = "[Фамилия официанта]";
                    break;
                case ("Номер бронирования"):
                    e.SortExpression = "[Номер бронирования]";
                    break;
                case ("Номер заказа"):
                    e.SortExpression = "[Номер заказа]"; 
                    break;
                case ("Комментарий"):
                    e.SortExpression = "[Комментарий]";
                    break;
                case ("Количество блюд"):
                    e.SortExpression = "[Количество блюд]";
                    break;
            }
            sortGridView(gvService, e, out sortDirection, out strField);
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

        protected void gvService_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[8].Visible = false;
        }
        //Выбор строки
        protected void gvService_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvService.SelectedRow;
            ddlNameBluda.SelectedValue = row.Cells[1].Text.ToString();
            tbComment.Text = row.Cells[12].Text.ToString();
            tbNumber.Text = row.Cells[10].Text.ToString();
            tbOrderNumber.Text = row.Cells[11].Text.ToString();
            tbPrice.Text = row.Cells[3].Text.ToString();
            tbQuantity.Text = row.Cells[5].Text.ToString();
            tbSum.Text = row.Cells[6].Text.ToString();
            tbSurname.Text = row.Cells[9].Text.ToString();
            tbTime.Text = row.Cells[7].Text.ToString();
            tbTimeCoocking.Text = row.Cells[4].Text.ToString();
            DBConnection.idRecord = Convert.ToInt32(row.Cells[11].Text);
            DBConnection.idOffic = Convert.ToInt32(row.Cells[8].Text);
            btCheckout.Enabled = true;
        }
        //Очистка полей
        private void Cleaner()
        {
            tbComment.Text = string.Empty;
            tbNumber.Text = string.Empty;
            tbOrderNumber.Text = string.Empty;
            tbPrice.Text = string.Empty;
            tbQuantity.Text = string.Empty;
            tbSum.Text = string.Empty;
            tbSurname.Text = string.Empty;
            tbTimeCoocking.Text = string.Empty;
            ddlNameBluda.SelectedIndex = 0;
            btCheckout.Enabled = false;
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            if(DBConnection.idPersonal == 0)
            {
                Response.Redirect("Authorization.aspx");
            }
            else
            {
                string Comment;
                int Sum; //Сумма заказа
                if (tbComment.Text == "")
                {
                    Comment = Convert.ToString(DBNull.Value);
                }
                else
                {
                    Comment = tbComment.Text.ToString();
                }
                Sum = Convert.ToInt32(tbQuantity.Text) * Convert.ToInt32(tbPrice.Text);
                DBProcedures procedures = new DBProcedures();
                procedures.ObslujivanieKlientaInsert(Convert.ToInt32(tbQuantity.Text), Comment, tbTime.Text, Sum, DBConnection.idPersonal, Convert.ToInt32(ddlNameBluda.SelectedValue), Convert.ToInt32(tbNumber.Text));
                gvFill(QR);
                Cleaner();
            }
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            string Comment;
            int Sum; //Сумма заказа
            if (tbComment.Text == "")
            {
                Comment = Convert.ToString(DBNull.Value);
            }
            else
            {
                Comment = tbComment.Text.ToString();
            }
            Sum = Convert.ToInt32(tbQuantity.Text) * Convert.ToInt32(tbPrice.Text);
            DBProcedures procedures = new DBProcedures();
            procedures.ObslujivanieKlientaUpdate(DBConnection.idRecord, Convert.ToInt32(tbQuantity.Text), Comment, tbTime.Text.ToString(), Sum, DBConnection.idOffic, 
                Convert.ToInt32(ddlNameBluda.SelectedValue), Convert.ToInt32(tbNumber.Text));
            gvFill(QR);
            Cleaner();
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            DBProcedures procedures = new DBProcedures();
            procedures.ObslujivanieKlientaDelete(DBConnection.idRecord);
            gvFill(QR);
            Cleaner();
        }
        //Выбор блюда из списка
        protected void ddlNameBluda_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection.idBludaSelected = Convert.ToInt32(ddlNameBluda.SelectedValue);
            BludaDataFill();
        }
        //Поиск
        protected void btSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != "")
            {
                foreach (GridViewRow row in gvService.Rows)
                {
                    if (row.Cells[2].Text.Equals(tbSearch.Text) ||
                        row.Cells[3].Text.Equals(tbSearch.Text) ||
                        row.Cells[4].Text.Equals(tbSearch.Text) ||
                        row.Cells[5].Text.Equals(tbSearch.Text) ||
                        row.Cells[6].Text.Equals(tbSearch.Text) ||
                        row.Cells[7].Text.Equals(tbSearch.Text) ||
                        row.Cells[9].Text.Equals(tbSearch.Text) ||
                        row.Cells[10].Text.Equals(tbSearch.Text) ||
                        row.Cells[11].Text.Equals(tbSearch.Text) ||
                        row.Cells[12].Text.Equals(tbSearch.Text))
                        row.BackColor = ColorTranslator.FromHtml("#a1f2be");
                    else
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
                btCanсel.Visible = true;
            }
        }
        //Фильтрация
        protected void btFilter_Click(object sender, EventArgs e)
        {
            if(tbSearch.Text != "")
            {
                string newQR = QR + "and ([Название блюда] like '%" + tbSearch.Text + "%' or [Цена блюда] like '%" + tbSearch.Text + "%' or [Время приготовления] like '%" + tbSearch.Text + "%' or " +
                    "[Количество блюд] like '%" + tbSearch.Text + "%' or [Сумма заказа] like '%" + tbSearch.Text + "%' or [Время заказа] like '%" + tbSearch.Text + "%'" +
                    "or [Фамилия официанта] like '%" + tbSearch.Text + "%' or [Номер бронирования] like '%" + tbSearch.Text + "%' or [Номер заказа] like '%" + tbSearch.Text + "%'" +
                    "or [Комментарий] like '%" + tbSearch.Text + "%')";
                gvFill(newQR);
                btCanсel.Visible = true;
            }
        }
        //Отмена поиска и фильтрации
        protected void btCanсel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btCanсel.Visible = false;
            gvFill(QR);
        }
        //Оформление заказа
        protected void btCheckout_Click(object sender, EventArgs e)
        {
            DBProcedures procedures = new DBProcedures();
            procedures.RabotaKuhni_Insert(DBConnection.idRecord);
            Cleaner();
            gvFill(QR);
        }
        
        //Подтверждение заказа
        protected void btConfirm_Click(object sender, EventArgs e)
        {
            int columnsCount = gvService.HeaderRow.Cells.Count;
            // Create the PDF Table specifying the number of columns
            PdfPTable pdfTable = new PdfPTable(columnsCount);

            // Loop thru each cell in GrdiView header row
            //foreach (TableCell gridViewHeaderCell in gvService.HeaderRow.Cells)
            //{
            //    // Create the Font Object for PDF document
            //    iTextSharp.text.Font font = new iTextSharp.text.Font();
            //    // Set the font color to GridView header row font color
            //    font.Color = new BaseColor(gvService.HeaderStyle.ForeColor);

            //    // Create the PDF cell, specifying the text and font
            //    PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

            //    // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
            //    pdfCell.BackgroundColor = new BaseColor(gvService.HeaderStyle.BackColor);

            //    // Add the cell to PDF table
            //    pdfTable.AddCell(pdfCell);
            //}

            // Loop thru each datarow in GrdiView
            foreach (GridViewRow gridViewRow in gvService.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    // Loop thru each cell in GrdiView data row
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        iTextSharp.text.Font font = new iTextSharp.text.Font();
                        font.Color = new BaseColor(0, 0, 0);

                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                        pdfCell.BackgroundColor = new BaseColor(gvService.RowStyle.BackColor);

                        pdfTable.AddCell(pdfCell);
                    }
                }
            }

            // Create the PDF document specifying page size and margins
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            // Roate page using Rotate() function, if you want in Landscape
            // pdfDocument.SetPageSize(PageSize.A4.Rotate());

            // Using PageSize.A4_LANDSCAPE may not work as expected
            // Document pdfDocument = new Document(PageSize.A4_LANDSCAPE, 10f, 10f, 10f, 10f);

            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Check.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
}