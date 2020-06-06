using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitchenBaseWeb.Pages
{
    public partial class Orders : System.Web.UI.Page
    {
        private string QR = ""; //Переменная для команд БД
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrOrders;
            if (!IsPostBack)
            {
                rpFill(QR);
            }
        }
        //Заполнение данными список заказов
        private void rpFill(string qr)
        {
            sdsOrders.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsOrders.SelectCommand = qr;
            sdsOrders.DataSourceMode = SqlDataSourceMode.DataReader;
            rpOrdersList.DataSource = sdsOrders;
            rpOrdersList.DataBind();
        }
        //Подробнее о заказе
        protected void btDetails_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            //Get the repeater selected row
            var item = (RepeaterItem)btn.NamingContainer;
            //FInd the control from row
            var IdValue = ((Label)item.FindControl("lblID")).Text;
            DBConnection.idRecord = Convert.ToInt32(IdValue);
            Response.Redirect("OrdersDetails.aspx");
        }
    }
}