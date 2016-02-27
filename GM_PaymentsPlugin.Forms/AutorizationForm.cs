using GM_PaymentsPlugin.DataLayer.Entities;
using GM_PaymentsPlugin.Forms.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GM_PaymentsPlugin.Forms
{
    public partial class AutorizationForm : Form
    {

        private bool _IsAutorizationSuccess;
        private AuthenticationService _authenticationService;
        private PaymentService _paymentService;

        public bool IsAutorizationSuccess
        {
            get
            {
                return _IsAutorizationSuccess;
            }
        }

        public AutorizationForm(AuthenticationService authenticationService)
        {
            InitializeComponent();
            _authenticationService = authenticationService;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            

            var user=tbUser.Text;
            var password = tbPassword.Text;

            if (String.IsNullOrEmpty(user) && String.IsNullOrEmpty(password))
            {
                _IsAutorizationSuccess = false;
                lbErrorRegistration.Text = "Ошибка регистрации";
                lbErrorRegistration.Visible = true;

            }
            else
            {
                SplashForm.ShowSplashScreen();
                //Thread.Sleep(10000);
                var result=_authenticationService.Login(new User()
                {
                    UserName = user,
                    Password = password,
                    PostUserName = "pen0234",
                    WorkPlace = "PST4000"

                });
                if (result.Success)
                {
                    _IsAutorizationSuccess = true;
                    SplashForm.CloseForm();
                    this.Close();
                }
                else
                {
                    SplashForm.CloseForm();
                    _IsAutorizationSuccess = false;
                    lbErrorRegistration.Text = result.Message;
                    lbErrorRegistration.Visible = true;
                }
            }

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            _IsAutorizationSuccess = false;
            this.Close();
        }

        private void tbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
    }
}
