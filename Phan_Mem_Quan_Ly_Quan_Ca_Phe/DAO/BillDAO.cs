using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance {
            get
            {
                if(instance == null)
                {
                    instance = new BillDAO();
                }
                return BillDAO.instance;
            }
          private set => instance = value;
        }

        public BillDAO() { }

        public int getIdBillFromTable(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Bill Where IDTable = " + id + " and StatusBill = 0");
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }

        public void InsertedBill(int idTable)
        {
            DataProvider.Instance.ExecuteQuery("exec InsertBill @IdTable", new object[] { idTable });
        }

        public void DeleteBill(int IDTable, int discount,float sumprice)
        {
            DataProvider.Instance.ExecuteQuery("exec DeleteBill @IDTable , @DisCount , @SumPrice",new object[] { IDTable ,discount, sumprice });
        }


        public int MaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("Select Max(ID) from Bill");
            }
            catch
            {
                return 1;
            }
        }

        public List<Bill> GetIDTableHaveHuman()
        {
            List<Bill> list = new List<Bill>();

            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Bill where StatusBill = 0");

            foreach(DataRow item in data.Rows)
            {
                Bill value = new Bill(item);
                list.Add(value);
            }
            return list;
        }
    }
}
