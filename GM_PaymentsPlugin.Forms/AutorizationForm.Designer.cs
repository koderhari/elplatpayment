namespace ElPlat_PaymentsPlugin.Forms
{
    partial class AutorizationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lbErrorRegistration = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пользователь";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 258);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // btOk
            // 
            this.btOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btOk.Location = new System.Drawing.Point(116, 403);
            this.btOk.Margin = new System.Windows.Forms.Padding(6);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(174, 52);
            this.btOk.TabIndex = 3;
            this.btOk.Text = "Ок";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btCancel.Location = new System.Drawing.Point(402, 403);
            this.btCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(174, 52);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // tbUser
            // 
            this.tbUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.tbUser.Location = new System.Drawing.Point(192, 180);
            this.tbUser.Margin = new System.Windows.Forms.Padding(6);
            this.tbUser.MaxLength = 0;
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(325, 35);
            this.tbUser.TabIndex = 1;
            this.tbUser.Text = "pen00080";
            this.tbUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUser_KeyDown);
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPassword.Location = new System.Drawing.Point(188, 293);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(6);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(325, 35);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.Text = "hockey10";
            this.tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPassword_KeyDown);
            // 
            // lbErrorRegistration
            // 
            this.lbErrorRegistration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbErrorRegistration.AutoSize = true;
            this.lbErrorRegistration.ForeColor = System.Drawing.Color.Red;
            this.lbErrorRegistration.Location = new System.Drawing.Point(183, 81);
            this.lbErrorRegistration.Name = "lbErrorRegistration";
            this.lbErrorRegistration.Size = new System.Drawing.Size(79, 29);
            this.lbErrorRegistration.TabIndex = 6;
            this.lbErrorRegistration.Text = "label3";
            this.lbErrorRegistration.Visible = false;
            // 
            // AutorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 583);
            this.ControlBox = false;
            this.Controls.Add(this.lbErrorRegistration);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutorizationForm";
            this.Text = "Авторизация";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbErrorRegistration;
    }
}