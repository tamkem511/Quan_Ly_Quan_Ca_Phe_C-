using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance {
            get
                {
                    if(instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                return CategoryDAO.instance;
                }
            private set => instance = value;
        }

        public CategoryDAO() { }

        public List<CategoryList> LoadCategory()
        {
            List<CategoryList> list = new List<CategoryList>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from FoodCategory");

             foreach(DataRow item in data.Rows)
            {
                CategoryList ct = new CategoryList(item);
                list.Add(ct);
            }

            return list;
        }

        public CategoryList GetIDCategoryFromName(string nameCategory)

        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"Select * From FoodCategory where NameFoodCategory = N'{nameCategory}'");

            foreach (DataRow item in data.Rows)
            {
                return new CategoryList(item);
            }

            return null;
        }

        public CategoryList GetNameCategoryFromID(int id)

        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"Select * From FoodCategory where ID = {id}");

            foreach (DataRow item in data.Rows)
            {
                return new CategoryList(item);
            }

            return null;
        }

        public void InsertCategory(string nameCategory)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_InsertCategory @nameCategory",new object[] {nameCategory});
        }

        public void DeleteCategory(int id)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_DeleteCategory @idCategory",new object[] {id});
        }

        public void updateCategory(string newName,int id)
        {
            DataProvider.Instance.ExecuteQuery("exec UpdateCategory @NewNameCategory , @id", new object[] { newName, id });
        }

        public List<CategoryList> SearchCategoryFood(string NameCategory)
        {
            List<CategoryList> CategoryList = new List<CategoryList>();
            DataTable data = DataProvider.Instance.ExecuteQuery($"select * from FoodCategory where dbo.fuChuyenCoDauThanhKhongDau(NameFoodCategory) like '%' + dbo.fuChuyenCoDauThanhKhongDau(N'{NameCategory}') + '%'");
            foreach (DataRow item in data.Rows)
            {
                CategoryList category = new CategoryList(item);
                CategoryList.Add(category);
            }
            return CategoryList;
        }

    }
}
