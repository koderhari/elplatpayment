using GM_PaymentsPlugin.DataLayer.Entities;
using GM_PaymentsPlugin.Forms.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GM_PaymentsPlugin.Forms
{
    public partial class SearchForm : Form
    {
        private PaymentService _paymentsService;
        BindingList<AccountInfo> _searchResults = new BindingList<AccountInfo>();
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
            List<AccountInfo> accounts=_paymentsService.SearchAccountServices(tbBarcode.Text);
            foreach(var account in accounts)
                _searchResults.Add(account);
            
        }

        private void btSelect_Click(object sender, EventArgs e)
        {

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
