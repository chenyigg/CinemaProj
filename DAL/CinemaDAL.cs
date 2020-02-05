using Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class CinemaDAL
    {
        public List<OfficeInfoModel> FindOfficeName()
        {
            string str = "select distinct OfficeName from OfficeInfo";

            SqlDataReader reader = SqlHelper.GetSqlDataReader(str);

            List<OfficeInfoModel> ls = new List<OfficeInfoModel>();

            while (reader.Read())
            {
                OfficeInfoModel of = new OfficeInfoModel(reader);
                ls.Add(of);
            }

            reader.Close();
            return ls;
        }

        public List<CinemaInfoModel> FindCinema()
        {
            string str = "select * from CinemaInfo";

            SqlDataReader reader = SqlHelper.GetSqlDataReader(str);

            List<CinemaInfoModel> ls = new List<CinemaInfoModel>();

            while (reader.Read())
            {
                CinemaInfoModel ci = new CinemaInfoModel(reader);
                ls.Add(ci);
            }

            reader.Close();
            return ls;
        }

        public List<CinemaInfoModel> Filtrate(string CinemaArea, string OfficeName)
        {
            string str = "select distinct c.CinemaID,c.CinemaName,c.CinemaAddress,c.CinemaArea from CinemaInfo c ,[dbo].[OfficeInfo] o " +
                "where c.CinemaID=o.CinemaID and c.CinemaArea like '%'+@CinemaArea+'%' and o.OfficeName like '%'+@OfficeName+'%' ";

            SqlParameter[] sqlParameters = new SqlParameter[] {
            new SqlParameter("@CinemaArea",System.Data.SqlDbType.NVarChar){Value=CinemaArea },
             new SqlParameter("@OfficeName",System.Data.SqlDbType.NVarChar){Value=OfficeName },
            };

            SqlDataReader reader = SqlHelper.ExecuteReader(str, System.Data.CommandType.Text, sqlParameters);

            List<CinemaInfoModel> ls = new List<CinemaInfoModel>();

            while (reader.Read())
            {
                CinemaInfoModel ci = new CinemaInfoModel(reader);
                ls.Add(ci);
            }

            reader.Close();
            return ls;
        }
    }
}