namespace GM_PaymentsPlugin.Forms
{
    partial class RecievePaymentsForm
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
            this.MainFormLayout = new System.Windows.Forms.TableLayoutPanel();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.BodyPanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbClientAddress = new System.Windows.Forms.TextBox();
            this.bsFormData = new System.Windows.Forms.BindingSource(this.components);
            this.tbAmountComission = new System.Windows.Forms.TextBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.tbPersonalAccountNumber = new System.Windows.Forms.TextBox();
            this.cmbVendor = new System.Windows.Forms.ComboBox();
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.btnSaveAndNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.MainFormLayout.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
            this.BodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFormData)).BeginInit();
            this.FooterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormLayout
            // 
            this.MainFormLayout.ColumnCount = 1;
            this.MainFormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainFormLayout.Controls.Add(this.HeaderPanel, 0, 0);
            this.MainFormLayout.Controls.Add(this.BodyPanel, 0, 1);
            this.MainFormLayout.Controls.Add(this.FooterPanel, 0, 2);
            this.MainFormLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormLayout.Location = new System.Drawing.Point(0, 0);
            this.MainFormLayout.Name = "MainFormLayout";
            this.MainFormLayout.RowCount = 3;
            this.MainFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.MainFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.MainFormLayout.Size = new System.Drawing.Size(784, 562);
            this.MainFormLayout.TabIndex = 0;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.lblTitle);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderPanel.Location = new System.Drawing.Point(3, 3);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(778, 94);
            this.HeaderPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(9, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(760, 82);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Заголовок формы";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BodyPanel
            // 
            this.BodyPanel.Controls.Add(this.dataGridView1);
            this.BodyPanel.Controls.Add(this.tbClientAddress);
            this.BodyPanel.Controls.Add(this.tbAmountComission);
            this.BodyPanel.Controls.Add(this.tbAmount);
            this.BodyPanel.Controls.Add(this.tbPersonalAccountNumber);
            this.BodyPanel.Controls.Add(this.cmbVendor);
            this.BodyPanel.Controls.Add(this.cmbPaymentType);
            this.BodyPanel.Controls.Add(this.label2);
            this.BodyPanel.Controls.Add(this.label4);
            this.BodyPanel.Controls.Add(this.label7);
            this.BodyPanel.Controls.Add(this.label6);
            this.BodyPanel.Controls.Add(this.label5);
            this.BodyPanel.Controls.Add(this.label1);
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(3, 103);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(778, 396);
            this.BodyPanel.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(119, 219);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 9;
            // 
            // tbClientAddress
            // 
            this.tbClientAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFormData, "ClientAddress", true));
            this.tbClientAddress.Location = new System.Drawing.Point(12, 74);
            this.tbClientAddress.Multiline = true;
            this.tbClientAddress.Name = "tbClientAddress";
            this.tbClientAddress.Size = new System.Drawing.Size(755, 52);
            this.tbClientAddress.TabIndex = 4;
            // 
            // bsFormData
            // 
            this.bsFormData.DataSource = typeof(GM_PaymentsPlugin.DataLayer.Entities.PaymentOld);
            // 
            // tbAmountComission
            // 
            this.tbAmountComission.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFormData, "AmountComission", true));
            this.tbAmountComission.Location = new System.Drawing.Point(508, 178);
            this.tbAmountComission.Name = "tbAmountComission";
            this.tbAmountComission.ReadOnly = true;
            this.tbAmountComission.Size = new System.Drawing.Size(259, 20);
            this.tbAmountComission.TabIndex = 7;
            // 
            // tbAmount
            // 
            this.tbAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFormData, "Amount", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N3"));
            this.tbAmount.Location = new System.Drawing.Point(105, 178);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(294, 20);
            this.tbAmount.TabIndex = 6;
            this.tbAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAmount_KeyPress);
            // 
            // tbPersonalAccountNumber
            // 
            this.tbPersonalAccountNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFormData, "PersonalNumber", true));
            this.tbPersonalAccountNumber.Location = new System.Drawing.Point(12, 153);
            this.tbPersonalAccountNumber.Name = "tbPersonalAccountNumber";
            this.tbPersonalAccountNumber.Size = new System.Drawing.Size(755, 20);
            this.tbPersonalAccountNumber.TabIndex = 5;
            // 
            // cmbVendor
            // 
            this.cmbVendor.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bsFormData, "Vendor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendor.FormattingEnabled = true;
            this.cmbVendor.Location = new System.Drawing.Point(268, 26);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.Size = new System.Drawing.Size(501, 21);
            this.cmbVendor.TabIndex = 2;
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bsFormData, "PaymentType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Location = new System.Drawing.Point(12, 26);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(230, 21);
            this.cmbPaymentType.TabIndex = 1;
            this.cmbPaymentType.SelectionChangeCommitted += new System.EventHandler(this.cmbPaymentType_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Поставщик:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Адрес абонента:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(405, 181);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Сумма комиссии:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 181);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Сумма платежа:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Лицевой счет абонента:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип платежа:";
            // 
            // FooterPanel
            // 
            this.FooterPanel.Controls.Add(this.btnSaveAndNext);
            this.FooterPanel.Controls.Add(this.btnCancel);
            this.FooterPanel.Controls.Add(this.btnSaveAndClose);
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FooterPanel.Location = new System.Drawing.Point(3, 505);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(778, 54);
            this.FooterPanel.TabIndex = 2;
            // 
            // btnSaveAndNext
            // 
            this.btnSaveAndNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAndNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveAndNext.Location = new System.Drawing.Point(191, 3);
            this.btnSaveAndNext.Name = "btnSaveAndNext";
            this.btnSaveAndNext.Size = new System.Drawing.Size(240, 40);
            this.btnSaveAndNext.TabIndex = 9;
            this.btnSaveAndNext.Text = "Сохранить и перейти к следующему";
            this.btnSaveAndNext.UseVisualStyleBackColor = true;
            this.btnSaveAndNext.Click += new System.EventHandler(this.btnSaveAndNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(619, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAndClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(9, 3);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(176, 40);
            this.btnSaveAndClose.TabIndex = 8;
            this.btnSaveAndClose.Text = "Сохранить и завершить";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            // 
            // RecievePaymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.MainFormLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "RecievePaymentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecievePaymentsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecievePaymentsForm_FormClosing);
            this.Load += new System.EventHandler(this.RecievePaymentsForm_Load);
            this.MainFormLayout.ResumeLayout(false);
            this.HeaderPanel.ResumeLayout(false);
            this.BodyPanel.ResumeLayout(false);
            this.BodyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFormData)).EndInit();
            this.FooterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainFormLayout;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveAndNext;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.ComboBox cmbVendor;
        private System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel FooterPanel;
        private System.Windows.Forms.TextBox tbClientAddress;
        private System.Windows.Forms.TextBox tbPersonalAccountNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAmountComission;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bsFormData;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}