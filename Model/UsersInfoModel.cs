using System.Data.Common;

namespace Models
{
    public class UsersInfoModel
    {
        private int usersID;
        private string userAccount;
        private string usersPwd;
        private string userName;
        private string userSex;
        private string userPhone;
        private string userIDCard;
        private string userAddress;
        private int userLevelNum;
        private int userMvp;
        private string userFace;
        private string userEmail;

        public int UsersID { get => usersID; set => usersID = value; }
        public string UserAccount { get => userAccount; set => userAccount = value; }
        public string UsersPwd { get => usersPwd; set => usersPwd = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserSex { get => userSex; set => userSex = value; }
        public string UserPhone { get => userPhone; set => userPhone = value; }
        public string UserIDCard { get => userIDCard; set => userIDCard = value; }
        public string UserAddress { get => userAddress; set => userAddress = value; }
        public int UserLevelNum { get => userLevelNum; set => userLevelNum = value; }
        public int UserMvp { get => userMvp; set => userMvp = value; }
        public string UserFace { get => userFace; set => userFace = value; }
        public string UserEmail { get => userEmail; set => userEmail = value; }

        public UsersInfoModel()
        { }

        //带形参的构造方法
        public UsersInfoModel(int usersID, string userAccount,
            string usersPwd, string userName, string userSex, string userPhone,
            string userIDCard, string userAddress, int userLevelNum, int userMvp, string userFace, string userEmail)
        {
            //通过传入的实参初始化UserInfoModel实体
            this.UsersID = usersID;
            this.UserAccount = userAccount;
            this.UsersPwd = usersPwd;
            this.UserName = userName;
            this.UserSex = userSex;
            this.UserPhone = userPhone;
            this.UserIDCard = userIDCard;
            this.UserAddress = userAddress;
            this.UserLevelNum = userLevelNum;
            this.UserMvp = userMvp;
            this.UserFace = userFace;
            this.UserEmail = userEmail;
        }

        public UsersInfoModel(DbDataReader reader)
        {
            //通过传入的reader对象初始化UserInfoModel实体
            //判断reader对象是否为空且是否处于关闭状态
            if (reader != null && !reader.IsClosed)
            {
                //遍历reader对象；reader.FieldCount有多少列
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    //reader.GetName(i)得到字段的名字
                    //ToLower()把字符串改成小写
                    switch (reader.GetName(i).ToLower())
                    {
                        //case和数据库表中的字段保持一致
                        case "usersid"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.UsersID = reader.GetInt32(i);
                            break;
                        //case和数据库表中的字段保持一致
                        case "useraccount"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.UserAccount = reader.GetString(i);
                            break;

                        case "userspwd"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.UsersPwd = reader.GetString(i);
                            break;

                        case "username"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.UserName = reader.GetString(i);
                            break;

                        case "usersex"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.UserSex = reader.GetString(i);
                            break;

                        case "userphone"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.UserPhone = reader.GetString(i);
                            break;

                        case "useridcard"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.UserIDCard = reader.GetString(i);
                            break;

                        case "useraddress"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.UserAddress = reader.GetString(i);
                            break;

                        case "userlevelnum"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.UserLevelNum = reader.GetInt32(i);
                            break;

                        case "usermvp"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.UserMvp = reader.GetInt32(i);
                            break;

                        case "userface"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.UserFace = reader.GetString(i);
                            break;

                        case "useremail"://字段名字
                            if (!reader.IsDBNull(i))
                                //reader.GetString(i); 取当前列对应的值,值的类型和数据库的类型一致
                                this.UserEmail = reader.GetString(i);
                            break;
                    }
                }
            }
        }
    }
}