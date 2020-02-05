using System;
using System.Data.Common;

namespace Model
{
    public class OrdersGoodsInfoModel
    {
        private int cinemaID;
        private int officeID;
        private string movieName;
        private DateTime startTime;
        private DateTime stopTime;

        public OrdersGoodsInfoModel()
        {
        }

        public OrdersGoodsInfoModel(int cinemaID, int officeID, string movieName, DateTime startTime, DateTime stopTime)
        {
            CinemaID = cinemaID;
            OfficeID = officeID;
            MovieName = movieName;
            StartTime = startTime;
            StopTime = stopTime;
        }

        public OrdersGoodsInfoModel(DbDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    switch (reader.GetName(i).ToLower())
                    {
                        case "cinemaid":
                            if (!reader.IsDBNull(i))
                            {
                                this.CinemaID = reader.GetInt32(i);
                            }
                            break;

                        case "officeid":
                            if (!reader.IsDBNull(i))
                            {
                                this.OfficeID = reader.GetInt32(i);
                            }
                            break;

                        case "moviename":
                            if (!reader.IsDBNull(i))
                            {
                                this.MovieName = reader.GetString(i);
                            }
                            break;

                        case "starttime":
                            if (!reader.IsDBNull(i))
                            {
                                this.StartTime = reader.GetDateTime(i);
                            }
                            break;

                        case "stoptime":
                            if (!reader.IsDBNull(i))
                            {
                                this.StopTime = reader.GetDateTime(i);
                            }
                            break;
                    }
                }
            }
        }

        public int CinemaID
        {
            get
            {
                return cinemaID;
            }

            set
            {
                cinemaID = value;
            }
        }

        public int OfficeID
        {
            get
            {
                return officeID;
            }

            set
            {
                officeID = value;
            }
        }

        public string MovieName
        {
            get
            {
                return movieName;
            }

            set
            {
                movieName = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
            }
        }

        public DateTime StopTime
        {
            get
            {
                return stopTime;
            }

            set
            {
                stopTime = value;
            }
        }
    }
}