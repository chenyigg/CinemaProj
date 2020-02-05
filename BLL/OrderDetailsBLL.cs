using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderDetailsBLL
    {
        public List<OrderShow> LoadInfo(string v)
        {
            return new OrderDetailsDAL().LoadInfo(v);
        }
    }
}
