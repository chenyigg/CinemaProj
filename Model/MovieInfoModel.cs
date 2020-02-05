using System;
using System.Data.Common;

namespace Models
{
    public class MovieInfoModel
    {
        private int movieID;
        private string movieName;
        private string movieCover;
        private string movieBrief;
        private double movieMoney;
        private DateTime movieReleaseDate;
        private int movieDuration;
        private string movieDirect;
        private string movieType;
        private string movieArea;
        private int movieYears;
        private decimal movieScore;
        private string moviePeople;

        public int MovieID { get => movieID; set => movieID = value; }
        public string MovieName { get => movieName; set => movieName = value; }
        public string MovieCover { get => movieCover; set => movieCover = value; }
        public string MovieBrief { get => movieBrief; set => movieBrief = value; }
        public double MovieMoney { get => movieMoney; set => movieMoney = value; }
        public DateTime MovieReleaseDate { get => movieReleaseDate; set => movieReleaseDate = value; }
        public int MovieDuration { get => movieDuration; set => movieDuration = value; }
        public string MovieDirect { get => movieDirect; set => movieDirect = value; }
        public string MovieType { get => movieType; set => movieType = value; }
        public string MovieArea { get => movieArea; set => movieArea = value; }
        public int MovieYears { get => movieYears; set => movieYears = value; }
        public decimal MovieScore { get => movieScore; set => movieScore = value; }
        public string MoviePeople { get => moviePeople; set => moviePeople = value; }

        public MovieInfoModel()
        { }

        //带形参的构造方法
        public MovieInfoModel(int movieID,
         string movieName,
         string movieCover,
         string movieBrief,
         double movieMoney,
         DateTime movieReleaseDate,
         int movieDuration,
         string movieDirect, string moviePeople)
        {
            //通过传入的实参初始化UserInfoModel实体
            this.MovieID = movieID;
            this.MovieName = movieName;
            this.MovieCover = movieCover;
            this.MovieBrief = movieBrief;
            this.MovieMoney = movieMoney;
            this.MovieReleaseDate = movieReleaseDate;
            this.MovieDuration = movieDuration;
            this.MovieDirect = movieDirect;
            this.MoviePeople = moviePeople;
        }

        public MovieInfoModel(DbDataReader reader)
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

                        case "moviebrief"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.MovieBrief = reader.GetString(i);
                            break;

                        case "moviereleasedate"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.MovieReleaseDate = reader.GetDateTime(i);
                            break;

                        case "movieduration"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.MovieDuration = reader.GetInt32(i);
                            break;

                        case "moviedirect"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.MovieDirect = reader.GetString(i);
                            break;

                        case "movietype"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.MovieType = reader.GetString(i);
                            break;

                        case "moviearea"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.MovieArea = reader.GetString(i);
                            break;

                        case "movieyears"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.MovieYears = reader.GetInt32(i);
                            break;

                        case "moviescore"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.MovieScore = reader.GetDecimal(i);
                            break;

                        case "moviepeople"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.MoviePeople = reader.GetString(i);
                            break;

                        case "moviemoney"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.MovieMoney = Convert.ToDouble(reader.GetDecimal(i));
                            break;
                    }
                }
            }
        }
    }
}