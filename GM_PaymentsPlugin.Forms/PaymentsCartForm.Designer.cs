namespace GM_PaymentsPlugin.Forms
{
    partial class PaymentsCartForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.commandPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.flowLayoutPanelCartCommand = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cartPanel = new System.Windows.Forms.Panel();
            this.datagridPayments = new System.Windows.Forms.DataGridView();
            this.headerPanel.SuspendLayout();
            this.commandPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanelCartCommand.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.headerPanel.Controls.Add(this.label1);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(995, 81);
            this.headerPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(414, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Платежи";
            // 
            // commandPanel
            // 
            this.commandPanel.Controls.Add(this.flowLayoutPanel1);
            this.commandPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.commandPanel.Location = new System.Drawing.Point(786, 81);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(209, 497);
            this.commandPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(209, 497);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(3, 419);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 30, 3, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(189, 48);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSize = true;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Location = new System.Drawing.Point(3, 111);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(189, 48);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "F5 - подтвердить";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(3, 57);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(189, 48);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "F3 - создать";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(189, 48);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "F1 - выбор";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // flowLayoutPanelCartCommand
            // 
            this.flowLayoutPanelCartCommand.Controls.Add(this.btnSearch);
            this.flowLayoutPanelCartCommand.Controls.Add(this.btnAdd);
            this.flowLayoutPanelCartCommand.Controls.Add(this.btnConfirm);
            this.flowLayoutPanelCartCommand.Controls.Add(this.btnDelete);
            this.flowLayoutPanelCartCommand.Controls.Add(this.btnEdit);
            this.flowLayoutPanelCartCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelCartCommand.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelCartCommand.Name = "flowLayoutPanelCartCommand";
            this.flowLayoutPanelCartCommand.Size = new System.Drawing.Size(213, 497);
            this.flowLayoutPanelCartCommand.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(3, 165);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(189, 48);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "F8 - удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(3, 219);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(189, 48);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.TabStop = false;
            this.btnEdit.Text = "Enter - редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelCartCommand);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 497);
            this.panel1.TabIndex = 3;
            // 
            // cartPanel
            // 
            this.cartPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cartPanel.Controls.Add(this.datagridPayments);
            this.cartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartPanel.Location = new System.Drawing.Point(213, 81);
            this.cartPanel.Name = "cartPanel";
            this.cartPanel.Size = new System.Drawing.Size(573, 497);
            this.cartPanel.TabIndex = 4;
            // 
            // datagridPayments
            // 
            this.datagridPayments.AllowUserToAddRows = false;
            this.datagridPayments.AllowUserToDeleteRows = false;
            this.datagridPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridPayments.Location = new System.Drawing.Point(0, 0);
            this.datagridPayments.Name = "datagridPayments";
            this.datagridPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridPayments.Size = new System.Drawing.Size(571, 495);
            this.datagridPayments.TabIndex = 2;
            // 
            // PaymentsCartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 578);
            this.ControlBox = false;
            this.Controls.Add(this.cartPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.commandPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "PaymentsCartForm";
            this.Text = "Коммунальные платежи";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PaymentsCartForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PaymentsCartForm_KeyDown);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.commandPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanelCartCommand.ResumeLayout(false);
            this.flowLayoutPanelCartCommand.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.cartPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridPayments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel commandPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCartCommand;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel cartPanel;
        private System.Windows.Forms.DataGridView datagridPayments;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
    }
}