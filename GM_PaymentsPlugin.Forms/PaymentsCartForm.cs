using ElPlat_PaymentsPlugin.DataLayer.Entities;
using ElPlat_PaymentsPlugin.Forms.Infrastructure;
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
    
    
    public partial class PaymentsCartForm : Form
    {

        private List<PaymentOld> _recievedPayments;
        BindingList<PaymentCartItemViewModel> _cartPayments = new BindingList<PaymentCartItemViewModel>();
        List<Payment> _payments;
        PaymentService _paymentsService;
        /// <summary>
        /// Список оформленных платежей
        /// </summary>
        public IEnumerable<Payment> Payments
        {
            get
            {
                return _payments;
            }
        }


        private BindingSource bindingSource1 = new BindingSource();
        private PaymentsCartFormSettings _settings;

        public PaymentsCartForm(PaymentsCartFormSettings settings, PaymentService paymentsService)
        {
            InitializeComponent();
            
            _paymentsService = paymentsService;
            _recievedPayments = new List<PaymentOld>();
            _payments = new List<Payment>();
            _settings = settings;
            //_payments = _paymentsService.GetPayments();
            foreach (var payment in _payments)
            {
                _cartPayments.Add(ToCartItemViewModel(payment));
            }
            
        }

        private void PaymentsCartForm_Load(object sender, EventArgs e)
        {

            
            //payments.Add(new PaymentCartItemViewModel { Amount=123.45M,ClientFullName="Василив Иоанн Петрович",VendorName="Межрегионгаз пенза" });
            datagridPayments.DataSource = _cartPayments;
        }


        public void DisplayError(string message)
        {
            lbError.Visible = true;
            lbError.Text = message;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPayment();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditPayment();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private PaymentCartItemViewModel ToCartItemViewModel(Payment payment)
        {
            var result = new PaymentCartItemViewModel();
            
            //Amount=123.45M,ClientFullName="Василив Иоанн Петрович",VendorName="Межрегионгаз пенза" 

            result.Amount=payment.Amount;
            result.ClientFullName=payment.ClientFullName;
            result.VendorName = _paymentsService.GetVendorById(payment.VendorId).Name;
            result.Id = payment.Id;

            return result;

        }

        private void PaymentsCartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                AddPayment();
                e.SuppressKeyPress = true;  
            }


            if (e.KeyCode == Keys.F8)
            {
                DeletePayment();
                e.SuppressKeyPress = true;
            }


            if (e.KeyCode == Keys.Enter)
            {
                EditPayment();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.F4)
            {
                this.Close();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.F1)
            {
                FindService();
                e.SuppressKeyPress = true;
            }
        }

        private void FindService()
        {
            using (var searchForm = new SearchForm(_paymentsService))
            {
                searchForm.ShowDialog();
                if (searchForm.FindPayment != null)
                {
                    OpenEditForm(searchForm.FindPayment);
                }
            }
        }




        private void EditPayment()
        {
            var payItemForEdit = GetSelectedPayment();
            if (payItemForEdit == null) return;
            var payForEdit=_payments.First(x => x.Id == payItemForEdit.Id);
            OpenEditForm(payForEdit);
           
        }

        private void OpenEditForm(Payment payForEdit)
        {
            //нет редактирования, если добавлять то надо разделять логику для платежей после поиска
            using (var form = new CreateOrUpdatePaymentForm(payForEdit, _paymentsService))
            {
                form.ShowDialog();

                //_paymentsService.EditPay(form.Payment);
                //_payments = _paymentsService.GetPayments();
                //_payments.Remove(payForEdit);
                _payments.Add(form.Payment);
                //_cartPayments.Remove(_cartPayments.First(x => x.Id == form.Payment.Id));
                _cartPayments.Add(ToCartItemViewModel(form.Payment));
            }
        }

        private void AddPayment()
        {
            using (var form = new CreateOrUpdatePaymentForm(null, _paymentsService))
            {
                form.ShowDialog();
                if (form.Payment != null)
                {
                    _payments.Add(form.Payment);
                    _cartPayments.Add(ToCartItemViewModel(form.Payment));
                    if (_settings.SingleMode)
                        this.Close();
                    
                    //_payments = _paymentsService.GetPayments();
                }
            }
        }

        private void DeletePayment()
        {
            var payForDelete = GetSelectedPayment();
            if (payForDelete == null) return;
            var id = payForDelete.Id;
            try
            {
                SplashForm.ShowSplashScreen();
                _paymentsService.DeletePayment(id);
                //_payments = _paymentsService.GetPayments();
                _cartPayments.Remove(_cartPayments.First(x => x.Id == id));
                _payments.Remove(_payments.First(x => x.Id == id));
            }
            catch (CancelPayException ex)
            {
                DisplayError(ex.Message);
                
            }
            finally
            {
                SplashForm.CloseForm();
            }
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePayment();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindService();
        }

        #region Utils
        private PaymentCartItemViewModel GetSelectedPayment()
        {
            if (datagridPayments.SelectedRows.Count > 0)
            {
                for (int i = 0; i < datagridPayments.SelectedRows.Count; i++)
                {
                    var currentPayment = (PaymentCartItemViewModel)datagridPayments.SelectedRows[i].DataBoundItem;
                    return currentPayment;
                }
                return null;
            }
            else return null;
        }
        #endregion


    }

    public class PaymentsCartFormSettings
    {
        public bool SingleMode { get; set; }
    }
}
