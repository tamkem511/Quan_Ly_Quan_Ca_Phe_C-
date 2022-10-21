using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO
{
    public class Bill
    {
        private int iD;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int idTable;
        private int statusBill;
        private int disCount; 

        public int ID { get => iD; set => iD = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int IdTable { get => idTable; set => idTable = value; }
        public int StatusBill { get => statusBill; set => statusBill = value; }
        public int DisCount { get => disCount; set => disCount = value; }

        public Bill(int id, DateTime? datecheckin, DateTime? datecheckout, int idtable, int statusbill,int discount = 0)
        {
            this.iD = id;
            this.DateCheckIn = datecheckin;
            this.DateCheckOut = datecheckout;
            this.IdTable = idtable;
            this.StatusBill = statusbill;
            this.DisCount = discount;
        }

        public Bill(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];
            var examDateCheckOut = row["DateCheckOut"];
            if(examDateCheckOut.ToString() != "")
            {
                this.DateCheckIn = (DateTime?)examDateCheckOut;
            }
            this.IdTable = (int)row["IDTable"];
            this.StatusBill = (int)row["StatusBill"];
            if(row["DisCount"].ToString() != "")
                this.DisCount = (int)row["DisCount"];
            
        }
    }
}
