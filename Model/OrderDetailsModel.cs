using System;
using System.Data.Common;

namespace Model
{
    public class OrderDetailsModel
    {
        private int orderID;
        private int seatID;
        private double orderDetailsPrice;
        private DateTime startTime;
        private DateTime stopTime;

        public OrderDetailsModel()
        {
        }

        public OrderDetailsModel(int orderID, int seatID, double orderDetailsPrice, DateTime startTime, DateTime stopTime)
        {
            OrderID = orderID;
            SeatID = seatID;
            OrderDetailsPrice = orderDetailsPrice;
            StartTime = startTime;
            StopTime = stopTime;
        }

        public OrderDetailsModel(DbDataReader reader)
        {
            //如果当前Reader对象还有数据且未被关闭
            if (reader != null && !reader.IsClosed)
            {
                //通过for循环遍历reader对象
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    //遍历
                    //获取当前列名,并且转换为小写
                    switch (reader.GetName(i).ToString().ToLower())
                    {
                        case "orderid":
                            //判断是否为null
                            if (!reader.IsDBNull(i))
                            {
                                OrderID = reader.GetInt32(i);
                            }
                            break;

                        case "seatid":
                            //判断是否为null
                            if (!reader.IsDBNull(i))
                            {
                                SeatID = reader.GetInt32(i);
                            }
                            break;

                        case "orderdetailsprice":
                            //判断是否为null
                            if (!reader.IsDBNull(i))
                            {
                                orderDetailsPrice = reader.GetDouble(i);
                            }
                            break;

                        case "starttime":
                            //判断是否为null
                            if (!reader.IsDBNull(i))
                            {
                                StartTime = reader.GetDateTime(i);
                            }
                            break;

                        case "stoptime":
                            //判断是否为null
                            if (!reader.IsDBNull(i))
                            {
                                StopTime = reader.GetDateTime(i);
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

        public int SeatID
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

        public double OrderDetailsPrice
        {
            get
            {
                return orderDetailsPrice;
            }

            set
            {
                orderDetailsPrice = value;
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