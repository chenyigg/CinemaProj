using System;
using System.Data.SqlClient;

namespace Model
{
    public class ShowDetails
    {
        private DateTime startTime;
        private DateTime stopTime;
        private string language;
        private int officeID;
        private int chipInfoID;
        private double money;
        private string officeName;

        public ShowDetails()
        {
        }

        public ShowDetails(SqlDataReader reader)
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

                        case "starttime"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.StartTime = reader.GetDateTime(i);
                            break;

                        case "stoptime"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.StopTime = reader.GetDateTime(i);
                            break;

                        case "language"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.Language = reader.GetString(i);
                            break;

                        case "money"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.Money = Convert.ToDouble(reader.GetDecimal(i));
                            break;

                        case "chipinfoid"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.ChipInfoID = reader.GetInt32(i);
                            break;
                    }
                }
            }
        }

        public ShowDetails(int chipInfoID, DateTime startTime, DateTime stopTime, string language, int officeID, double money, string officeName)
        {
            this.ChipInfoID = chipInfoID;
            this.StartTime = startTime;
            this.StopTime = stopTime;
            this.Language = language;
            this.OfficeID = officeID;
            this.Money = money;
            this.OfficeName = officeName;
        }

        public int ChipInfoID { get => chipInfoID; set => chipInfoID = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime StopTime { get => stopTime; set => stopTime = value; }
        public string Language { get => language; set => language = value; }
        public int OfficeID { get => officeID; set => officeID = value; }
        public double Money { get => money; set => money = value; }
        public string OfficeName { get => officeName; set => officeName = value; }
    }
}