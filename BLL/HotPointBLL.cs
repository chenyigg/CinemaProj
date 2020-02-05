using DAL;
using Models;
using System.Collections.Generic;

namespace BLL
{
    public class HotPointBLL
    {
        public List<NewsInfoModel> selectNews()
        {
            return new HotPointDAL().selectNews();
        }
    }
}