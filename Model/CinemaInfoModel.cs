using System.Data.Common;

namespace Models
{
    public class CinemaInfoModel
    {
        private int cinemaID;
        private string cinemaName;
        private string cinemaAddress;
        private string cinemaArea;
        private string cinemaImg;

        public int CinemaID { get => cinemaID; set => cinemaID = value; }
        public string CinemaName { get => cinemaName; set => cinemaName = value; }
        public string CinemaAddress { get => cinemaAddress; set => cinemaAddress = value; }
        public string CinemaArea { get => cinemaArea; set => cinemaArea = value; }
        public string CinemaImg { get => cinemaImg; set => cinemaImg = value; }

        public CinemaInfoModel()
        { }

        //带形参的构造方法
        public CinemaInfoModel(int cinemaID,
         string cinemaName,
         string cinemaAddress,
         string cinemaArea,
         string cinemaImg)
        {
            //通过传入的实参初始化UserInfoModel实体
            this.CinemaID = cinemaID;
            this.CinemaName = cinemaName;
            this.CinemaAddress = cinemaAddress;
            this.CinemaArea = cinemaArea;
            this.CinemaImg = cinemaImg;
        }

        public CinemaInfoModel(DbDataReader reader)
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
                        case "cinemaid"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.CinemaID = reader.GetInt32(i);
                            break;
                        //case和数据库表中的字段保持一致
                        case "cinemaname"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.CinemaName = reader.GetString(i);
                            break;

                        case "cinemaaddress"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.CinemaAddress = reader.GetString(i);
                            break;

                        case "cinemaarea"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.CinemaArea = reader.GetString(i);
                            break;

                        case "cinemaimg"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.CinemaImg = reader.GetString(i);
                            break;
                    }
                }
            }
        }
    }
}