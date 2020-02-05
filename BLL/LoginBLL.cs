using DAL;
using Models;
using System.Collections.Generic;

namespace BLL
{
    public class LoginBLL
    {
        /// <summary>
        /// 进行登录账号判断
        /// </summary>
        /// <param name="UsersInfo">用户层</param>
        /// <returns>布尔</returns>
        public bool SelectUsersInfo(UsersInfoModel UsersInfo, out bool lv)
        {
            List<UsersInfoModel> ls = new LoginDAL().SelectUsersInfo();
            lv = false;

            foreach (UsersInfoModel item in ls)
            {
                if (item.UserAccount == UsersInfo.UserAccount && item.UsersPwd == UsersInfo.UsersPwd)
                {
                    if (item.UserLevelNum == 2)
                    {
                        lv = true;
                    }
                    else
                    {
                        lv = false;
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 查询用户名是否重复
        /// </summary>
        /// <returns>用户集合</returns>
        public List<UsersInfoModel> HasUser()
        {
            return new LoginDAL().SelectUsersInfo();
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="users"></param>
        /// <returns>Int</returns>
        public int InsertIntoUser(UsersInfoModel users)
        {
            return new LoginDAL().InsertIntoUser(users);
        }
    }
}