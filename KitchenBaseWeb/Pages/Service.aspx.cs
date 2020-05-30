using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitchenBaseWeb.Pages
{
    public partial class Service : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrService;
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
            //e.Row.Cells[1].Visible = false;
        }
        //Выбор строки
        protected void gvService_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}