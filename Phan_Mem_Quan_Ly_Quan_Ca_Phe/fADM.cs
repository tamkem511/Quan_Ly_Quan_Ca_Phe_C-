using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DAO;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe
{
    public partial class fADM : Form
    {
        string UserNameManage;
        BindingSource bindinglist = new BindingSource();
        public fADM()
        {
            InitializeComponent();
            dtgvFood.DataSource = bindinglist;
            LoadDataAcc();
            GetResult();
            See();
            LoadCategoryToFood();
            LoadInfoCategory();
            LoadTable();
        }

        public fADM(string userName)
        {
            InitializeComponent();
            dtgvFood.DataSource = bindinglist;
            LoadDataAcc();
            GetResult();
            See();
            LoadCategoryToFood();
            LoadInfoCategory();
            LoadTable();
            this.UserNameManage = userName;
        }

        #region Methods


        void LoadCategoryToFood()
        {
            List<CategoryList> list = CategoryDAO.Instance.LoadCategory();

            cbbCategory.DataSource = list;
            cbbCategory.DisplayMember = "NameFoodCategory";
        }

        void LoadInfoCategory()
        {
            List<CategoryList> list = CategoryDAO.Instance.LoadCategory();

            dtgvCategory.DataSource = list;
        }
        void LoadDataAcc()
        {
            string query = "select * from Account";

            //Cach truyền nhiều parameter bằng new Object
            dtgvAcc.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void GetResult()
        {
            string query = "select count(*) from Account";



            txbSearchAcc.Text = DataProvider.Instance.ExecuteScalar(query).ToString();
        }

        //Hàm Để Hiểu luồng xử lý 
        void test()
        {
            //kết nối với CSDL
            string connectionStr = @"Data Source=LAPTOP-JSUGHU76;Initial Catalog=ManageCoffee;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionStr);

            // yêu cầu từ user
            string query = "select * from Account Where TypeAcc = 0";
            connection.Open();

            //câu truy vấn thực thi đẩy xg CSDL
            SqlCommand command = new SqlCommand(query, connection);

            DataTable data = new DataTable();

            //Trung gian để lấy ra dữ liệu
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            //Dữ liệu lấy dưới CSDL có dạng dataTable -> đổ dữ liệu vào data
            adapter.Fill(data);

            connection.Close();

            dtgvAcc.DataSource = data;
        }
        void See()
        {
            List<Food> listFood = FoodListDAO.Instance.ShowFood();

            bindinglist.DataSource = listFood;
        }

        void AddNewCategory(string nameCategory)
        {
            CategoryDAO.Instance.InsertCategory(nameCategory);
        }

        void DeleteCategoryFood(int id)
        {
            CategoryDAO.Instance.DeleteCategory(id);
        }

        void LoadTable()
        {
            List<TableList> tableList = TableDAO.Instance.LoadTableList();

            dtgvTable.DataSource = tableList;
        }
        #endregion

        #region Event

        private void ShowBill_Click(object sender, EventArgs e)
        {
            
            DateTime datein = dtpkFromDateIn.Value;
            DateTime dateout = dtpkToDateOut.Value;
            List<TurnOver> tov = TurnOverDAO.Instance.ShowTurnOver(datein, dateout);
            Turnover.DataSource = tov;
        }


        bool StatusSee = true;
        private void btnSeeFood_Click(object sender, EventArgs e)
        {
            if (StatusSee)
            {
                txbNameShow.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "NameFood",true,DataSourceUpdateMode.Never));
                txbPriceShow.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
                btnSeeFood.Text = "Tắt Xem";
                StatusSee = false;
            }
            else
            {
                txbNameShow.DataBindings.Clear();
                txbPriceShow.DataBindings.Clear();
                txbNameShow.Text = "";
                cbbCategory.Text = "";
                txbPriceShow.Text = "";
                btnSeeFood.Text = "Xem";
                StatusSee = true;
            }
            // List<Food> listFood = FoodListDAO.Instance.ShowFood();

            //  dtgvFood.DataSource = listFood;

        }



        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string NameFood = txbNameShow.Text;
            string NameCategory = cbbCategory.Text;


            if (txbNameShow.Text == "" || txbPriceShow.Text == "")
            {
                MessageBox.Show("Yêu Cầu Thêm Tên Và Giá Món Ăn !");
            }
            else
            {
                float Price = Convert.ToInt64(txbPriceShow.Text);
                int IDCategory = CategoryDAO.Instance.GetIDCategoryFromName(NameCategory).ID;
                int count = 0;
                List<Food> food = FoodListDAO.Instance.LoadFood();
                foreach(Food item in food)
                {
                    if(NameFood == item.NameFood)
                    {
                        count++;
                    }
                }
                if(count > 0)
                {
                    MessageBox.Show("Món ăn đã tòn tại");
                }
                else
                {
                    FoodListDAO.Instance.AddFood(NameFood, IDCategory, Price);
                    notifyIconAddCategory.ShowBalloonTip(5000, "Thông Báo", "Thêm Food Thành Công", ToolTipIcon.Info);
                    See();
                }

            }

        }


        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (dtgvFood.SelectedCells.Count > 0)
            {
                int id = Convert.ToInt32(dtgvFood.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
                if (updateAfterDeleteFood != null)
                {
                    updateAfterDeleteFood(this, new DeleteFoodEvent(id));
                }
                int IDCategory = Convert.ToInt32(dtgvFood.SelectedCells[0].OwningRow.Cells["IdCategory"].Value.ToString());
                FoodListDAO.Instance.DeleteFood(id);
          
                See();
                notifyIconDeleteFood.ShowBalloonTip(5000, "Thông Báo", "Đã Xóa Thành Công", ToolTipIcon.Info);
            }
            else
            {
                MessageBox.Show("Dữ Liệu Trống !");
            }


        }

        private event EventHandler<DeleteFoodEvent> updateAfterDeleteFood;
        public event EventHandler<DeleteFoodEvent> UpdateAfterDeleteFood
        {
            add
            {
                updateAfterDeleteFood += value;
            }
            remove
            {
                updateAfterDeleteFood -= value;
            }
        }




        private void btnEditFood_Click(object sender, EventArgs e)
        {
            int idFood = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["ID"].Value;
            string NameFood = txbNameShow.Text;
            string NameCategory = cbbCategory.Text;
            int IDCategory = Convert.ToInt32(CategoryDAO.Instance.GetIDCategoryFromName(NameCategory).ID);
            float Price = Convert.ToInt64(txbPriceShow.Text);

            if(dtgvFood.SelectedCells.Count > 0)
            {
                FoodListDAO.Instance.UpdateFood(idFood, NameFood, IDCategory, Price);
                notifyIconUpdate.ShowBalloonTip(5000, "Thông Báo", "Cập Nhật Thành Công", ToolTipIcon.Info);
                See();
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Dữ Liệu Trong Bảng Để Sửa");
            }
        }


        private void txbNameShow_TextChanged(object sender, EventArgs e)
        {
            if (dtgvFood.SelectedCells.Count > 0)
            {
                int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["IDCategory"].Value;
                CategoryList data = CategoryDAO.Instance.GetNameCategoryFromID(id);

                int index = -1;
                int i = 0;
                foreach (CategoryList item in cbbCategory.Items)
                {
                    if (item.ID == data.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbbCategory.SelectedIndex = index;
            }
        }

        private void SearchFood_Click(object sender, EventArgs e)
        {
            string nameFood = txbValueSearchFood.Text;
            List<Food> infoFood = FoodListDAO.Instance.SearchFood(nameFood);
            
            List<Food> listFood = FoodListDAO.Instance.LoadFood();
            int count = 0;
            foreach (Food food in listFood)
            {
                foreach (Food item in infoFood)
                {
                    if(item.NameFood == food.NameFood)
                    {
                        count++;
                    }
                }   
            }
            if (count > 0)
            {
                txbNameShow.DataBindings.Clear();
                txbPriceShow.DataBindings.Clear();
                txbNameShow.Text = "";
                cbbCategory.Text = "";
                txbPriceShow.Text = "";
                btnSeeFood.Text = "Xem";
                StatusSee = true;

                    dtgvFood.DataSource = infoFood;
                
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Món Ăn");
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            txbNameShow.DataBindings.Clear();
            txbPriceShow.DataBindings.Clear();
            txbNameShow.Text = "";
            cbbCategory.Text = "";
            txbPriceShow.Text = "";
            btnSeeFood.Text = "Xem";
            StatusSee = true;
            List<Food> food = FoodListDAO.Instance.ShowFood();

            dtgvFood.DataSource = food;
        }

        //Phần Danh Mục
        private void AddCategory_Click(object sender, EventArgs e)
        {
            string nameCategory = txbShowNameCategory.Text;

            List<CategoryList> categoryLists = CategoryDAO.Instance.LoadCategory();
            int count = 0;
            foreach(CategoryList item in categoryLists)
            {
                if(nameCategory.ToLower() == item.NameFoodCategory.ToLower())
                {
                    count++;
                }
            }
            if(count > 0)
            {
                MessageBox.Show("Tên Danh Mục Đã Tồn Tại");
            }
            else
            {

                AddNewCategory(nameCategory);
                See();
                LoadCategoryToFood();

                if(updateCategoryFromFManage != null)
                {
                    updateCategoryFromFManage(this,new UpdateCategoryEvent(txbShowNameCategory.Text));
                }


                notifyIconInsertCategory.ShowBalloonTip(5000, "Thông Báo", "Thêm Mới Danh Mục Thành Công", ToolTipIcon.Info);

                LoadInfoCategory();
            }

        }

        private event EventHandler<UpdateCategoryEvent> updateCategoryFromFManage;
        public event EventHandler<UpdateCategoryEvent> UpdateCategoryFromFManage
        {
            add
            {
                updateCategoryFromFManage+=value;
            }
            remove
            {
                updateCategoryFromFManage -= value;
            }
        }


        private void DeleteCategory_Click(object sender, EventArgs e)
        {
            int idCategory = Convert.ToInt32(dtgvCategory.SelectedCells[0].OwningRow.Cells["ID"].Value);

            if (dtgvCategory.SelectedCells.Count > 0)
            {
                DeleteCategoryFood(idCategory);
                notifyIconDeleteCategory.ShowBalloonTip(5000, "Thông Báo", "Xóa Danh Mục Thành Công", ToolTipIcon.Info);
                if (updateCategoryFromFManageAfterDelete != null)
                {
                    updateCategoryFromFManageAfterDelete(this,new UpdateCategorAfterDeleteEvent(idCategory));
                }
                LoadInfoCategory();
                See();
                LoadCategoryToFood();

            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Danh Mục Muốn Xóa !");
            }

        }

        private event EventHandler<UpdateCategorAfterDeleteEvent> updateCategoryFromFManageAfterDelete;
        public event EventHandler<UpdateCategorAfterDeleteEvent> UpdateCategoryFromFManageAfterDelete
        {
            add
            {
                updateCategoryFromFManageAfterDelete += value;
            }
            remove
            {
                updateCategoryFromFManageAfterDelete -= value;
            }
        }


        private void EditCategory_Click(object sender, EventArgs e)
        {
            if(dtgvCategory.SelectedCells.Count > 0)
            {
                int idCategory = Convert.ToInt32(dtgvCategory.SelectedCells[0].OwningRow.Cells["ID"].Value);
                string newName = txbShowNameCategory.Text;
                CategoryDAO.Instance.updateCategory(newName, idCategory);
                LoadInfoCategory();
                LoadCategoryToFood();
                if(updateNameCategoryAfterUpdate != null)
                {
                    updateNameCategoryAfterUpdate(this, new updateCategoryEvent(idCategory));
                }

            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Sản Phẩm Muốn Sửa");
            }

        }

        private event EventHandler<updateCategoryEvent> updateNameCategoryAfterUpdate;
        public event EventHandler<updateCategoryEvent> UpdateNameCategoryAfterUpdate
        {
            add
            {
                updateNameCategoryAfterUpdate += value;
            }
            remove
            {
                updateNameCategoryAfterUpdate -= value;
            }
        }

        bool ExamStatusCategory = true;
        private void ShowCategory_Click(object sender, EventArgs e)
        {
            if (ExamStatusCategory)
            {
                txbShowNameCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "NameFoodCategory", true, DataSourceUpdateMode.Never));
                ShowCategory.Text = "Tắt Xem";
                ExamStatusCategory = false;
            }
            else
            {
                txbShowNameCategory.DataBindings.Clear();
                txbShowNameCategory.Text = "";
                ShowCategory.Text = "Xem";
                ExamStatusCategory = true;
            }
        }


        private void SearchCategoryFood_Click(object sender, EventArgs e)
        {
            string valueSearch = ValueSearchCategory.Text;

            int count = 0;

            List<CategoryList> loadCTGR = CategoryDAO.Instance.LoadCategory();

            List<CategoryList> listCategory = CategoryDAO.Instance.SearchCategoryFood(valueSearch);

            foreach(CategoryList item in loadCTGR)
            {
                foreach(CategoryList value in listCategory)
                {
                    if(value.NameFoodCategory == item.NameFoodCategory)
                    {
                        count++;
                    }
                }
            }
            if(count > 0)
            {
                dtgvCategory.DataBindings.Clear();
                txbShowNameCategory.Text = "";
                btnSeeFood.Text = "Xem";
                ExamStatusCategory = true;
                dtgvCategory.DataSource = listCategory;
                
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Món Ăn");
            }

        }

        private void AddTable_Click(object sender, EventArgs e)
        {
            List<TableList> listTable = TableDAO.Instance.LoadTableList(); ;
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from TableFood");
            int count = 0;
            if (count > 0)
            {
                MessageBox.Show("Tên Bàn Đã Tồn Tại");
            }
            else
            {
                string nameTable = "Bàn " + (TableDAO.Instance.MaxID() + 1).ToString();
                TableDAO.Instance.AddTable(nameTable);
                LoadTable();
                notifyIconAddTable.ShowBalloonTip(5000, "Thông Báo", "Thêm Mới Thành Công",ToolTipIcon.Info);
                if (updateListTableFromManage != null)
                {
                    updateListTableFromManage(this,new UpdateListTableFromManageEvent(nameTable));
                }
            }
        }

        private event EventHandler<UpdateListTableFromManageEvent> updateListTableFromManage;
        public event EventHandler<UpdateListTableFromManageEvent> UpdateListTableFromManage
        {
            add
            {
                updateListTableFromManage += value;
            }
            remove
            {
                updateListTableFromManage -= value;
            }
        }

        private void DeleteTable_Click(object sender, EventArgs e)
        {
            if(dtgvTable.SelectedCells.Count > 0)
            {
   

                if(Convert.ToInt32(dtgvTable.SelectedCells[0].OwningRow.Cells["ID"].Value) == Convert.ToInt32(TableDAO.Instance.MaxID()))
                {
                    int idTable = Convert.ToInt32(dtgvTable.SelectedCells[0].OwningRow.Cells["ID"].Value);
                    int idBill = BillDAO.Instance.getIdBillFromTable(idTable);

                    if (idBill == -1)
                    {
                        DataProvider.Instance.ExecuteQuery($"exec USP_deleteNoBillTable {idTable}");
                        notifyIconDeleteFood.ShowBalloonTip(5000, "Thông Báo", "Xóa Bàn Thành Công", ToolTipIcon.Info);
                    }
                    else
                    {
                        TableDAO.Instance.Deletetable(idBill, idTable);
                        notifyIconDeleteFood.ShowBalloonTip(5000, "Thông Báo", "Xóa Bàn Thành Công", ToolTipIcon.Info);
                    }
                    LoadTable();
                    if (updateListTableFromManageAfterDelete != null)
                    {
                        updateListTableFromManageAfterDelete(this, new UpdateListTableFromManageAfterEvent($"Bàn {idTable}"));
                    }
                }
                else
                {
                    MessageBox.Show("Bàn Chỉ Được Xóa Theo Thứ Tự");
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Bàn Muốn Xóa");
            }
           
        }

        private event EventHandler<UpdateListTableFromManageAfterEvent> updateListTableFromManageAfterDelete;
        public event EventHandler<UpdateListTableFromManageAfterEvent> UpdateListTableFromManageAfterDelete
        {
            add
            {
                updateListTableFromManageAfterDelete += value;
            }
            remove
            {
                updateListTableFromManageAfterDelete -= value;
            }
        }

        #endregion

        private void EditTable_Click(object sender, EventArgs e)
        {

        }

        bool examStatus = true;
        private void searchTableFood_Click(object sender, EventArgs e)
        {
            string name = valueSearch.Text;

            int count = 0;

            List<TableList> loadTable = TableDAO.Instance.LoadTableList();

            List<TableList> ListTable = TableDAO.Instance.SearchTableList(name);

            foreach (TableList item in loadTable)
            {
                foreach (TableList value in ListTable)
                {
                    if (value.Name == item.Name)
                    {
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                dtgvFood.DataBindings.Clear();
                textShowNameTable.Text = "";
                txbStatusTable.Text = "";
                ShowTable.Text = "Xem";
                ExamStatusCategory = true;
                dtgvCategory.DataSource = ListTable;

            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Bàn");
            }

        }

        bool examStatusTable = true;
        private void ShowTable_Click(object sender, EventArgs e)
        {
            if (examStatusTable)
            {
                textShowNameTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
                txbStatusTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
                examStatusTable = false;
                ShowTable.Text = "Tắt Xem";
            }
            else
            {
                textShowNameTable.DataBindings.Clear();
                txbStatusTable.DataBindings.Clear();
                examStatusTable = true;
                ShowTable.Text = "Xem";
                textShowNameTable.Text = "";
                txbStatusTable.Text = "";
            }
           
        }

        private void AddAcc_Click(object sender, EventArgs e)
        {
            string userName = txbUserNameShow.Text;
            string displayName = txbDisplayNameShow.Text;
            string password = txbPasswordShow.Text;
            int typeAcc = Convert.ToInt32(cbbTypeACc.Text);

            if (userName != "" && displayName != "" && password != "" && cbbTypeACc.Text != "")
            {
                List<Account> accounts = AccountDAO.Instance.LoadAcc();
                List<Account> acc = AccountDAO.Instance.getAcc(userName);
                int count = 0;
                foreach(Account account in accounts)
                {
                    foreach(Account accItem in acc)
                    {
                        if(accItem.UserName == account.UserName)
                        {
                            count++;
                        }
                    }
                }
                if(count > 0)
                {
                    MessageBox.Show("Tên Tài Khoản Đã Tồn Tại");
                }
                else
                {
                    AccountDAO.Instance.AddAccUser(userName.Trim(), displayName.Trim(), password.Trim(), typeAcc);
                    notifyIconAddAcc.ShowBalloonTip(5000, "Thông Báo", "Thêm Mới Tài Khoản Thành Công", ToolTipIcon.Info);
                    LoadDataAcc();
                }
            }
            else
            {
                MessageBox.Show("That Bai");
            }
        }

        private void DeleteAcc_Click(object sender, EventArgs e)
        {
            if(dtgvAcc.SelectedCells.Count > 0)
            {
               

                string username = dtgvAcc.SelectedCells[0].OwningRow.Cells["UserName"].Value.ToString();
                if (username == UserNameManage)
                {
                    AccountDAO.Instance.DeleteAcc(username);
                    notifyIconAddAcc.ShowBalloonTip(5000, "Thông Báo", "Xóa Tài Khoản Thành Công", ToolTipIcon.Info);
                    LoadDataAcc();
                    if (closeFormManage != null)
                    {
                        closeFormManage(this, new CloseFromManageEvent(username));
                    }
                    this.Close();
                  
                }
                else
                {
                    AccountDAO.Instance.DeleteAcc(username);
                    notifyIconAddAcc.ShowBalloonTip(5000, "Thông Báo", "Xóa Tài Khoản Thành Công", ToolTipIcon.Info);
                    LoadDataAcc();
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Account Muốn Xóa");
            }
        }

        private event EventHandler<CloseFromManageEvent> closeFormManage;
        public event EventHandler<CloseFromManageEvent> CloseFormManage
        {
            add
            {
                closeFormManage += value;
            }
            remove
            {
                closeFormManage -= value;
            }
        }
        bool examAcc = true;
        private void EditAcc_Click(object sender, EventArgs e)
        {
            if(dtgvAcc.SelectedCells.Count > 0)
            {
                string userNameOld = dtgvAcc.SelectedCells[0].OwningRow.Cells["UserName"].Value.ToString();
                string userName = txbUserNameShow.Text;
                string displayName = txbDisplayNameShow.Text;
                string password = txbPasswordShow.Text;
                int typeAcc = Convert.ToInt32(cbbTypeACc.Text);
                if(userNameOld == userName)
                {
                    if (userName != "" && displayName != "" && password != "")
                    {
                        AccountDAO.Instance.updateAccUser(userName.Trim(), password.Trim(), displayName.Trim(), typeAcc);
                        notifyIconAddAcc.ShowBalloonTip(5000, "Thông Báo", "Cập Nhật Thành Công", ToolTipIcon.Info);
                        LoadDataAcc();
                    }
                    else
                    {
                        MessageBox.Show("Không Được Bỏ Trống Dữ Liệu");
                    }
                }
                else
                {
                    MessageBox.Show("Tên Đăng Nhập Không Được Thay Đổi");
                }
                
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Tài Khoản Sau Đó Ấn Xem Để Cập Nhật");
            }
           
        }

        private void ShowAcc_Click(object sender, EventArgs e)
        {
            if (examAcc)
            {
                txbUserNameShow.DataBindings.Add("Text", dtgvAcc.DataSource, "UserName", true, DataSourceUpdateMode.Never);
                txbDisplayNameShow.DataBindings.Add("Text", dtgvAcc.DataSource, "DisplayName", true, DataSourceUpdateMode.Never);
                txbPasswordShow.DataBindings.Add("Text", dtgvAcc.DataSource, "PassWord", true, DataSourceUpdateMode.Never);
                cbbTypeACc.DataBindings.Add("Text", dtgvAcc.DataSource, "TypeAcc", true, DataSourceUpdateMode.Never);

                ShowAcc.Text = "Tắt Xem";
                examAcc = false;
            }
            else
            {
                txbUserNameShow.DataBindings.Clear();
                txbDisplayNameShow.DataBindings.Clear();
                txbPasswordShow.DataBindings.Clear();
                cbbTypeACc.DataBindings.Clear();
                txbUserNameShow.Text = "";
                txbDisplayNameShow.Text = "";
                txbPasswordShow.Text = "";
                cbbTypeACc.Text = "";
                ShowAcc.Text = "Xem";
                examAcc = true;
            }
        }

        private void SearchAcc_Click(object sender, EventArgs e)
        {
            string displayName = txbSearchAcc.Text;
            List<Account> accounts = AccountDAO.Instance.LoadAcc();
            List<Account> value = AccountDAO.Instance.SearchAccList(displayName);
            int count = 0;
            foreach(Account acc in accounts)
            {
                foreach(Account item in value)
                {
                    if(item.DisplayName == acc.DisplayName)
                    {
                        count++;
                    }
                }
            }
            if(count > 0)
            {
                dtgvAcc.DataSource = value;
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Tài Khoản");
            }
        }
    }

    public class DeleteFoodEvent : EventArgs
    {
        private int idFood;

        public int IdFood { get => idFood; set => idFood = value; }

        public DeleteFoodEvent(int idfood)
        {
            this.IdFood = idfood;
        }
    }

    public class UpdateCategoryEvent : EventArgs
    {
        private string NameCategory;

        public string NameCategory1 { get => NameCategory; set => NameCategory = value; }

        public UpdateCategoryEvent(string namecategory)
        {

            this.NameCategory = namecategory;
        }
    }

    public class UpdateCategorAfterDeleteEvent : EventArgs
    {

        private int id;

        public int Id { get => id; set => id = value; }
        public UpdateCategorAfterDeleteEvent(int id)
        {
            this.Id = id;
        }
    }

    public class updateCategoryEvent : EventArgs
    {
        private int id;

        public int Id { get => id; set => id = value; }

        public updateCategoryEvent(int id)
        {
            this.Id = id;
        }
    }

    public class UpdateListTableFromManageEvent : EventArgs
    {
        private string name;

        public string Name { get => name; set => name = value; }

        public UpdateListTableFromManageEvent(string name)
        {
            this.Name = name;
        }
    }

    public class UpdateListTableFromManageAfterEvent : EventArgs
    {
        private string name;

        public string Name { get => name; set => name = value; }

        public UpdateListTableFromManageAfterEvent(string name)
        {
            this.Name = name;
        }
    }

    public class CloseFromManageEvent : EventArgs
    {
        private string name;

        public string Name { get => name; set => name = value; }

        public CloseFromManageEvent(string name)
        {
            this.Name = name;
        }
        CloseFromManageEvent()
        {
            
        }
    }
}
