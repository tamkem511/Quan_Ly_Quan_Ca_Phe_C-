using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO
{
    public class BillInfor
    {
        private  int iD;
        private  int iDTable;
        private  int iDFood;
        private  int number;
        private string nameFood;

        public  int ID { get => iD; set => iD = value; }
        public  int IDBill { get => iDTable; set => iDTable = value; }
        public  int IDFood { get => iDFood; set => iDFood = value; }
        public int Number { get => number; set => number = value; }
        public string NameFood { get => nameFood; set => nameFood = value; }

        public BillInfor(int id,int idbill,int idfood,int number,string namefood)
        {
            this.ID = id;
            this.IDBill = idbill;
            this.IDFood = idfood;
            this.Number = number;
            this.NameFood = namefood;
        }

        public BillInfor(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.IDFood = (int)row["IDFood"];
            this.IDBill = (int)row["IDBill"];
            this.Number = (int)row["Number"];
            this.NameFood = (string)row["NameFood"];
        }
    }
}
