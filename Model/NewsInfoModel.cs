using System.Data.Common;

namespace Models
{
    public class NewsInfoModel
    {
        private int newsID;
        private string newsPoster;
        private string newsSynopsis;
        private string newsContent;
        private string newsSource;
        private string issueTime;

        public int NewsID { get => newsID; set => newsID = value; }
        public string NewsPoster { get => newsPoster; set => newsPoster = value; }
        public string NewsSynopsis { get => newsSynopsis; set => newsSynopsis = value; }
        public string NewsSource { get => newsSource; set => newsSource = value; }
        public string IssueTime { get => issueTime; set => issueTime = value; }
        public string NewsContent { get => newsContent; set => newsContent = value; }

        public NewsInfoModel()
        { }

        //带形参的构造方法
        public NewsInfoModel(int newsID,
         string newsPoster,
         string newsSynopsis,
         string newsSource,
         string issueTime,
         string newsContent)
        {
            //通过传入的实参初始化UserInfoModel实体
            this.newsID = newsID;
            this.NewsPoster = newsPoster;
            this.newsSynopsis = newsSynopsis;
            this.newsSource = newsSource;
            this.issueTime = issueTime;
            this.newsContent = issueTime;
        }

        public NewsInfoModel(DbDataReader reader)
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
                        case "newsid"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.NewsID = reader.GetInt32(i);
                            break;
                        //case和数据库表中的字段保持一致
                        case "newsposter"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.NewsPoster = reader.GetString(i);
                            break;

                        case "newssynopsis"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.NewsSynopsis = reader.GetString(i);
                            break;

                        case "newssource "://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.NewsSource = reader.GetString(i);
                            break;

                        case "issuetime"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.IssueTime = reader.GetString(i);
                            break;

                        case "newscontent"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.NewsContent = reader.GetString(i);
                            break;
                    }
                }
            }
        }

        /*create table NewsInfo --新闻信息表
(
NewsID int primary key identity(1,1),
NewsPoster Nvarchar(50) Not null,
NewsSynopsis Nvarchar(50) Not null ,
NewsSource Nvarchar(50)	Not Null,
IssueTime Nvarchar(50)	Not Null
)*/
    }
}