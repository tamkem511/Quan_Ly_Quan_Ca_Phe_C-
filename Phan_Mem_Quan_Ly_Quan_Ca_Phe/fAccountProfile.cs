using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO;
using System;
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
    public partial class fAccountProfile : Form
    {
        private string UserName;
        private string DisplayName;
        private string passWord;
        public fAccountProfile()
        {
            InitializeComponent();
        }public fAccountProfile(string nameuser, string displayname, string password)
        {
            InitializeComponent();
            this.UserName = nameuser;
            this.DisplayName = displayname;
            LoadInfoAcc();
            this.passWord = password;
        }

        #region Methods
        void LoadInfoAcc()
        {
            txbUserNameProfile.Text = UserName;
            txbDisplayProfile.Text = DisplayName;
        }
        #endregion

        #region Envents
        bool examStatusOldPassword = true;
        bool examStatusNewPassword = true;
        bool examStatusConfirmPassword = true;
        private void showOldPassword_Click(object sender, EventArgs e)
        {
            if (examStatusOldPassword)
            {
                txbPasswordProfile.UseSystemPasswordChar = false;
                examStatusOldPassword = false;
            }
            else
            {
                txbPasswordProfile.UseSystemPasswordChar = true;
                examStatusOldPassword = true;
            }
            
        }

        private void showNewPassword_Click(object sender, EventArgs e)
        {
            if (examStatusNewPassword)
            {
                txbNewPasswordProfile.UseSystemPasswordChar = false;
                examStatusNewPassword = false;
            }
            else
            {
                txbNewPasswordProfile.UseSystemPasswordChar = true;
                examStatusNewPassword = true;
            }
        }

        private void showConfirmPassword_Click(object sender, EventArgs e)
        {
            if (examStatusConfirmPassword)
            {
                txbConfirmPasswordProfile.UseSystemPasswordChar = false;
                examStatusConfirmPassword = false;
            }
            else
            {
                txbConfirmPasswordProfile.UseSystemPasswordChar = true;
                examStatusConfirmPassword = true;
            }
        }
        #endregion

        private void UpdateProfile_Click(object sender, EventArgs e)
        {
            string UserName = txbUserNameProfile.Text;
            string DisplayName = txbDisplayProfile.Text;
            string Password = txbPasswordProfile.Text;
            string NewPassword = txbNewPasswordProfile.Text;
            string ConfirmPassword = txbConfirmPasswordProfile.Text;

           if(Password == passWord)
            {
                if(NewPassword == ConfirmPassword)
                {
                    AccountDAO.Instance.UpdateAccountManage(UserName, DisplayName, NewPassword);
                    
                    notifyIconUpdate.ShowBalloonTip(5000, "Thông Báo", "Cập Nhật Tài Khoản Thành Công", ToolTipIcon.Info);
                    if(updateDisplayName != null)
                    {
                        updateDisplayName(this, new AccountEvent(AccountDAO.Instance.getAccountByUserName(txbUserNameProfile.Text)));
                        //this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Xác Nhận Mật Khẩu Không Chính Xác", "Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mật Khẩu Không Chính Xác !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitProfile_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private event EventHandler<AccountEvent> updateDisplayName;
        public event EventHandler<AccountEvent> UpdateDisplayName
        {
            add
            {
                updateDisplayName += value;
            }
            remove
            {
                updateDisplayName -= value;
            }
        }
    }

   public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc { get => acc; set => acc = value; }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
