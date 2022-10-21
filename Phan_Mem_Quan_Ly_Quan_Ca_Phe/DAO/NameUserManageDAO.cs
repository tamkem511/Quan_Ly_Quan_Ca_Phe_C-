using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO
{
    public class NameUserManageDAO
    {
        private static NameUserManageDAO instance;

        public static NameUserManageDAO Instance {
            get { 
               if(instance == null)
                {
                    instance = new NameUserManageDAO();
                }
                return NameUserManageDAO.instance;
            }
            set => instance = value; 
        }

        public NameUserManageDAO() { }

        public List<NameUserManage> GetNameUserManage(string nameUser)
        {
            List<NameUserManage> list = new List<NameUserManage>();
            DataTable data = DataProvider.Instance.ExecuteQuery($"Select * from Account where UserName = '{nameUser}'");
            foreach(DataRow item in data.Rows)
            {
                NameUserManage name = new NameUserManage(item);
                list.Add(name);
            }
            return list;
        }
    }
}
