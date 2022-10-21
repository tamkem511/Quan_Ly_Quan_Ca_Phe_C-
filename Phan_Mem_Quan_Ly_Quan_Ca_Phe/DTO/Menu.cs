using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO
{
    public class Menu
    {
        private int iD;
        private string nameFood;
        private float price;
        private int iDBill;
        private int number;
        private int iDTable;

        public int ID { get => iD; set => iD = value; }
        public string NameFood { get => nameFood; set => nameFood = value; }
        public float Price { get => price; set => price = value; }
        public int IDBill { get => iDBill; set => iDBill = value; }
        public int Number { get => number; set => number = value; }
        public int IDTable { get => iDTable; set => iDTable = value; }

        public Menu(int id,string namefood,float price,int idbill,int number,int idtable)
        {
            this.ID = id;
            this.NameFood = namefood;
            this.Price = price;
            this.IDBill = idbill;
            this.Number = number;
            this.IDTable = idtable;
        }

        public Menu(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.NameFood = row["NameFood"].ToString();
            this.Price = Convert.ToInt64(row["Price"]);
            this.IDBill = (int)row["IDBill"];
            this.Number = (int)row["Number"];
            this.IDTable = (int)row["IDTable"];
        }
    }
}
