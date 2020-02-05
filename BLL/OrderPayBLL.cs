using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderPayBLL
    {
        public OrderShow LoadInfo(OrderInfoModel om)
        {
            OrderShow oh = new OrderPayDAL().LoadInfo(om);
            oh = Change(oh);
            return oh;
        }

        public OrderShow Change(OrderShow oh)
        {
            for (int k = 0; k < oh.SeatSum.Length; k++)
            {
                var i = Convert.ToInt32(oh.SeatSum[k]);
                var zuowei = "";
                if (i % 160 % 16 < oh.NullColOne)
                {
                    zuowei = (int.Parse((i % 160 / 16).ToString()) + 1).ToString() + "排" + (i % 160 % 16).ToString() + "座";
                    if (i % 160 % 16 == 0)
                    {
                        zuowei = int.Parse((i % 160 / 16).ToString()).ToString() + "排" + "14" + "座";
                    }
                }
                else if (i % 160 % 16 < oh.NullColTwo)
                {
                    zuowei = (int.Parse((i % 160 / 16).ToString()) + 1).ToString() + "排" + (i % 160 % 16 - 1).ToString() + "座";
                }
                else if (i % 160 % 16 < 16)
                {
                    zuowei = (int.Parse((i % 160 / 16).ToString()) + 1).ToString() + "排" + (i % 160 % 16 - 2).ToString() + "座";
                }
                oh.SeatSum[k] = zuowei;
            }

            return oh;
        }

        public int UpdateSeat(string v)
        {
            return new OrderPayDAL().UpdateSeat(v);
        }

        public int SelectIsPay()
        {
            return new OrderPayDAL().SelectIsPay();
        }
    }
}