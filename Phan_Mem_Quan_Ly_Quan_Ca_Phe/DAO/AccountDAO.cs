using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO
{

    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance {
            get {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return AccountDAO.instance;
            }
            private set => instance = value;
        }

        public AccountDAO() { }

        public List<Account> LoadAcc()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Account");
            List<Account> listAcc = new List<Account>();
            foreach(DataRow row in data.Rows)
            {
                Account acc = new Account(row);
                listAcc.Add(acc);
            }
            return listAcc;
        }

        public bool Login(string username, string password)
        {
            string query = $"exec USP_GetAccByUsernameAndPassword @Username = N'{username}',@Password = N'{password}'";


            int result = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));

            return result > 0;
            
        }

        public Account getAccountByUserName(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"exec USP_GetAccByUsername @Username ",new object[] {username});
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public List<Account> getAcc(string userName)
        {
            List<Account> listAcc = new List<Account>();
            DataTable data = DataProvider.Instance.ExecuteQuery($"select * from Account where UserName = N'{userName}'");
            foreach (DataRow item in data.Rows)
            {
                Account acc = new Account(item);
                listAcc.Add(acc);
            }
            return listAcc;
        }

        public void DeleteAcc(string username)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_DeleteAcc @username", new object[] { username });
        }

        public void UpdateAccountManage(string username,string displayname,string newpassword)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_UpdateAccount @userName , @displayName , @newPassword", new object[] { username, displayname, newpassword });
        }

        public void AddAccUser(string userName, string displayName,string password,int type)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_addNewAcc @userName , @displayName , @password , @typeAcc",new object[] { userName, displayName, password, type });    
        }

        public void updateAccUser(string userName, string password, string displayName, int type)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_UpdateAcc @userName , @password , @displayName , @type", new object[] { userName.Trim(), password.Trim(), displayName.Trim(), type });
        }

        public List<Account> SearchAccList(string name)
        {
            List<Account> list = new List<Account>();
            DataTable data = DataProvider.Instance.ExecuteQuery($"Select * from Account where dbo.fuChuyenCoDauThanhKhongDau(DisplayName) like '%' + dbo.fuChuyenCoDauThanhKhongDau(N'{name}') + '%'");
            foreach (DataRow item in data.Rows)
            {
                Account listACc = new Account(item);
                list.Add(listACc);
            }
            return list;
        }


    }
}
