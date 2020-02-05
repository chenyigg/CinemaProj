using System;
using System.Data.Common;

namespace Model
{
    public class CommentModel
    {
        private int commentID;

        private int movieID;

        private int usersID;

        private string userName;

        private string userFace;

        private string commentInfo;

        private DateTime commentTime;

        public CommentModel()
        {
        }

        public CommentModel(int movieID, int usersID, string userName, string userFace, string commentInfo, DateTime commentTime)
        {
            this.MovieID = movieID;
            this.usersID = usersID;
            this.userName = userName;
            this.userFace = userFace;
            this.commentInfo = commentInfo;
            this.commentTime = commentTime;
        }

        public CommentModel(DbDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    switch (reader.GetName(i).ToLower())
                    {
                        case "commentid":
                            if (!reader.IsDBNull(i))
                                this.CommentID = reader.GetInt32(i);
                            break;

                        case "movieid":
                            if (!reader.IsDBNull(i))
                                this.MovieID = reader.GetInt32(i);
                            break;

                        case "usersid":
                            if (!reader.IsDBNull(i))
                                this.UsersID = reader.GetInt32(i);
                            break;

                        case "username":
                            if (!reader.IsDBNull(i))
                                this.UserName = reader.GetString(i);
                            break;

                        case "userface":
                            if (!reader.IsDBNull(i))
                                this.UserFace = reader.GetString(i);
                            break;

                        case "commentinfo":
                            if (!reader.IsDBNull(i))
                                this.CommentInfo = reader.GetString(i);
                            break;

                        case "commenttime":
                            if (!reader.IsDBNull(i))
                                this.CommentTime = reader.GetDateTime(i);
                            break;
                    }
                }
            }
        }

        public int CommentID
        {
            get
            {
                return commentID;
            }

            set
            {
                commentID = value;
            }
        }

        public int UsersID
        {
            get
            {
                return usersID;
            }

            set
            {
                usersID = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string UserFace
        {
            get
            {
                return userFace;
            }

            set
            {
                userFace = value;
            }
        }

        public string CommentInfo
        {
            get
            {
                return commentInfo;
            }

            set
            {
                commentInfo = value;
            }
        }

        public DateTime CommentTime
        {
            get
            {
                return commentTime;
            }

            set
            {
                commentTime = value;
            }
        }

        public int MovieID
        {
            get
            {
                return movieID;
            }

            set
            {
                movieID = value;
            }
        }
    }
}