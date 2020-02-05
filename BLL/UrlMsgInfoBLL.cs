using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UrlMsgInfoBLL
    {
        public int Update()
        {
            return new UrlMsgInfoDAL().Update();
        }
    }
}