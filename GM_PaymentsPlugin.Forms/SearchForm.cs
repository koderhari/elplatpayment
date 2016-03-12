using ElPlat_PaymentsPlugin.DataLayer.Entities;
using ElPlat_PaymentsPlugin.Forms.Helpers;
using ElPlat_PaymentsPlugin.Forms.Infrastructure;
using ElPlat_PaymentsPlugin.Forms.Infrastructure.Commands;
using ElPlat_PaymentsPlugin.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ElPlat_PaymentsPlugin.Forms
{
    public partial class SearchForm : Form
    {
        private PaymentService _paymentsService;
        BindingList<AccountInfoViewModel> _searchResults = new BindingList<AccountInfoViewModel>();
        public Payment FindPayment { get; set; }
        public SearchForm(PaymentService paymentsService)
        {
            InitializeComponent();
            _paymentsService = paymentsService;
            
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            dataGridSearchResults.DataSource = _searchResults;
            dataGridSearchResults.Columns[0].Width=180;
            dataGridSearchResults.Columns[1].Width = 100;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void DoSearch()
        {
            _searchResults.Clear();
            lbError.Visible = false;
            try
            {
                SplashForm.ShowSplashScreen();
                List<AccountInfo> accounts = _paymentsService.SearchAccountServices(tbBarcode.Text);
                if (accounts.Count > 0)
                {
                    foreach (var account in accounts)
                        _searchResults.Add(ToViewModel(account));
                    btSelect.Select();
                }
                else 
                {
                    DisplayError("Нет результатов");
                }

            }
            catch (CommandException ex)
            {
                DisplayError(ex.Message);
             }
            finally
            {
                SplashForm.CloseForm();
            }
            
        }

        
        
        private void btSelect_Click(object sender, EventArgs e)
        {
            var selectAccountInfo = GetSelectedAccountInfo();
            var accountInfoWithCounters=_paymentsService.CheckPay(new CheckPayCommandParams
            {
                Account=selectAccountInfo.PersonalNumber,
                VendorId=selectAccountInfo.VendorService.VendorId,
                VendorServiceId=selectAccountInfo.VendorServiceId
            });
            FindPayment = CreatePayment(selectAccountInfo.VendorService,accountInfoWithCounters);
            this.Close();
        }

        private Payment CreatePayment(VendorService vendorService, AccountInfo accountInfoWithCounters)
        {
            var payment = new Payment();
            payment.Amount = accountInfoWithCounters.Amount;
            payment.ClientAddress = accountInfoWithCounters.Address;
            payment.ClientFullName = accountInfoWithCounters.FullName;
            payment.TransactionId = accountInfoWithCounters.TransactionId;
            payment.PersonalNumber = accountInfoWithCounters.PersonalNumber;
            payment.VendorId = vendorService.VendorId;
            payment.VendorServiceId = vendorService.Id;
            payment.VendorServiceNumber = vendorService.Number;
            foreach(var counter in vendorService.Counters)
            {
                payment.ListPaymentCounters.Add(new PaymentCounter 
                {
                    IsRequired=counter.IsRequired,
                    Name=counter.Name,
                    Order=counter.Order,
                    CounterId = counter.Id
                });
            }
            foreach (var counter in accountInfoWithCounters.PaymentCounters)
            {
                var find = payment.ListPaymentCounters.FirstOrDefault(x => x.CounterId == counter.CounterId);
                if (find != null)
                {
                    find.OldValue = counter.OldValue;
                }
            }
               
            return payment;
            
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private AccountInfoViewModel ToViewModel(AccountInfo accountInfo) 
        {
            var model = new AccountInfoViewModel();
            model.Address = accountInfo.Address;
            model.Amount = accountInfo.Amount;
            model.FullName = accountInfo.FullName;
            model.PersonalNumber = accountInfo.PersonalNumber;
            model.VendorServiceId = accountInfo.VendorServiceId;
            var findVendorService = _paymentsService.GetVendorServiceById(accountInfo.VendorServiceId);
            model.VendorServiceName = findVendorService.Name;
            model.VendorService= findVendorService;
            return model;
        }

        private AccountInfoViewModel GetSelectedAccountInfo()
        {
            if (dataGridSearchResults.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridSearchResults.SelectedRows.Count; i++)
                {
                    return (AccountInfoViewModel)dataGridSearchResults.SelectedRows[i].DataBoundItem;
                }
                return null;
            }
            else return null;
        }

        void DisplayError(string msg)
        {
            lbError.Text = msg;
            lbError.Visible = true;
        }

        private void tbBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                DoSearch();
            }
        }



    }
}
