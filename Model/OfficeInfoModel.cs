using System.Data.Common;

namespace Models
{
    public class OfficeInfoModel
    {
        private int officeID;
        private string officeName;
        private int cinemaID;

        public int OfficeID { get => officeID; set => officeID = value; }
        public string OfficeName { get => officeName; set => officeName = value; }
        public int CinemaID { get => cinemaID; set => cinemaID = value; }

        public OfficeInfoModel()
        { }

        //带形参的构造方法
        public OfficeInfoModel(int officeID,
         string officeName,
         int cinemaID)
        {
            //通过传入的实参初始化UserInfoModel实体
            this.OfficeID = officeID;
            this.OfficeName = officeName;
            this.CinemaID = cinemaID;
        }

        public OfficeInfoModel(DbDataReader reader)
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
                        case "officeid"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.OfficeID = reader.GetInt32(i);
                            break;
                        //case和数据库表中的字段保持一致
                        case "officename"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.OfficeName = reader.GetString(i);
                            break;

                        case "cinemaid"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.CinemaID = reader.GetInt32(i);
                            break;
                    }
                }
            }
        }
    }
}