using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO.Menu;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe
{
    public partial class fTableManage : Form
    {
        private string UserNameManage;
        private string Password;
        public fTableManage()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
            //LoadNameSwitchTable(cbSwitchTable);
        }

        public fTableManage(string usermanage, string password)
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
            this.UserNameManage = usermanage;
            LoadUserName();
            this.Password = password;
        }

        void LoadUserName()
        {
            List<NameUserManage> value = NameUserManageDAO.Instance.GetNameUserManage(UserNameManage);
            foreach(NameUserManage m in value)
            {
                thôngTinCáNhânToolStripMenuItem.Text = m.Name;
            }
            
        }

        #region Methods
        void LoadNameSwitchTable(ComboBox cb)
        {
            int id = Convert.ToInt32(ShowIDTable.Text.Substring(4, ShowIDTable.Text.Length - 4));
            List<TableList> list = TableDAO.Instance.getInfoTableEmpty(id);
                cb.DataSource = list;
                cb.DisplayMember = "Name";
            
            
        }

        void getInfoTableHaveHuman(ComboBox cb)
        {
         int id = Convert.ToInt32(ShowIDTable.Text.Substring(4, ShowIDTable.Text.Length - 4));
         List<TableList> list = TableDAO.Instance.getInfoTableHaveHuman(id);
        cb.DataSource = list;
        cb.DisplayMember = "Name";

        }
        void LoadCategory()
        {
            List<CategoryList> categoryList = CategoryDAO.Instance.LoadCategory();
            cbCategory.DataSource = categoryList;
            cbCategory.DisplayMember = "NameFoodCategory";
            

        }

        void LoadFoodListFromCategory(int id)
        {
            List<Food> listFood = FoodListDAO.Instance.LoadFood(id);

           
                cbFood.DataSource = listFood;
                cbFood.DisplayMember = "NameFood";
            
        }

        void LoadTable()
        {
            List<TableList> listTable = TableDAO.Instance.LoadTableList();
            List<Bill> listBill = BillDAO.Instance.GetIDTableHaveHuman();

            foreach(TableList item in listTable)
            {
                Button btn = new Button()
                {
                    Width = TableDAO.TableWidth,
                    Height = TableDAO.TableHeight,
                };
                btn.Click += Btn_Click;

                foreach (Bill items in listBill)
                {
                    if((item.ID) == items.IdTable)
                    {
                        item.Status = "Có Người";
                        TableDAO.Instance.UpdateStatusTable(items.IdTable);
                    }
                }

                btn.Text = item.Name + Environment.NewLine + item.Status;
                if(item.Status == "Trống")
                {
                    btn.BackColor = Color.Aqua;
                }if(item.Status == "Có Người")
                {
                    btn.BackColor = Color.Crimson;
                }
                flpTable.Controls.Add(btn);
            }


        }


        void ShowBill(int id)
        {
            
            List<Menu> listMenu = MenuDAO.Instance.getValue(BillDAO.Instance.getIdBillFromTable(id));
            
            lvBill.Items.Clear();
            double tong = 0;
            foreach (Menu item in listMenu)
            {

                ListView lv = new ListView();
                ListViewItem lvItem = new ListViewItem(item.NameFood.ToString());

                double Sum = item.Number * item.Price;
                tong += Sum;
                lvItem.SubItems.Add(item.Number.ToString());
                lvItem.SubItems.Add(item.Price.ToString());
                lvItem.SubItems.Add(Sum.ToString());

                

                lvBill.Items.Add(lvItem);
            }

            txbSumPrice.Text = tong.ToString();
        }

        float Price(int id)
        {
            List<Menu> listMenu = MenuDAO.Instance.getValue(BillDAO.Instance.getIdBillFromTable(id));
            float tong = default;
            foreach (Menu item in listMenu)
            {
                float Sum = item.Number * item.Price;
                tong += Sum;
            }

            return tong;
        }

        

        #endregion

        #region Events


        private void Btn_Click(object sender, EventArgs e)
        {
            
            Button btn = sender as Button;
            ShowIDTable.Text = "Bàn " + (btn.TabIndex+1).ToString();
            ShowBill(btn.TabIndex + 1);
            setStatus.Text = "Set Bàn " + (btn.TabIndex + 1);
    }


        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<NameUserManage> value = NameUserManageDAO.Instance.GetNameUserManage(UserNameManage);
            foreach (NameUserManage m in value)
            {
                fAccountProfile f = new fAccountProfile(UserNameManage, m.Name,Password);
                f.UpdateDisplayName += F_UpdateDisplayName;
              
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            
        }

        private void F_UpdateDisplayName(object sender, AccountEvent e)
        {
            thôngTinCáNhânToolStripMenuItem.Text = e.Acc.DisplayName;
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fADM f = new fADM(UserNameManage);
            f.UpdateAfterDeleteFood += F_UpdateAfterDeleteFood;
            f.UpdateCategoryFromFManage += F_UpdateCategoryFromFManage;
            f.UpdateCategoryFromFManageAfterDelete += F_UpdateCategoryFromFManageAfterDelete;
            f.UpdateNameCategoryAfterUpdate += F_UpdateNameCategoryAfterUpdate;
            f.UpdateListTableFromManage += F_UpdateListTableFromManage;
            f.UpdateListTableFromManageAfterDelete += F_UpdateListTableFromManageAfterDelete;
            f.CloseFormManage += F_CloseFormManage;
          this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void F_CloseFormManage(object sender, CloseFromManageEvent e)
        {
            this.Close();
        }

        private void F_UpdateListTableFromManageAfterDelete(object sender, UpdateListTableFromManageAfterEvent e)
        {
            flpTable.Controls.Clear();
            LoadTable();
            MessageBox.Show("Đã Xóa " + e.Name);
        }

        private void F_UpdateListTableFromManage(object sender, UpdateListTableFromManageEvent e)
        {
            flpTable.Controls.Clear();
            LoadTable();
            MessageBox.Show("Đã Thêm Mới " + e.Name);
        }

        private void F_UpdateNameCategoryAfterUpdate(object sender, updateCategoryEvent e)
        {
            LoadCategory();
        }

        private void F_UpdateCategoryFromFManageAfterDelete(object sender, UpdateCategorAfterDeleteEvent e)
        {
            LoadCategory();
            bool exam = Regex.IsMatch(ShowIDTable.Text.Substring(4, ShowIDTable.Text.Length - 4), "[$1-9]");

            if (exam)
            {
                int idTable = Convert.ToInt32(ShowIDTable.Text.Substring(4, ShowIDTable.Text.Length - 4));
                ShowBill(idTable);
            }
        }

        private void F_UpdateCategoryFromFManage(object sender, UpdateCategoryEvent e)
        {
            LoadCategory();
        }

        private void F_UpdateAfterDeleteFood(object sender, DeleteFoodEvent e)
        {
            LoadCategory();
            LoadFoodListFromCategory(1);
            
            if (ShowIDTable.Text.Length <= 2)
            {
                int idTable = Convert.ToInt32(ShowIDTable.Text.Substring(4, ShowIDTable.Text.Length - 4));
                ShowBill(idTable);
            }

            
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;

            CategoryList select = cb.SelectedItem as CategoryList;
            id = select.ID;
            LoadFoodListFromCategory(id);
        }

        private void AddFood_Click(object sender, EventArgs e)
        {
            flpTable.Controls.Clear();
            
            int idTable = Convert.ToInt32(ShowIDTable.Text.Substring(4, ShowIDTable.Text.Length - 4));
            int idBill = BillDAO.Instance.getIdBillFromTable(idTable);
            int foodID = (cbFood.SelectedItem as Food).ID;
            int count = (int)nmrCount.Value;
            if (idBill == -1)
            {
                BillDAO.Instance.InsertedBill(idTable);
                BillInfoDAO.Instance.InsertedBillInfo(BillDAO.Instance.MaxIDBill(), foodID, count);
                ShowBill(idTable);
                LoadTable();
            }
            else
            {
                BillInfoDAO.Instance.InsertedBillInfo(idBill, foodID, count);
                ShowBill(idTable);
                LoadTable();
            }
        }



        private void btnCheckOut_Click(object sender, EventArgs e)
        {



            if (lvBill.Items.Count > 0)
            {
                flpTable.Controls.Clear();
                int idTable = Convert.ToInt32(ShowIDTable.Text.Substring(4, ShowIDTable.Text.Length - 4));
                int idBill = BillDAO.Instance.getIdBillFromTable(idTable);
                int disCount = (int)nmDisCount.Value;
                float totlePrice = Convert.ToInt64(txbSumPrice.Text);
                float SumPrice = totlePrice - (totlePrice / 100 * disCount);
                BillInfoDAO.Instance.DeleteBillInfo(idBill);
                BillDAO.Instance.DeleteBill(idTable, disCount, SumPrice);
                CultureInfo culture = new CultureInfo("vi-VN");
                notify.ShowBalloonTip(5000, "Thông Báo", $"Thanh Toán Thành Công Số Tiền Là {SumPrice.ToString("c", culture)}đ \n  Cảm Ơn Quý Khách", ToolTipIcon.Info);
                LoadTable();
                ShowBill(idTable);
            }
            else
            {
                notify.ShowBalloonTip(5000, "Thông Báo", "Bàn Trống Không Thể Thanh Toán", ToolTipIcon.Info);
            }
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            if(cbbChangOrAdd.Text == "Chuyển Bàn")
            {
                flpTable.Controls.Clear();
                int idTable1 = Convert.ToInt32(ShowIDTable.Text.Substring(4, ShowIDTable.Text .Length- 4));
                int idTable2 = Convert.ToInt32(cbSwitchTable.Text.Substring(4, cbSwitchTable.Text.Length - 4));
                TableDAO.Instance.SwitchTable(idTable1, idTable2);
                LoadTable();
            }if(cbbChangOrAdd.Text == "Gộp Bàn")
            {
                flpTable.Controls.Clear();
                int idTable1 = Convert.ToInt32(ShowIDTable.Text.Substring(4, ShowIDTable.Text.Length - 4));
                int idTable2 = Convert.ToInt32(cbSwitchTable.Text.Substring(4, cbSwitchTable.Text.Length - 4));
                TableDAO.Instance.PoolTable(idTable1, idTable2);
                LoadTable();
            }

        }


        private void cbbChangOrAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbChangOrAdd.SelectedIndex == 0)
            {
                LoadNameSwitchTable(cbSwitchTable);
            }if(cbbChangOrAdd.SelectedIndex == 1)
            {
                getInfoTableHaveHuman(cbSwitchTable);
            }
            
            
        }

        private void nmDisCount_ValueChanged(object sender, EventArgs e)
        {
            fTableManage f = new fTableManage();
            f.UpdatePrice += F_UpdatePrice;
            int idTable = Convert.ToInt32(ShowIDTable.Text.Substring(4, ShowIDTable.Text.Length - 4));
            List<Menu> listMenu = MenuDAO.Instance.getValue(BillDAO.Instance.getIdBillFromTable(idTable));
            float tong = default;
            foreach (Menu item in listMenu)
            {
                float Sum = item.Number * item.Price;
                tong += Sum;
            }


            
            txbSumPrice.Text = (tong - (tong/100 * Convert.ToInt64(nmDisCount.Value))).ToString();
            if (updatePrice != null)
            {
                updatePrice(this, new UpdatePriceEvent(txbSumPrice.Text));
            }
        }

        private void F_UpdatePrice(object sender, UpdatePriceEvent e)
        {
            txbSumPrice.Text = (Convert.ToInt64(txbSumPrice.Text) - (Convert.ToInt64(txbSumPrice.Text) * nmDisCount.Value / 100)).ToString();
        }

        private event EventHandler<UpdatePriceEvent> updatePrice;
        public event EventHandler<UpdatePriceEvent> UpdatePrice
        {
            add
            {
                updatePrice += value;
            }remove
            {
                updatePrice -= value;
            }
        }

        #endregion

        private void setStatus_Click(object sender, EventArgs e)
        {
            bool exam = Regex.IsMatch(ShowIDTable.Text,"[$1-9]");
            if (lvBill.Items.Count > 0)
            {
                MessageBox.Show("Bàn Vẫn Có Người Không Thể Set");
            }
            else
            {
                if (exam) {
                    flpTable.Controls.Clear();
                    int idTable = Convert.ToInt32(ShowIDTable.Text.Substring(4, ShowIDTable.Text.Length - 4));
                    int idBill = Convert.ToInt32(BillDAO.Instance.getIdBillFromTable(idTable));
                    TableDAO.Instance.UpdateStatusTableEmpty(idTable, idBill);

                    notifyIconSetStatus.ShowBalloonTip(5000, "Thông Báo", "Set Trạng Thái Thành Công", ToolTipIcon.Info);
                    LoadTable();
                }
                else
                {
                    MessageBox.Show("Chọn Bàn Để Thực Hiện Set");
                }
                
            }
        }
    }
    public class UpdatePriceEvent
    {
        private string price;

        public string Price { get => price; set => price = value; }

        public UpdatePriceEvent(string price)
        {
            this.Price = price;
        }
    }
}
