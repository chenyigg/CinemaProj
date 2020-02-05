using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderShow
    {
        private string movieName;
        private DateTime orderTime;
        private DateTime startTime;
        private string cinemaName;
        private string officeName;
        private int nullColOne;
        private int nullColTwo;
        private int payTime;
        private int isPay;
        private int orderID;
        private int chipInfoID;
        private string seatID;
        private decimal orderSumMoney;
        private string[] seatSum;

        public OrderShow()
        {
        }

        public OrderShow(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    switch (reader.GetName(i).ToLower())
                    {
                        case "seatid":
                            if (!reader.IsDBNull(i))
                            {
                                SeatID = reader.GetInt32(i).ToString();
                            }
                            break;

                        case "orderid":
                            if (!reader.IsDBNull(i))
                            {
                                OrderID = reader.GetInt32(i);
                            }
                            break;

                        case "nullcolone":
                            if (!reader.IsDBNull(i))
                            {
                                NullColOne = reader.GetInt32(i);
                            }
                            break;

                        case "nullcoltwo":
                            if (!reader.IsDBNull(i))
                            {
                                NullColTwo = reader.GetInt32(i);
                            }
                            break;

                        case "ordertime":
                            if (!reader.IsDBNull(i))
                            {
                                OrderTime = reader.GetDateTime(i);
                            }
                            break;

                        case "moviename":
                            if (!reader.IsDBNull(i))
                            {
                                MovieName = reader.GetString(i);
                            }
                            break;

                        case "cinemaname":
                            if (!reader.IsDBNull(i))
                            {
                                CinemaName = reader.GetString(i);
                            }
                            break;

                        case "officename":
                            if (!reader.IsDBNull(i))
                            {
                                OfficeName = reader.GetString(i);
                            }
                            break;

                        case "chipinfoid":
                            if (!reader.IsDBNull(i))
                            {
                                ChipInfoID = reader.GetInt32(i);
                            }
                            break;

                        case "ordersummoney":
                            if (!reader.IsDBNull(i))
                            {
                                OrderSumMoney = reader.GetDecimal(i);
                            }
                            break;

                        case "paytime":
                            if (!reader.IsDBNull(i))
                            {
                                PayTime = reader.GetInt32(i);
                            }
                            break;

                        case "starttime":
                            if (!reader.IsDBNull(i))
                            {
                                StartTime = reader.GetDateTime(i);
                            }
                            break;

                        case "ispay":
                            if (!reader.IsDBNull(i))
                            {
                                IsPay = reader.GetInt32(i);
                            }
                            break;
                    }
                }
            }
        }

        public OrderShow(string movieName, DateTime orderTime, string cinemaName,
            int officeID, string[] seatSum, int chipInfoID, int nullColOne, int nullColTwo,
            string seatID, string officeName, decimal OrderSumMoney, int payTime,
            int orderID, DateTime starTime, int isPay)
        {
            this.movieName = movieName;
            this.orderTime = orderTime;
            this.cinemaName = cinemaName;
            this.officeName = officeName;
            this.seatSum = seatSum;
            this.chipInfoID = chipInfoID;
            this.nullColOne = nullColOne;
            this.nullColTwo = nullColTwo;
            this.seatID = seatID;
            this.orderID = orderID;
            this.orderSumMoney = OrderSumMoney;
            this.PayTime = payTime;
            this.StartTime = starTime;
            this.IsPay = isPay;
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

        public DateTime OrderTime
        {
            get
            {
                return orderTime;
            }

            set
            {
                orderTime = value;
            }
        }

        public string CinemaName
        {
            get
            {
                return cinemaName;
            }

            set
            {
                cinemaName = value;
            }
        }

        public string OfficeName
        {
            get
            {
                return officeName;
            }

            set
            {
                officeName = value;
            }
        }

        public string[] SeatSum
        {
            get
            {
                return seatSum;
            }

            set
            {
                seatSum = value;
            }
        }

        public int ChipInfoID
        {
            get
            {
                return chipInfoID;
            }

            set
            {
                chipInfoID = value;
            }
        }

        public int NullColOne
        {
            get
            {
                return nullColOne;
            }

            set
            {
                nullColOne = value;
            }
        }

        public int NullColTwo
        {
            get
            {
                return nullColTwo;
            }

            set
            {
                nullColTwo = value;
            }
        }

        public string SeatID
        {
            get
            {
                return seatID;
            }

            set
            {
                seatID = value;
            }
        }

        public decimal OrderSumMoney
        {
            get
            {
                return orderSumMoney;
            }

            set
            {
                orderSumMoney = value;
            }
        }

        public int PayTime
        {
            get
            {
                return payTime;
            }

            set
            {
                payTime = value;
            }
        }

        public int OrderID
        {
            get
            {
                return orderID;
            }

            set
            {
                orderID = value;
            }
        }

        public DateTime StartTime { get => startTime; set => startTime = value; }

        public int IsPay
        {
            get
            {
                return isPay;
            }

            set
            {
                isPay = value;
            }
        }
    }
}