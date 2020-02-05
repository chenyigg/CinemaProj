using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class OrderPay : System.Web.UI.Page
    {
        public static OrderShow oh;
        public static int Count;
        public static int p = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["OrderID"] != null)
                {
                    LoadInfo(Request["OrderID"]);
                }
                if (p == 0)
                {
                    //获取初始值
                    Count = new OrderPayBLL().SelectIsPay();
                }

                p += 1;
            }

            if (Request["Method"] != null)
            {
                switch (Request["Method"])
                {
                    case "IsPay":
                        IsPay(Request["OI"]);
                        break;
                }
            }
        }

        private void IsPay(string x)
        {
            int k = new OrderPayBLL().SelectIsPay();

            if (k != Count)
            {
                Count = k;

                int ppp = new OrderPayBLL().UpdateSeat(x);

                if (ppp > 0)
                {
                    Response.Write("{\"state\":\"ok\"}");
                    Response.End();
                }
            }
            else
            {
                Response.Write("{\"state\":\"no\"}");
                Response.End();
            }
        }

        private void LoadInfo(string st)
        {
            OrderInfoModel om = new OrderInfoModel();
            om.OrderID = Convert.ToInt32(st);
            oh = new OrderPayBLL().LoadInfo(om);
        }
    }
}