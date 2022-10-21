using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO
{
    public class DataProvider
    {
        private string connectionStr = @"Data Source=LAPTOP-JSUGHU76;Initial Catalog=ManageCoffee;Integrated Security=True";

        private static DataProvider instance;

        public static DataProvider Instance {
            get { 
              if(instance == null)
                {
                    instance = new DataProvider();
                }
                return DataProvider.instance;
            }
            private set => instance = value;
        }

        public DataProvider() { }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            //kết nối với CSDL
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                // yêu cầu từ user

                connection.Open();

                //câu truy vấn thực thi đẩy xg CSDL
                SqlCommand command = new SqlCommand(query, connection);

                if(parameter != null)
                {
                    string[] ListParameter = query.Split(' ');
                    int i = 0;
                    foreach(string item in ListParameter)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item,parameter[i]);
                            i++;
                        }
                    }
                }
                

                //Trung gian để lấy ra dữ liệu
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Dữ liệu lấy dưới CSDL có dạng dataTable -> đổ dữ liệu vào data
                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            //kết nối với CSDL
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                // yêu cầu từ user

                connection.Open();

                //câu truy vấn thực thi đẩy xg CSDL
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] ListParameter = query.Split(' ');
                    int i = 0;
                    foreach (string item in ListParameter)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }


                //Trung gian để lấy ra dữ liệu
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Dữ liệu lấy dưới CSDL có dạng dataTable -> đổ dữ liệu vào data
                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            //kết nối với CSDL
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                // yêu cầu từ user

                connection.Open();

                //câu truy vấn thực thi đẩy xg CSDL
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] ListParameter = query.Split(' ');
                    int i = 0;
                    foreach (string item in ListParameter)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }


                //Trung gian để lấy ra dữ liệu
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Dữ liệu lấy dưới CSDL có dạng dataTable -> đổ dữ liệu vào data
                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
    }
}
