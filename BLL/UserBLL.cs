using DAL;
using Models;

namespace BLL
{
    public class UserBLL
    {
        /// <summary>
        /// 根据账号判断该用户资料是否完善
        /// </summary>
        /// <param name="User">用户对象</param>
        /// <returns>用户对象集合</returns>
        public UsersInfoModel SelectUserInfoFromAccount(UsersInfoModel User)
        {
            return new UserDAL().SelectUserInfoFromAccount(User);
        }

        /// <summary>
        /// 更新用户资料
        /// </summary>
        /// <param name="use">用户对象</param>
        /// <returns>Int</returns>
        public int UpdataUsersInfo(UsersInfoModel use)
        {
            return new UserDAL().UpdataUsersInfo(use);
        }
    }
}