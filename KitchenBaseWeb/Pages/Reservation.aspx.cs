using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using SautinSoft.Document;

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
        //Очистка полей                               
        protected void Cleaner()
        {
            tbComment.Text = string.Empty;
            tbDate.Text = string.Empty;
            tbQuantity.Text = string.Empty;
            ddlNumber.SelectedIndex = 0;
            ddlTime.SelectedIndex = 0;
            DBConnection.idRecord = 0;
            btWord.Visible = false;
            btPdf.Visible = false;
        }
        protected void btInsert_Click(object sender, EventArgs e)
        {
            string Comment;
            if (DBConnection.idUser == 0)
            {
                Response.Redirect("Authorization.aspx");
            }
            else
            {

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
            btWord.Visible = true;
            btPdf.Visible = true;
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
        /// <summary>
        /// Создание нового документа
        /// </summary>
        /// <param name="Format">Формат файла</param>
        protected void CreateDocx(string Format)
        {
            DBConnection connection = new DBConnection();
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Reservation information № " + Convert.ToString(DBConnection.idRecord) + Format;
            // Путь для скачивания документа
            DocumentCore dc = new DocumentCore();
            Section section = new Section(dc);
            dc.Sections.Add(section);
            section.PageSetup.PaperType = PaperType.A4;
            //Добавление строк
            dc.Content.End.Insert("\nИНФОРМАЦИЯ О БРОНИРОВАНИИ", new CharacterFormat() { FontName = "Times New Roman", Size = 18, FontColor = Color.Black, Bold = true });
            SpecialCharacter lBr = new SpecialCharacter(dc, SpecialCharacterType.LineBreak);
            dc.Content.End.Insert(lBr.Content);
            dc.Content.End.Insert("Вы забронировали стол №" + ddlNumber.SelectedItem.Text + ". Стол забронирован на " + tbDate.Text + " " +
                "в " + Convert.ToString(ddlTime.SelectedItem.Text) + ". Количество гостей " + tbQuantity.Text + ".",
                new CharacterFormat() { FontName = "Times New Roman", Size = 16, FontColor = Color.Black, });
            SpecialCharacter lBr2 = new SpecialCharacter(dc, SpecialCharacterType.LineBreak);
            dc.Content.End.Insert(lBr2.Content);
            dc.Content.End.Insert("Ваш номер бронирования " + Convert.ToString(DBConnection.idRecord) + ".",
                new CharacterFormat() { FontName = "Times New Roman", Size = 16, FontColor = Color.Black, });
            SpecialCharacter lBr3 = new SpecialCharacter(dc, SpecialCharacterType.LineBreak);
            dc.Content.End.Insert(lBr2.Content);
            dc.Content.End.Insert("Кому, " + connection.KlientData(DBConnection.idKlient) + ".",
                new CharacterFormat() { FontName = "Times New Roman", Size = 14, FontColor = Color.Black });
            //Документ в формате .docx
            if (Format == ".docx")
            {
                // Сохраняем документ в формате .docx
                dc.Save(docPath, new DocxSaveOptions());

                // Открываем документ
                Process.Start(new ProcessStartInfo(docPath) { UseShellExecute = true });
            }
            //Документ в другом формате (тут .pdf)
            else
            {
                dc.Save(docPath, new PdfSaveOptions()
                {
                    Compliance = PdfCompliance.PDF_A,
                    PreserveFormFields = true
                });

                // Open the result for demonstration purposes.
                Process.Start(new ProcessStartInfo(docPath) { UseShellExecute = true });
            }
        }
        //Создание документа .Word
        protected void btWord_Click(object sender, EventArgs e)
        {
            try
            {
                CreateDocx(".docx");
                Cleaner();
                lblExportError.Visible = false;
            }
            catch
            {
                lblExportError.Visible = true;
            }
        }
        //Создание документа .PDF
        protected void btPdf_Click(object sender, EventArgs e)
        {
            try
            {
                CreateDocx(".pdf");
                Cleaner();
                lblExportError.Visible = false;
            }
            catch
            {
                lblExportError.Visible = true;
            }
        }
    }
}