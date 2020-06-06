using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitchenBaseWeb.Pages
{
    public partial class OrdersDetails : System.Web.UI.Page
    {
        private string QR = ""; //Переменная для команд БД
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrOrdersMore + " where [Номер заказа] = " + DBConnection.idRecord + "";
            if (!IsPostBack)
            {
                gvFill(QR);
            }
        }
        private void gvFill(string qr)
        {
            sdsOrders.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsOrders.SelectCommand = qr;
            sdsOrders.DataSourceMode = SqlDataSourceMode.DataReader;
            gvBludo.DataSource = sdsOrders;
            gvBludo.DataBind();
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Orders.aspx");
            DBConnection.idRecord = 0;
        }
        //Подтверждение заказа
        protected void btConfirm_Click(object sender, EventArgs e)
        {
            DBProcedures procedures = new DBProcedures();
            procedures.RabotaKuhni_Update(DBConnection.idRecord);
            Response.Redirect("Orders.aspx");
        }
    }
}