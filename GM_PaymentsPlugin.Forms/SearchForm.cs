using ElPlat_PaymentsPlugin.DataLayer.Entities;
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
        public SearchForm(PaymentService paymentsService)
        {
            InitializeComponent();
            _paymentsService = paymentsService;
            
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            dataGridSearchResults.DataSource = _searchResults;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void DoSearch()
        {
            _searchResults.Clear();

            try
            {
                SplashForm.ShowSplashScreen();
                List<AccountInfo> accounts = _paymentsService.SearchAccountServices(tbBarcode.Text);

                foreach (var account in accounts)
                    _searchResults.Add(ToViewModel(account));

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
                VendorId=selectAccountInfo.VendorId,
                VendorServiceId=selectAccountInfo.VendorServiceId
            });
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
            model.VendorId = findVendorService.VendorId;
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
        }

        //#region Utils
        //private PaymentCartItemViewModel GetSelectedPayment()
        //{
        //    if (datagridPayments.SelectedRows.Count > 0)
        //    {
        //        for (int i = 0; i < datagridPayments.SelectedRows.Count; i++)
        //        {
        //            var currentPayment = (PaymentCartItemViewModel)datagridPayments.SelectedRows[i].DataBoundItem;
        //            return currentPayment;
        //        }
        //        return null;
        //    }
        //    else return null;
        //}
        //#endregion


    }
}
