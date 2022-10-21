using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO
{
    public class FoodListDAO
    {
        private static FoodListDAO instance;

        public static FoodListDAO Instance {
            get
            {
                if(instance == null)
                {
                    instance = new FoodListDAO();
                }
                return FoodListDAO.instance;
            }
            private set => instance = value; 
        }

        FoodListDAO() { }

        public List<Food> LoadFood(int id)
        {
            List<Food> list = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Food where IDCategory = " + id);
            foreach(DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

        public List<Food> LoadFood()
        {
            List<Food> list = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Food");
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

        public List<Food> ShowFood()
        {
            List<Food> list = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Food");
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

        public void AddFood(string NameFood,int IDCategory,float Price)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_AddFood @nameFood , @iDCategory , @price", new object[] { NameFood, IDCategory, Price });
        }

        public void DeleteFood(int idFood)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_DeleteFood @idFood", new object[] { idFood });
        }

        public void UpdateFood(int idFood,string nameFood,int idCategory,float price)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_UpdateFood @idTable , @nameFood , @idCategory , @price",new object[] {idFood,nameFood, idCategory, price });
        }

        public List<Food> SearchFood(string NameFood)
        {
            List<Food> foodList = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery($"select * from Food where dbo.fuChuyenCoDauThanhKhongDau(NameFood) like '%' + dbo.fuChuyenCoDauThanhKhongDau(N'{NameFood}') + '%'");
            foreach(DataRow item in data.Rows)
            {
                Food food = new Food(item);
                foodList.Add(food);
            }
            return foodList;
        }
    }
}
