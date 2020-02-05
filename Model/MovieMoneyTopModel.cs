using System.Data.Common;

namespace Model
{
    public class MovieMoneyTopModel
    {
        private int movieID;
        private string movieName;
        private string movieCover;
        private string sumMoney;

        public int MovieID { get => movieID; set => movieID = value; }
        public string MovieName { get => movieName; set => movieName = value; }
        public string MovieCover { get => movieCover; set => movieCover = value; }
        public string SumMoney { get => sumMoney; set => sumMoney = value; }

        public MovieMoneyTopModel()
        {
        }

        public MovieMoneyTopModel(int movieID, string movieName, string movieCover, string sumMoney)
        {
            this.movieID = movieID;
            this.movieName = movieName;
            this.movieCover = movieCover;
            this.sumMoney = sumMoney;
        }

        public MovieMoneyTopModel(DbDataReader reader)
        {
            //通过传入的reader对象初始化UserInfoModel实体
            //判断reader对象是否为空且是否处于关闭状态
            if (reader != null && !reader.IsClosed)
            {
                //遍历reader对象；reader.FieldCount有多少列
                for (int i = 0, cnt = reader.FieldCount; i < cnt; i++)
                {
                    //reader.GetName(i)得到字段的名字
                    //ToLower()把字符串改成小写
                    switch (reader.GetName(i).ToLower())
                    {
                        //case和数据库表中的字段保持一致
                        case "movieid"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.MovieID = reader.GetInt32(i);
                            break;
                        //case和数据库表中的字段保持一致
                        case "moviename"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.MovieName = reader.GetString(i);
                            break;

                        case "moviecover"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.MovieCover = reader.GetString(i);
                            break;

                        case "SumMoney"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.SumMoney = reader.GetString(i);
                            break;
                    }
                }
            }
        }
    }
}