using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class ChooseOfficeDAL
    {
        /// <summary>
        /// 找到该影院信息
        /// </summary>
        /// <param name="om"></param>
        /// <returns></returns>
        public CinemaInfoModel FindOffice(CinemaInfoModel om)
        {
            string str = "select * from CinemaInfo where CinemaID=@CinemaID";

            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@CinemaID",System.Data.SqlDbType.Int){Value=om.CinemaID }
            };

            SqlDataReader reader = SqlHelper.ExecuteReader(str, System.Data.CommandType.Text, sqlParameters);

            CinemaInfoModel oi = new CinemaInfoModel();
            while (reader.Read())
            {
                oi = new CinemaInfoModel(reader);
            }
            reader.Close();
            return oi;
        }

        /// <summary>
        /// 传入影院ID和电影ID时返回厅院上映信息
        /// </summary>
        /// <param name="mi"></param>
        /// <param name="om"></param>
        /// <returns></returns>
        public List<ShowDetails> FindShowDetails(MovieInfoModel mi, CinemaInfoModel om)
        {
            string str;
            SqlParameter[] sqlParameters = null;
            if (mi.MovieID != 0)
            {
                //通过电影ID查询到该电影信息
                str = "select * from MovieInfo where MovieID =@MovieID";
                sqlParameters = new SqlParameter[] {
                    new SqlParameter("@MovieID",System.Data.SqlDbType.Int){Value=mi.MovieID }
                };
            }
            else
            {
                // 在没有电影ID的时候，查询该电影院的Top 1排片电影
                str = " Select Top 1* from MovieInfo where MovieName in " +
                             "(select MovieName from[dbo].[ChipInfo] where CinemaID = @CinemaID " +
                             " and datediff(MINUTE, getdate(),StartTime)>15)";

                sqlParameters = new SqlParameter[] {
                      new SqlParameter("@CinemaID",System.Data.SqlDbType.Int){Value=om.CinemaID}
                };
            }

            SqlDataReader reader = SqlHelper.ExecuteReader(str, System.Data.CommandType.Text, sqlParameters);

            MovieInfoModel mo = new MovieInfoModel();
            while (reader.Read())
            {
                mo = new MovieInfoModel(reader);
            }
            reader.Close();

            //上映详情集合
            List<ShowDetails> ls = new List<ShowDetails>();

            if (String.IsNullOrEmpty(mo.MovieName))
            {
                return ls;
            }

            //通过传入的影院ID获取该排片的开始结束时间、且必须为今日排片、离上映时间大于15分钟
            str = "select * from [dbo].[ChipInfo] where CinemaID=@CinemaID and datediff(MINUTE,getdate(),StartTime)>15 and Convert(nvarchar,StartTime,120) like @TimeNow+'%' and MovieName=@MovieName";
            sqlParameters = new SqlParameter[] {
                new SqlParameter("@CinemaID",System.Data.SqlDbType.Int){Value=om.CinemaID },
                new SqlParameter("@MovieName",System.Data.SqlDbType.NVarChar){Value=mo.MovieName },
                new SqlParameter("@TimeNow",System.Data.SqlDbType.NVarChar){Value=DateTime.Now.ToString().Substring(0, DateTime.Now.ToString().IndexOf(' ')).Replace('/', '-') }
            };

            reader = SqlHelper.ExecuteReader(str, System.Data.CommandType.Text, sqlParameters);

            //排片集合
            List<ChipInfoModel> os = new List<ChipInfoModel>();
            while (reader.Read())
            {
                ChipInfoModel oi = new ChipInfoModel(reader);
                os.Add(oi);
            }
            reader.Close();

            //将该影院所有关于该电影的排片信息（开始结束时间）放入ShowDetails集合
            for (int i = 0; i < os.Count; i++)
            {
                ls.Add(new ShowDetails() { ChipInfoID = os[i].ChipInfoID, StartTime = os[i].StartTime, StopTime = os[i].StopTime, Money = mo.MovieMoney, Language = mo.MovieArea });
            }

            List<OfficeInfoModel> of = new List<OfficeInfoModel>();
            //通过传入的影院ID获取厅信息
            for (int i = 0; i < os.Count; i++)
            {
                str = " select * from [dbo].[OfficeInfo] where [OfficeID] in  (@OfficeID)";
                sqlParameters = new SqlParameter[] {
                    new SqlParameter("@OfficeID",System.Data.SqlDbType.Int){Value=os[i].OfficeID }
                };

                reader = SqlHelper.ExecuteReader(str, System.Data.CommandType.Text, sqlParameters);

                //获取到了所有的厅位信息
                while (reader.Read())
                {
                    OfficeInfoModel ofs = new OfficeInfoModel(reader);
                    of.Add(ofs);
                }
                reader.Close();
            }

            for (int i = 0; i < of.Count; i++)
            {
                ls[i].OfficeID = of[i].OfficeID;
                ls[i].OfficeName = of[i].OfficeName;
            }

            return ls;
        }

        public List<ShowDetails> FindTod(MovieInfoModel mi, CinemaInfoModel om)
        {
            string str = "select ch.StartTime,ch.StopTime,mi.MovieArea,ofi.OfficeID,ofi.OfficeName,ch.ChipInfoID,mi.MovieMoney as [Money] from ChipInfo ch ,MovieInfo mi, OfficeInfo ofi where ch.MovieName = mi.MovieName and ch.OfficeID = ofi.OfficeID and ch.CinemaID = @CinemaID and ch.MovieName = @MovieName and ch.StartTime >= Convert(DateTime, CONVERT(nvarchar, GETDATE(), 23) + ' 00:00:00') and datediff(MINUTE,getdate(),StartTime)>15 AND ch.StartTime < Convert(DateTime, CONVERT(nvarchar, GETDATE() , 23) + ' 23:59:59')";

            SqlParameter[] sqlParameters = new SqlParameter[] {
                    new SqlParameter("@CinemaID",System.Data.SqlDbType.Int){Value=om.CinemaID },
                    new SqlParameter("@MovieName",System.Data.SqlDbType.NVarChar){Value=mi.MovieName }
            };

            SqlDataReader reader = SqlHelper.ExecuteReader(str, System.Data.CommandType.Text, sqlParameters);

            List<ShowDetails> ls = new List<ShowDetails>();
            //获取到了所有的厅位信息
            while (reader.Read())
            {
                ShowDetails ofs = new ShowDetails(reader);
                ls.Add(ofs);
            }
            reader.Close();

            return ls;
        }

        /// <summary>
        /// 根据传入的影院ID和电影ID返回厅院电影信息
        /// </summary>
        /// <param name="mi"></param>
        /// <param name="om"></param>
        /// <returns></returns>
        public List<MovieInfoModel> FindMovieInfo(MovieInfoModel mi, CinemaInfoModel om)
        {
            string str;
            SqlParameter[] sqlParameters = null;
            str = "Select * from MovieInfo where MovieName in ( select MovieName from [dbo].[ChipInfo] where CinemaID=@CinemaID)";
            sqlParameters = new SqlParameter[] {
                    new SqlParameter("@CinemaID",System.Data.SqlDbType.Int){Value=om.CinemaID }
            };

            SqlDataReader reader = SqlHelper.GetSqlDataReader(str, sqlParameters);

            //获取到该电影院所有的排片电影
            List<MovieInfoModel> ls = new List<MovieInfoModel>();
            while (reader.Read())
            {
                ls.Add(new MovieInfoModel(reader));
            }
            reader.Close();

            return ls;
        }

        public List<ShowDetails> FindTom(MovieInfoModel mi, CinemaInfoModel om)
        {
            string str = "  select ch.StartTime,ch.StopTime,mi.MovieArea,ofi.OfficeID,ofi.OfficeName,ch.ChipInfoID,mi.MovieMoney as [Money] from ChipInfo ch ,MovieInfo mi, OfficeInfo ofi where ch.MovieName = mi.MovieName and ch.OfficeID = ofi.OfficeID and ch.CinemaID = @CinemaID and ch.MovieName = @MovieName and ch.StartTime >= Convert(DateTime, CONVERT(nvarchar, GETDATE(), 23) + ' 23:59:00') AND ch.StartTime < Convert(DateTime, CONVERT(nvarchar, GETDATE() + 1, 23) + ' 23:59:59')";

            SqlParameter[] sqlParameters = new SqlParameter[] {
                    new SqlParameter("@CinemaID",System.Data.SqlDbType.Int){Value=om.CinemaID },
                    new SqlParameter("@MovieName",System.Data.SqlDbType.NVarChar){Value=mi.MovieName }
            };

            SqlDataReader reader = SqlHelper.ExecuteReader(str, System.Data.CommandType.Text, sqlParameters);

            List<ShowDetails> ls = new List<ShowDetails>();
            //获取到了所有的厅位信息
            while (reader.Read())
            {
                ShowDetails ofs = new ShowDetails(reader);
                ls.Add(ofs);
            }
            reader.Close();

            return ls;
        }
    }
}