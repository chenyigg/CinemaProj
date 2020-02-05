using System.Data.Common;

namespace Model
{
    public class SeatInfoModel
    {
        private int seatID;
        private int officeID;
        private int isSeat;
        private int chipInfoID;

        public SeatInfoModel()
        {
        }

        public SeatInfoModel(int seatID, int officeID, int isSeat, int chipInfoID)
        {
            this.SeatID = seatID;
            this.OfficeID = officeID;
            this.isSeat = isSeat;
            this.ChipInfoID = chipInfoID;
        }

        public SeatInfoModel(DbDataReader reader)
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
                                SeatID = reader.GetInt32(i);
                            }
                            break;

                        case "officeid":
                            if (!reader.IsDBNull(i))
                            {
                                OfficeID = reader.GetInt32(i);
                            }
                            break;

                        case "isseat":
                            if (!reader.IsDBNull(i))
                            {
                                this.IsSeat = reader.GetInt32(i);
                            }
                            break;

                        case "chipinfoid":
                            if (!reader.IsDBNull(i))
                            {
                                this.ChipInfoID = reader.GetInt32(i);
                            }
                            break;
                    }
                }
            }
        }

        public int IsSeat { get => isSeat; set => isSeat = value; }
        public int SeatID { get => seatID; set => seatID = value; }
        public int OfficeID { get => officeID; set => officeID = value; }

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
    }
}