using System;
using System.Data.Common;

namespace Model
{
    public class OrderInfoModel
    {
        private int orderID;
        private decimal orderSumMoney;
        private int usersID;
        private DateTime orderTime;
        private string movieName;
        private string cinemaAddress;
        private int officeID;
        private int payTime;
        private int chipInfoID;
        private int isPay;

        public OrderInfoModel()
        {
        }

        public OrderInfoModel(int orderID, decimal orderSumMoney, int usersID,
            DateTime orderTime, string movieName, string cinemaAddress, int officeID,
            int payTime, int chipInfoID, int IsPay)
        {
            OrderID = orderID;
            OrderSumMoney = orderSumMoney;
            UsersID = usersID;
            OrderTime = orderTime;
            MovieName = movieName;
            CinemaAddress = cinemaAddress;
            OfficeID = officeID;
            PayTime = payTime;
            this.ChipInfoID = chipInfoID;
            this.IsPay = IsPay;
        }

        public OrderInfoModel(DbDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    switch (reader.GetName(i).ToLower())
                    {
                        case "orderid":
                            if (!reader.IsDBNull(i))
                            {
                                OrderID = reader.GetInt32(i);
                            }
                            break;

                        case "ordersummoney":
                            if (!reader.IsDBNull(i))
                            {
                                OrderSumMoney = reader.GetDecimal(i);
                            }
                            break;

                        case "usersid":
                            if (!reader.IsDBNull(i))
                            {
                                UsersID = reader.GetInt32(i);
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

                        case "cinemaaddress":
                            if (!reader.IsDBNull(i))
                            {
                                CinemaAddress = reader.GetString(i);
                            }
                            break;

                        case "officeid":
                            if (!reader.IsDBNull(i))
                            {
                                OfficeID = reader.GetInt32(i);
                            }
                            break;

                        case "payTime":
                            if (!reader.IsDBNull(i))
                            {
                                PayTime = reader.GetInt32(i);
                            }
                            break;

                        case "chipInfoid":
                            if (!reader.IsDBNull(i))
                            {
                                ChipInfoID = reader.GetInt32(i);
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

        public string CinemaAddress
        {
            get
            {
                return cinemaAddress;
            }

            set
            {
                cinemaAddress = value;
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