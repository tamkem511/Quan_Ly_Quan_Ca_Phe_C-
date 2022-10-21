using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO
{
    public class TurnOver
    {
        private string nameTable;
        private float sumPrice;
        private DateTime datein;
        private DateTime? dateout;
        private int discount;

        public string NameTable { get => nameTable; set => nameTable = value; }
        public float SumPrice { get => sumPrice; set => sumPrice = value; }
        public DateTime Datein { get => datein; set => datein = value; }
        public DateTime? Dateout { get => dateout; set => dateout = value; }
        public int Discount { get => discount; set => discount = value; }

        public TurnOver(string nametable,float sumprice,DateTime datein,DateTime dateout,int discount)
        {
            this.NameTable = nametable;
            this.SumPrice = SumPrice;
            this.Datein = datein;
            this.Dateout = dateout;
            this.Discount = discount;
        }

        public TurnOver(DataRow row)
        {
            this.NameTable = row["NameTable"].ToString();
            this.SumPrice = Convert.ToInt32(row["SumPrice"]);
            this.Datein = (DateTime)row["DateCheckIn"];
            var examDateCheckOut = row["DateCheckOut"];
            if (examDateCheckOut.ToString() != "")
            {
                this.Dateout = (DateTime?)examDateCheckOut;
            }
            this.Discount = (int)row["Discount"];
        }
    }
}
