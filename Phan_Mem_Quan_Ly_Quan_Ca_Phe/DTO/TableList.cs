using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO
{
    public class TableList
    {
        private int iD;
        private string name;
        private string status;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }


        public TableList(int id,string name,string status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }

        public TableList(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Name = row["NameTable"].ToString();
            this.Status = row["StatusTable"].ToString();
        }
    }
}
