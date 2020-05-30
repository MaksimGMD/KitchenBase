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
            //QR = DBConnection.qrEmployeeList;
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
    }
}