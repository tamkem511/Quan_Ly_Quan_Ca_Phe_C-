using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO
{
    public class CategoryList
    {
        private int iD;
        private string nameFoodCategory;

        public int ID { get => iD; set => iD = value; }
        public string NameFoodCategory { get => nameFoodCategory; set => nameFoodCategory = value; }

        public CategoryList(int id,string namefoodcategory)
        {
            this.ID = id;
            this.NameFoodCategory = namefoodcategory;
        }

        public CategoryList(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.NameFoodCategory = row["NameFoodCategory"].ToString();
        }
    }
}
