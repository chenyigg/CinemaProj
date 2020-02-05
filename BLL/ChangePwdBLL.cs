using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChangePwdBLL
    {
        public UsersInfoModel HasPwd(UsersInfoModel use)
        {
            return new ChangePwdDAL().HasPwd(use);
        }

        public int UpdatePwd(UsersInfoModel use)
        {
            return new ChangePwdDAL().UpdatePwd(use);
        }
    }
}