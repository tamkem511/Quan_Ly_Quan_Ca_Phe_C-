using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance {
            get { 
               if(instance == null)
                {
                    instance = new BillInfoDAO();
                } 
               return BillInfoDAO.instance;
            }
            private set => instance = value;
        }

        public BillInfoDAO() { }

        public List<BillInfor> getBillIDInfoFromBill(int id)
        {
            List<BillInfor> listBillInfo =  new List<BillInfor>();
             DataTable data = DataProvider.Instance.ExecuteQuery("select * from BullInfo bu join Food f on f.ID = bu.IDFood where IDBill =" + id);

            foreach (DataRow item in data.Rows)
            {
                BillInfor billinfor = new BillInfor(item);
                listBillInfo.Add(billinfor);
            }
            return listBillInfo;
        }

        public void InsertedBillInfo(int idBill,int idFood,int number)
        {
            DataProvider.Instance.ExecuteQuery("exec InsertBillInfo @IdBill , @IdFood , @Number",new object[] {idBill,idFood,number});
        }

        public void DeleteBillInfo(int IDBill)
        {
            DataProvider.Instance.ExecuteQuery("exec DeleteBillInfo @IDBill",new object[]{IDBill});
        }
    }
}
