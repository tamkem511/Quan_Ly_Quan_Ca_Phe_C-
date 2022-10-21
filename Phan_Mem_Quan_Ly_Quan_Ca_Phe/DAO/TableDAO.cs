using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;


        public static int TableWidth = 100;
        public static int TableHeight = 100;

        public static TableDAO Instance {
            get
            {
                if(instance == null)
                {
                    instance = new TableDAO();
                }
                return  TableDAO.instance;
            } 
            private set => instance = value;
        }

        public TableDAO() { }

        public List<TableList> LoadTableList()
        {
            List<TableList> list = new List<TableList>();

            DataTable data = DataProvider.Instance.ExecuteQuery("exec USP_GetTableList");

            foreach(DataRow item in data.Rows)
            {
                TableList table = new TableList(item);
                list.Add(table);
            }

            return list;
        }

        public void UpdateStatusTable(int idTable)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_UpdateStatusTable @idTable",new object[] { idTable });
        }

        public void UpdateStatusTableEmpty(int idTable,int idBill)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_UpdateStatusTableEmply @idTable , @idBill", new object[] { idTable, idBill });
        }


        public void SwitchTable(int idtable1,int idtable2)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_SwitchTable @idTable1 , @idTable2", new object[] { idtable1, idtable2 });
        }

        public void PoolTable(int idTable1,int idTable2)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_PoolTable @idTable1 , @idTable2", new object[] { idTable1, idTable2 });
        }

        public List<TableList> getInfoTableEmpty(int id)
        {
            List<TableList> list = new List<TableList>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from TableFood where StatusTable = N'Trống'  and ID != " + id);

            foreach (DataRow item in data.Rows)
            {
                TableList table = new TableList(item);
                list.Add(table);
            }

            return list;
            
        }

        public List<TableList> getInfoTableHaveHuman(int id)
        {
            List<TableList> list = new List<TableList>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from TableFood where StatusTable = N'Có Người' and ID != " + id);

            foreach (DataRow item in data.Rows)
            {
                TableList table = new TableList(item);
                list.Add(table);
            }

            return list;

        }

        public void AddTable(string newName)
        {
            DataProvider.Instance.ExecuteQuery("exec addNewTable @newName",new object[] {newName});
        }

        public void Deletetable(int idBill, int idTable)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_deleteTable @idBill , @idTable", new object[] { idBill, idTable });
        }

        public int MaxID()
        {
            DataTable IDMax = DataProvider.Instance.ExecuteQuery("Select * from TableFood where ID = (select Max(ID) from TableFood)");

            TableList table = new TableList(IDMax.Rows[0]);

            return table.ID;
          
        }

        public List<TableList> SearchTableList(string name)
        {
            List<TableList> list = new List<TableList>();
            DataTable data = DataProvider.Instance.ExecuteQuery($"Select NameTable from TableFood where dbo.fuChuyenCoDauThanhKhongDau(NameTable) like '%' + dbo.fuChuyenCoDauThanhKhongDau(N'{name}') + '%'");
            foreach(DataRow item in data.Rows)
            {
                TableList listTable = new TableList(item);
                list.Add(listTable);
            }
            return list;
        }
    }
}
