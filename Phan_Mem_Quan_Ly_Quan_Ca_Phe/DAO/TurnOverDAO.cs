using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO
{
    public class TurnOverDAO
    {
        private static TurnOverDAO instance;

        public static TurnOverDAO Instance {
            get { 
              if(instance == null)
                {
                    instance = new TurnOverDAO();
                }
                return TurnOverDAO.instance;
            } 
            set => instance = value;
        }

        public TurnOverDAO() { }

        public List<TurnOver> ShowTurnOver(DateTime datein,DateTime dateout)
        {
            List<TurnOver> list = new List<TurnOver>();
            DataTable data = DataProvider.Instance.ExecuteQuery("exec USP_ShowTurnover @datein , @dateout", new object[] { datein, dateout });
            foreach (DataRow item in data.Rows) {
                TurnOver tov = new TurnOver(item);
                list.Add(tov);
            }

            return list;
        }
    }
}
