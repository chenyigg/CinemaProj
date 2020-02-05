using System;
using System.Data.SqlClient;

namespace Model
{
    public class ChipInfoModel
    {
        private int chipInfoID;
        private int cinemaID;
        private int officeID;
        private string movieName;
        private DateTime startTime;
        private DateTime stopTime;

        public ChipInfoModel()
        {
        }

        public ChipInfoModel(int chipInfoID, int cinemaID, int officeID, string movieName, DateTime startTime, DateTime stopTime)
        {
            this.chipInfoID = chipInfoID;
            this.cinemaID = cinemaID;
            this.officeID = officeID;
            this.movieName = movieName;
            this.startTime = startTime;
            this.stopTime = stopTime;
        }

        public ChipInfoModel(SqlDataReader reader)
        {
            if (!reader.IsClosed && reader != null)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    switch (reader.GetName(i).ToLower())
                    {
                        case "chipinfoid":
                            if (!reader.IsDBNull(i))
                                this.ChipInfoID = reader.GetInt32(i);
                            break;

                        case "cinemaid":
                            if (!reader.IsDBNull(i))
                                this.CinemaID = reader.GetInt32(i);
                            break;

                        case "officeid":
                            if (!reader.IsDBNull(i))
                                this.OfficeID = reader.GetInt32(i);
                            break;

                        case "moviename":
                            if (!reader.IsDBNull(i))
                                this.MovieName = reader.GetString(i);
                            break;

                        case "starttime":
                            if (!reader.IsDBNull(i))
                                this.StartTime = reader.GetDateTime(i);
                            break;

                        case "stoptime":
                            if (!reader.IsDBNull(i))
                                this.StopTime = reader.GetDateTime(i);
                            break;
                    }
                }
            }
        }

        public int ChipInfoID { get => chipInfoID; set => chipInfoID = value; }
        public int CinemaID { get => cinemaID; set => cinemaID = value; }
        public int OfficeID { get => officeID; set => officeID = value; }
        public string MovieName { get => movieName; set => movieName = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime StopTime { get => stopTime; set => stopTime = value; }
    }
}