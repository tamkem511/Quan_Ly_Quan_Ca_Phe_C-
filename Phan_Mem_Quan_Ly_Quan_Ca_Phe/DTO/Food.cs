using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO
{
    public class Food
    {
        private int iD;
        private string nameFood;
        private int idCategory;
        private float price;

        public int ID { get => iD; set => iD = value; }
        public string NameFood { get => nameFood; set => nameFood = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public float Price { get => price; set => price = value; }

        public Food(int id,string namefood,int idcategory,float price)
        {
            ID = id;
            NameFood = namefood;
            IdCategory = idcategory;
            Price = price;
        }

        public Food(DataRow row)
        {
            ID = (int)row["ID"];
            NameFood = (string)row["NameFood"];
            IdCategory = (int)row["IDCategory"];
            Price = Convert.ToInt64(row["Price"]);
        }
    }
}
