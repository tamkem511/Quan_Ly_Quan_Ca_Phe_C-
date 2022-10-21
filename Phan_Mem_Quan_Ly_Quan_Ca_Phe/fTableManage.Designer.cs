namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe
{
    partial class fTableManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTableManage));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.setStatus = new System.Windows.Forms.Button();
            this.txbSumPrice = new System.Windows.Forms.TextBox();
            this.cbbChangOrAdd = new System.Windows.Forms.ComboBox();
            this.cbSwitchTable = new System.Windows.Forms.ComboBox();
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.nmDisCount = new System.Windows.Forms.NumericUpDown();
            this.btnDisCount = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nmrCount = new System.Windows.Forms.NumericUpDown();
            this.AddFood = new System.Windows.Forms.Button();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ShowIDTable = new System.Windows.Forms.Label();
            this.lvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.UserManage = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconSetStatus = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDisCount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCount)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinCáNhânToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1256, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.thôngTinCáNhânToolStripMenuItem1});
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông Tin Cá Nhân";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thôngTinCáNhânToolStripMenuItem1
            // 
            this.thôngTinCáNhânToolStripMenuItem1.Name = "thôngTinCáNhânToolStripMenuItem1";
            this.thôngTinCáNhânToolStripMenuItem1.Size = new System.Drawing.Size(218, 26);
            this.thôngTinCáNhânToolStripMenuItem1.Text = "Thông Tin Cá Nhân";
            this.thôngTinCáNhânToolStripMenuItem1.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.setStatus);
            this.panel3.Controls.Add(this.txbSumPrice);
            this.panel3.Controls.Add(this.cbbChangOrAdd);
            this.panel3.Controls.Add(this.cbSwitchTable);
            this.panel3.Controls.Add(this.btnSwitchTable);
            this.panel3.Controls.Add(this.nmDisCount);
            this.panel3.Controls.Add(this.btnDisCount);
            this.panel3.Controls.Add(this.btnCheckOut);
            this.panel3.Location = new System.Drawing.Point(721, 635);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(523, 86);
            this.panel3.TabIndex = 3;
            // 
            // setStatus
            // 
            this.setStatus.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.setStatus.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.setStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.setStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.setStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setStatus.Location = new System.Drawing.Point(266, 20);
            this.setStatus.Name = "setStatus";
            this.setStatus.Size = new System.Drawing.Size(126, 26);
            this.setStatus.TabIndex = 11;
            this.setStatus.Text = "Set Status";
            this.setStatus.UseVisualStyleBackColor = false;
            this.setStatus.Click += new System.EventHandler(this.setStatus_Click);
            // 
            // txbSumPrice
            // 
            this.txbSumPrice.BackColor = System.Drawing.Color.PeachPuff;
            this.txbSumPrice.Location = new System.Drawing.Point(266, 50);
            this.txbSumPrice.Name = "txbSumPrice";
            this.txbSumPrice.ReadOnly = true;
            this.txbSumPrice.Size = new System.Drawing.Size(126, 22);
            this.txbSumPrice.TabIndex = 9;
            this.txbSumPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbbChangOrAdd
            // 
            this.cbbChangOrAdd.FormattingEnabled = true;
            this.cbbChangOrAdd.Items.AddRange(new object[] {
            "Chuyển Bàn",
            "Gộp Bàn"});
            this.cbbChangOrAdd.Location = new System.Drawing.Point(9, 20);
            this.cbbChangOrAdd.Name = "cbbChangOrAdd";
            this.cbbChangOrAdd.Size = new System.Drawing.Size(107, 24);
            this.cbbChangOrAdd.TabIndex = 10;
            this.cbbChangOrAdd.SelectedIndexChanged += new System.EventHandler(this.cbbChangOrAdd_SelectedIndexChanged);
            // 
            // cbSwitchTable
            // 
            this.cbSwitchTable.FormattingEnabled = true;
            this.cbSwitchTable.Location = new System.Drawing.Point(8, 52);
            this.cbSwitchTable.Name = "cbSwitchTable";
            this.cbSwitchTable.Size = new System.Drawing.Size(166, 24);
            this.cbSwitchTable.TabIndex = 8;
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.Location = new System.Drawing.Point(122, 18);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(52, 28);
            this.btnSwitchTable.TabIndex = 7;
            this.btnSwitchTable.Text = "OK";
            this.btnSwitchTable.UseVisualStyleBackColor = true;
            this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
            // 
            // nmDisCount
            // 
            this.nmDisCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmDisCount.Location = new System.Drawing.Point(202, 52);
            this.nmDisCount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nmDisCount.Name = "nmDisCount";
            this.nmDisCount.ReadOnly = true;
            this.nmDisCount.Size = new System.Drawing.Size(58, 22);
            this.nmDisCount.TabIndex = 6;
            this.nmDisCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmDisCount.ValueChanged += new System.EventHandler(this.nmDisCount_ValueChanged);
            // 
            // btnDisCount
            // 
            this.btnDisCount.Location = new System.Drawing.Point(180, 18);
            this.btnDisCount.Name = "btnDisCount";
            this.btnDisCount.Size = new System.Drawing.Size(80, 28);
            this.btnDisCount.TabIndex = 5;
            this.btnDisCount.Text = "Giảm Giá";
            this.btnDisCount.UseVisualStyleBackColor = true;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(398, 18);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(104, 54);
            this.btnCheckOut.TabIndex = 4;
            this.btnCheckOut.Text = "Thanh Toán";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nmrCount);
            this.panel4.Controls.Add(this.AddFood);
            this.panel4.Controls.Add(this.cbFood);
            this.panel4.Controls.Add(this.cbCategory);
            this.panel4.Location = new System.Drawing.Point(725, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(505, 82);
            this.panel4.TabIndex = 4;
            // 
            // nmrCount
            // 
            this.nmrCount.Location = new System.Drawing.Point(423, 32);
            this.nmrCount.Name = "nmrCount";
            this.nmrCount.Size = new System.Drawing.Size(69, 22);
            this.nmrCount.TabIndex = 3;
            this.nmrCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AddFood
            // 
            this.AddFood.Location = new System.Drawing.Point(313, 15);
            this.AddFood.Name = "AddFood";
            this.AddFood.Size = new System.Drawing.Size(75, 54);
            this.AddFood.TabIndex = 2;
            this.AddFood.Text = "Thêm";
            this.AddFood.UseVisualStyleBackColor = true;
            this.AddFood.Click += new System.EventHandler(this.AddFood_Click);
            // 
            // cbFood
            // 
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(4, 45);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(289, 24);
            this.cbFood.TabIndex = 1;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(4, 15);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(289, 24);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // flpTable
            // 
            this.flpTable.Location = new System.Drawing.Point(12, 31);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(691, 690);
            this.flpTable.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ShowIDTable);
            this.flowLayoutPanel1.Controls.Add(this.lvBill);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(725, 120);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(505, 509);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // ShowIDTable
            // 
            this.ShowIDTable.AutoSize = true;
            this.ShowIDTable.Location = new System.Drawing.Point(3, 0);
            this.ShowIDTable.Name = "ShowIDTable";
            this.ShowIDTable.Size = new System.Drawing.Size(59, 16);
            this.ShowIDTable.TabIndex = 1;
            this.ShowIDTable.Text = "ID Table";
            // 
            // lvBill
            // 
            this.lvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvBill.HideSelection = false;
            this.lvBill.Location = new System.Drawing.Point(5, 21);
            this.lvBill.Margin = new System.Windows.Forms.Padding(5);
            this.lvBill.Name = "lvBill";
            this.lvBill.Size = new System.Drawing.Size(502, 488);
            this.lvBill.TabIndex = 0;
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Món";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số Lượng";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành Tiền";
            this.columnHeader4.Width = 80;
            // 
            // notify
            // 
            this.notify.BalloonTipTitle = "Thông Báo";
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "Thông Báo";
            this.notify.Visible = true;
            // 
            // UserManage
            // 
            this.UserManage.AutoSize = true;
            this.UserManage.Location = new System.Drawing.Point(1127, 9);
            this.UserManage.Name = "UserManage";
            this.UserManage.Size = new System.Drawing.Size(0, 16);
            this.UserManage.TabIndex = 7;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // notifyIconSetStatus
            // 
            this.notifyIconSetStatus.BalloonTipTitle = "Thông Báo";
            this.notifyIconSetStatus.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconSetStatus.Icon")));
            this.notifyIconSetStatus.Text = "notifyIcon2";
            this.notifyIconSetStatus.Visible = true;
            // 
            // fTableManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 733);
            this.Controls.Add(this.UserManage);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần Mềm Quản Lý Quán Cà Phê";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDisCount)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmrCount)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbSwitchTable;
        private System.Windows.Forms.Button btnSwitchTable;
        private System.Windows.Forms.NumericUpDown nmDisCount;
        private System.Windows.Forms.Button btnDisCount;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nmrCount;
        private System.Windows.Forms.Button AddFood;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txbSumPrice;
        private System.Windows.Forms.ListView lvBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label ShowIDTable;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ComboBox cbbChangOrAdd;
        private System.Windows.Forms.Label UserManage;
        private System.Windows.Forms.Button setStatus;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NotifyIcon notifyIconSetStatus;
    }
}