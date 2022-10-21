using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance { 
            get
            {
                if(instance == null)
                {
                    instance = new MenuDAO();
                }
                return MenuDAO.instance;
            }
            private set => instance = value;
        }

        public MenuDAO() { }

        public List<Menu> getValue(int id)
        {
            List<Menu> list = new List<Menu>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Bill bi join BullInfo bif on bi.ID = bif.IDBill join Food f on f.ID = bif.IDFood where IDBill = " + id + "and StatusBill = 0");

            foreach(DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                list.Add(menu);
            }
            return list;
        }
    }
}
