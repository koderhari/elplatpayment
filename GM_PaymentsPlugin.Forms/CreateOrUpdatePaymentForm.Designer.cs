namespace ElPlat_PaymentsPlugin.Forms
{
    partial class CreateOrUpdatePaymentForm
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.commandPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.flowLayoutPanelCartCommand = new System.Windows.Forms.FlowLayoutPanel();
            this.lbError = new System.Windows.Forms.Label();
            this.btnMainInfo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbFioClient = new System.Windows.Forms.Label();
            this.lbClientAddress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbAccountLabel = new System.Windows.Forms.Label();
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbVendorNumber = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbVendorService = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVendors = new System.Windows.Forms.ComboBox();
            this.gbCounters = new System.Windows.Forms.GroupBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddInfo = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.commandPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanelCartCommand.SuspendLayout();
            this.panel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.headerPanel.Controls.Add(this.lbTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1119, 95);
            this.headerPanel.TabIndex = 0;
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lbTitle.Location = new System.Drawing.Point(466, 32);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(102, 29);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Платеж";
            // 
            // commandPanel
            // 
            this.commandPanel.Controls.Add(this.flowLayoutPanel1);
            this.commandPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.commandPanel.Location = new System.Drawing.Point(884, 95);
            this.commandPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(235, 585);
            this.commandPanel.TabIndex = 70;
            this.commandPanel.TabStop = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(235, 585);
            this.flowLayoutPanel1.TabIndex = 50;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(3, 494);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 35, 3, 35);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(213, 56);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(3, 368);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 35, 3, 35);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(213, 56);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // flowLayoutPanelCartCommand
            // 
            this.flowLayoutPanelCartCommand.Controls.Add(this.lbError);
            this.flowLayoutPanelCartCommand.Controls.Add(this.btnMainInfo);
            this.flowLayoutPanelCartCommand.Controls.Add(this.btnAddInfo);
            this.flowLayoutPanelCartCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelCartCommand.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelCartCommand.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelCartCommand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanelCartCommand.Name = "flowLayoutPanelCartCommand";
            this.flowLayoutPanelCartCommand.Size = new System.Drawing.Size(240, 585);
            this.flowLayoutPanelCartCommand.TabIndex = 40;
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(3, 100);
            this.lbError.Margin = new System.Windows.Forms.Padding(3, 100, 3, 0);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(70, 25);
            this.lbError.TabIndex = 4;
            this.lbError.Text = "label8";
            this.lbError.Visible = false;
            // 
            // btnMainInfo
            // 
            this.btnMainInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainInfo.Location = new System.Drawing.Point(3, 160);
            this.btnMainInfo.Margin = new System.Windows.Forms.Padding(3, 35, 3, 35);
            this.btnMainInfo.Name = "btnMainInfo";
            this.btnMainInfo.Size = new System.Drawing.Size(213, 56);
            this.btnMainInfo.TabIndex = 3;
            this.btnMainInfo.TabStop = false;
            this.btnMainInfo.Text = "Данные";
            this.btnMainInfo.UseVisualStyleBackColor = true;
            this.btnMainInfo.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelCartCommand);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 95);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 585);
            this.panel1.TabIndex = 60;
            this.panel1.TabStop = true;
            // 
            // mainPanel
            // 
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.tabControl1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(240, 95);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(644, 585);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.TabStop = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(642, 583);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.gbCounters);
            this.tabPage1.Controls.Add(this.tbAmount);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 5);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(634, 574);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbFioClient);
            this.groupBox2.Controls.Add(this.lbClientAddress);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lbAccountLabel);
            this.groupBox2.Controls.Add(this.tbAccount);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 164);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(628, 162);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Абонент";
            // 
            // lbFioClient
            // 
            this.lbFioClient.AutoSize = true;
            this.lbFioClient.Location = new System.Drawing.Point(173, 46);
            this.lbFioClient.Name = "lbFioClient";
            this.lbFioClient.Size = new System.Drawing.Size(47, 20);
            this.lbFioClient.TabIndex = 4;
            this.lbFioClient.Text = "ФИО";
            // 
            // lbClientAddress
            // 
            this.lbClientAddress.AutoSize = true;
            this.lbClientAddress.Location = new System.Drawing.Point(12, 121);
            this.lbClientAddress.Name = "lbClientAddress";
            this.lbClientAddress.Size = new System.Drawing.Size(57, 20);
            this.lbClientAddress.TabIndex = 3;
            this.lbClientAddress.Text = "Адрес";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Адрес";
            // 
            // lbAccountLabel
            // 
            this.lbAccountLabel.AutoSize = true;
            this.lbAccountLabel.Location = new System.Drawing.Point(12, 22);
            this.lbAccountLabel.Name = "lbAccountLabel";
            this.lbAccountLabel.Size = new System.Drawing.Size(114, 20);
            this.lbAccountLabel.TabIndex = 1;
            this.lbAccountLabel.Text = "Лицевой счет";
            // 
            // tbAccount
            // 
            this.tbAccount.Location = new System.Drawing.Point(9, 46);
            this.tbAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Size = new System.Drawing.Size(130, 26);
            this.tbAccount.TabIndex = 0;
            this.tbAccount.Enter += new System.EventHandler(this.tbAccount_Enter);
            this.tbAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAccount_KeyDown);
            this.tbAccount.Leave += new System.EventHandler(this.tbAccount_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbVendorNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbVendorService);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbVendors);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(628, 160);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поставщик";
            // 
            // cmbVendorNumber
            // 
            this.cmbVendorNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVendorNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVendorNumber.FormattingEnabled = true;
            this.cmbVendorNumber.Location = new System.Drawing.Point(11, 62);
            this.cmbVendorNumber.Margin = new System.Windows.Forms.Padding(3, 4, 34, 4);
            this.cmbVendorNumber.Name = "cmbVendorNumber";
            this.cmbVendorNumber.Size = new System.Drawing.Size(92, 28);
            this.cmbVendorNumber.Sorted = true;
            this.cmbVendorNumber.TabIndex = 0;
            this.cmbVendorNumber.SelectedValueChanged += new System.EventHandler(this.cmbVendorNumber_SelectedValueChanged);
            this.cmbVendorNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbVendorNumber_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Услуга";
            // 
            // cmbVendorService
            // 
            this.cmbVendorService.FormattingEnabled = true;
            this.cmbVendorService.Location = new System.Drawing.Point(10, 119);
            this.cmbVendorService.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbVendorService.Name = "cmbVendorService";
            this.cmbVendorService.Size = new System.Drawing.Size(583, 28);
            this.cmbVendorService.TabIndex = 1;
            this.cmbVendorService.SelectedValueChanged += new System.EventHandler(this.cmbVendorService_SelectedValueChanged);
            this.cmbVendorService.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbVendorService_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Наименование";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Номер";
            // 
            // cmbVendors
            // 
            this.cmbVendors.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVendors.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVendors.FormattingEnabled = true;
            this.cmbVendors.Location = new System.Drawing.Point(147, 62);
            this.cmbVendors.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbVendors.Name = "cmbVendors";
            this.cmbVendors.Size = new System.Drawing.Size(447, 28);
            this.cmbVendors.Sorted = true;
            this.cmbVendors.TabIndex = 2;
            this.cmbVendors.TabStop = false;
            this.cmbVendors.SelectedValueChanged += new System.EventHandler(this.cmbVendors_SelectedValueChanged);
            // 
            // gbCounters
            // 
            this.gbCounters.AutoSize = true;
            this.gbCounters.Location = new System.Drawing.Point(16, 367);
            this.gbCounters.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbCounters.Name = "gbCounters";
            this.gbCounters.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbCounters.Size = new System.Drawing.Size(587, 196);
            this.gbCounters.TabIndex = 4;
            this.gbCounters.TabStop = false;
            this.gbCounters.Text = "Счетчики";
            this.gbCounters.Visible = false;
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(75, 340);
            this.tbAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(145, 26);
            this.tbAmount.TabIndex = 3;
            this.tbAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAmount_KeyDown);
            this.tbAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAmount_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Сумма";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 5);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(634, 574);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(207, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "label7";
            // 
            // btnAddInfo
            // 
            this.btnAddInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInfo.Location = new System.Drawing.Point(3, 254);
            this.btnAddInfo.Name = "btnAddInfo";
            this.btnAddInfo.Size = new System.Drawing.Size(213, 57);
            this.btnAddInfo.TabIndex = 5;
            this.btnAddInfo.Text = "Доп. сведения";
            this.btnAddInfo.UseVisualStyleBackColor = true;
            this.btnAddInfo.Visible = false;
            this.btnAddInfo.Click += new System.EventHandler(this.btnAddInfo_Click);
            // 
            // CreateOrUpdatePaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 680);
            this.ControlBox = false;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.commandPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "CreateOrUpdatePaymentForm";
            this.Text = "Редактирование платежа";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CreateOrUpdatePaymentForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreateOrUpdatePaymentForm_KeyDown);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.commandPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanelCartCommand.ResumeLayout(false);
            this.flowLayoutPanelCartCommand.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel commandPanel;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCartCommand;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnMainInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbCounters;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbFioClient;
        private System.Windows.Forms.Label lbClientAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbAccountLabel;
        private System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbVendorNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbVendorService;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVendors;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddInfo;
    }
}