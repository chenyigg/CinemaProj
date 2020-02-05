using Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class HotPointDAL
    {
        /// <summary>
        /// 查询新闻
        /// </summary>
        /// <returns></returns>
        public List<NewsInfoModel> selectNews()
        {
            List<NewsInfoModel> list = new List<NewsInfoModel>();
            string sql = "select *from NewsInfo";
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql);
            while (reader.Read())
            {
                NewsInfoModel news = new NewsInfoModel(reader);
                list.Add(news);
            }
            reader.Close();
            return list;
        }
    }
}