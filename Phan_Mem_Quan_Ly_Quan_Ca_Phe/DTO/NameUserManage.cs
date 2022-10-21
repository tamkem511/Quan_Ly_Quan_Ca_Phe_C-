using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO
{
    public class NameUserManage
    {
        private string name;

        public string Name { get => name; set => name = value; }

        public NameUserManage() { }

        public NameUserManage(DataRow row)
        {
            this.Name = row["DisplayName"].ToString();
        }
    }
}
