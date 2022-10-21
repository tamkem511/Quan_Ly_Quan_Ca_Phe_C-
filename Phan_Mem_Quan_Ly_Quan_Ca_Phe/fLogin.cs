using System;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe
{
    public partial class fLogin : Form
    {
       
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login(txbUsername.Text, txbPassword.Text))
            {
                
                fTableManage f = new fTableManage(txbUsername.Text,txbPassword.Text);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài Khoản Hoặc Mật Khẩu Không Chính Xác !", "Thông Báo", MessageBoxButtons.YesNo);
            }

        }

        bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }

        private void btnExitLogin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Thoát Chương Trình ?", "Thông Báo", MessageBoxButtons.OKCancel); 
            if (result == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
               
            }
        }

    }
}
