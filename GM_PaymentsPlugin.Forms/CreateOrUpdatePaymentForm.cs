using ElPlat_PaymentsPlugin.DataLayer.Entities;
using ElPlat_PaymentsPlugin.Forms.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ElPlat_PaymentsPlugin.Forms.Infrastructure;
using ElPlat_PaymentsPlugin.Forms.Helpers;
using System.Globalization;
using ElPlat_PaymentsPlugin.Forms.Infrastructure.Commands;

namespace ElPlat_PaymentsPlugin.Forms
{
    public partial class CreateOrUpdatePaymentForm : Form
    { 

        private Payment _payment;
        private PaymentViewModel _paymentViewModel;
        List<VendorNumber> vendorNumbers = new List<VendorNumber>();
        PaymentService _paymentService;
        bool manualVendorChanges = false;
        bool IsEditMode = false;
        string oldAccountValue = "";
        List<SelectListItem> _currentServices;
        Int16 test=0;

        public Payment Payment
        {
            get
            {
                return _payment;
            }
        }





        public CreateOrUpdatePaymentForm(Payment payment, PaymentService paymentService)
        {
            InitializeComponent();
            _paymentService = paymentService;
            
            _payment = payment;
            if (_payment == null)
            {
                _paymentViewModel = new PaymentViewModel();
                this.lbTitle.Text = "Добавление нового платежа";
                this.Text = "Добавление нового платежа";
            }
            else
            {
                _paymentViewModel = payment.ToViewModel();
                this.lbTitle.Text = "Редактирование платежа";
                this.Text = "Редактирование платежа";
                IsEditMode = true;
            }

            tbAccount.DataBindings.Add("Text", _paymentViewModel, "PersonalNumber", false, DataSourceUpdateMode.OnPropertyChanged);
            tbAmount.DataBindings.Add("Text", _paymentViewModel, "Amount", false, DataSourceUpdateMode.OnValidation,0,"0.00");
            lbFioClient.DataBindings.Add("Text", _paymentViewModel, "ClientFullName", false, DataSourceUpdateMode.OnPropertyChanged);
            lbClientAddress.DataBindings.Add("Text", _paymentViewModel, "ClientAddress", false, DataSourceUpdateMode.OnPropertyChanged);
            vendorNumbers = _paymentService.GetVendors().Select(x => new VendorNumber { VendorId = x.VendorId, Number = x.Number }).ToList();
        }

        private void CreateOrUpdatePaymentForm_Load(object sender, EventArgs e)
        {

            
            cmbVendors.DataSource = _paymentService.GetVendors();
            cmbVendors.DisplayMember = "Name";
            cmbVendors.ValueMember = "VendorId";
            
            //cmbVendors.DataBindings.Add("")

            cmbVendorNumber.DataSource = vendorNumbers;
            cmbVendorNumber.DisplayMember = "Number";
            cmbVendorNumber.ValueMember = "VendorId";

            

            if (IsEditMode)
            {
                manualVendorChanges = false;
                cmbVendorNumber.SelectedItem = vendorNumbers.First(x => x.VendorId == _payment.VendorId);//cmbVendorNumber.Items.IndexOf(vendorNumbers.First(x => x.VendorId == _payment.VendorId));

                //cmbVendorService.SelectedIndex = cmbVendorService.Items.IndexOf(_currentServices.First(x => x.Value == _payment.VendorServiceId));
                cmbVendorService.SelectedItem= _currentServices.First(x => x.Value == _payment.VendorServiceId);
                foreach(var counter in _paymentViewModel.ListPaymentCounters)
                {
                    var find=_payment.ListPaymentCounters.First(x => x.CounterId == counter.CounterId);
                    counter.NewValue = find.NewValue;
                    counter.OldValue = find.OldValue;
                }
                _paymentViewModel.Amount = _payment.Amount;
                _paymentViewModel.AmountComission = _payment.AmountComission;
                _paymentViewModel.PersonalNumber = _payment.PersonalNumber;
                tbAmount.Select();
                //cmbVendorNumber.Enabled = false;
                //cmbVendors.Enabled = false;
            }
            manualVendorChanges = false;
        }


        public void DisplayError(string message)
        {
            lbError.Visible = true;
            lbError.Text = message;
        }
        private void CreateOrUpdatePaymentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                var payment = _paymentViewModel.ToModel();
                //_payment.ClientFullName = _paymentViewModel.PersonalNumber;
                try
                {
                    SplashForm.ShowSplashScreen();
                    //if (!IsEditMode)
                    //{
                        _paymentService.AddPay(payment);
                    //}
                    _payment = payment;
                    this.Close();
                }
                catch (DoPayException exception)
                {
                    DisplayError(exception.Message);
                }
                finally 
                {
                    SplashForm.CloseForm();
                }
                
                
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab= tabPage1;
        }
        //for дополнительных сведений
        private void btnAddInfo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        
      
        #region VendorsSelect
        private void cmbVendors_SelectedValueChanged(object sender, EventArgs e)
        {
            if (manualVendorChanges)
            {
                manualVendorChanges = false;
                return;
            }

            var selectedVendor = (Vendor)cmbVendors.SelectedItem;
           if (selectedVendor!= null)
           {
                manualVendorChanges = true;
                cmbVendorNumber.SelectedItem = vendorNumbers.First(x => x.VendorId == selectedVendor.VendorId);
                _paymentViewModel.VendorId = selectedVendor.VendorId;
                UpdateServicesList(selectedVendor.VendorId); 
               ClearPersonalInfo();
           }
                
        }

        private void UpdateServicesList(string vendorId)
        {
            _currentServices = _paymentService.GetVendorServiceByVendorId(vendorId)
                                            .Select(x => 
                                            new SelectListItem
                                            {
                                                Text =String.Format("{0} - {1}",x.Number,x.Name),
                                                Value=x.Id
                                            }).ToList();
            cmbVendorService.DataSource = _currentServices;
            cmbVendorService.DisplayMember = "Text";
            cmbVendorService.ValueMember = "Value";
        }


        private void cmbVendorNumber_SelectedValueChanged(object sender, EventArgs e)
        {
            if (manualVendorChanges)
            {
                manualVendorChanges = false;
                return;
            }

            var selectedVendorNumber = (VendorNumber)cmbVendorNumber.SelectedItem;

            if (selectedVendorNumber != null)
            {
                manualVendorChanges = true;
                cmbVendors.SelectedItem = _paymentService.GetVendors().First(x => x.VendorId == selectedVendorNumber.VendorId);
                _paymentViewModel.VendorId = selectedVendorNumber.VendorId;
                UpdateServicesList(selectedVendorNumber.VendorId);
                ClearPersonalInfo();
            }
        }

        private void cmbVendorNumber_KeyDown(object sender, KeyEventArgs e)
        {
            TabBackForward(sender, e);
        }

        private void cmbVendorService_KeyDown(object sender, KeyEventArgs e)
        {
            TabBackForward(sender, e);
        }

        #endregion

        #region VendorService select

        private void cmbVendorService_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectItem = (SelectListItem)cmbVendorService.SelectedItem;
            var selectService = _paymentService.GetVendorServiceById(selectItem.Value);
            _paymentViewModel.VendorServiceId = selectItem.Value;
            
            if (selectService != null)
            {
                if (selectService.HasCounters)
                {
                    LoadCounters(selectService);
                }
                else
                {
                    _paymentViewModel.ListPaymentCounters.Clear();
                    gbCounters.Visible = false;

                }

                if (selectService.HasAddInfos)
                {
                    LoadAddInfos(selectService);
                    btnAddInfo.Visible = true;
                }
                else
                {
                    _paymentViewModel.ListPaymentCounters.Clear();
                    btnAddInfo.Visible = false;
                }

            }
            lbAccountLabel.Text = selectService.AccountLabel;
            tbAccount.MaxLength = FormatHelper.GetLengthFromFormat(selectService.FormatInput);
            ClearPersonalInfo();
                
        }


        private void LoadAddInfos(VendorService selectService)
        {
            _paymentViewModel.ListPaymentAddInfos.Clear();
            
            var addInfos = CreatePaymentAddInfos(selectService.AddInfos);
            _paymentViewModel.ListPaymentAddInfos.AddRange(addInfos);

            gbAddInfos.Controls.Clear();
            int x = 20;
            int y = 20;
            int padding = 50;
            foreach (var addInfo in addInfos)
            {
                Label labelAddInfo = new Label();
                labelAddInfo.Text = addInfo.Name;
                labelAddInfo.Size = new Size(100, 25);
                labelAddInfo.Location = new Point(x, y);
                gbAddInfos.Controls.Add(labelAddInfo);

                TextBox tbValue = new TextBox();
                tbValue.Size = new Size(400, 25);
                tbValue.Location = new Point(x + 100 + padding, y);

                tbValue.DataBindings.Add("Text", addInfo, "Value", false, DataSourceUpdateMode.OnPropertyChanged);
                tbValue.KeyDown += tbnewvalue_KeyDown;
                gbAddInfos.Controls.Add(tbValue);

                y += 30;
            }
        }

        private List<PaymentAddInfoViewModel> CreatePaymentAddInfos(List<AddInfo> addInfos)
        {
            var result = new List<PaymentAddInfoViewModel>();
            foreach (var addInfo in addInfos)
            {
                result.Add(new PaymentAddInfoViewModel
                {
                    Required = addInfo.Required,
                    Name = addInfo.Name,
                    Id = addInfo.Id,
                });
            }
            return result;
        }

        private void LoadCounters(VendorService selectService)
        {

            _paymentViewModel.ListPaymentCounters.Clear();
            var viewCounters=selectService.Counters.OrderBy(c => c.Order).ToList();
            var paymentCounters = CreatePaymentCounters(viewCounters);
            _paymentViewModel.ListPaymentCounters.AddRange(paymentCounters);

            gbCounters.Controls.Clear();
            int x = 20;
            int y = 20;
            int padding = 50;
            int lastIndex=0;
            foreach (var paymentCounter in paymentCounters)
            {

                Label labelCounter = new Label();
                labelCounter.Text = paymentCounter.Name;
                labelCounter.Size = new Size(100, 25);
                labelCounter.Location = new Point(x, y);
                gbCounters.Controls.Add(labelCounter);

                TextBox tboldvalue = new TextBox();
                tboldvalue.Size = new Size(100, 25);
                tboldvalue.Location = new Point(x + 100 + padding, y);
                tboldvalue.ReadOnly=true;
                
                tboldvalue.DataBindings.Add("Text", paymentCounter, "OldValue",false,DataSourceUpdateMode.OnPropertyChanged);
                
                tboldvalue.TabStop = false; 
                gbCounters.Controls.Add(tboldvalue);
                
                //TextBox tbnewvalue = new TextBox();
                MaskedTextBox tbnewvalue = new MaskedTextBox();
                tbnewvalue.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                tbnewvalue.PromptChar = '0';
                tbnewvalue.Mask = paymentCounter.Format;// "00000.00";
                tbnewvalue.Size = new Size(100, 25);
                tbnewvalue.Location = new Point(x + 200 + 2* padding, y);
                tbnewvalue.DataBindings.Add("Text", paymentCounter, "NewValueStr", false, DataSourceUpdateMode.OnPropertyChanged);
                //tbnewvalue.KeyPress += tbnewvalue_KeyPress;
                tbnewvalue.KeyDown += tbnewvalue_KeyDown;
                gbCounters.Controls.Add(tbnewvalue);
                lastIndex = tbnewvalue.TabIndex;

                 y += 25;
            }
            gbCounters.Visible = true;
            //btnSave.TabIndex = lastIndex;
        }

        void tbnewvalue_KeyDown(object sender, KeyEventArgs e)
        {
            TabBackForward(sender, e);
        }

        void tbnewvalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbersEnter(sender, e);
        }

        private List<PaymentCounterViewModel> CreatePaymentCounters(List<Counter> counters)
        {
            var result = new List<PaymentCounterViewModel>();
            foreach (var counter in counters)
            {
                result.Add(new PaymentCounterViewModel 
                {
                    IsRequired=counter.IsRequired,
                    Name=counter.Name,
                    Order=counter.Order,
                    CounterId = counter.Id,
                    Format = FormatHelper.ParseCounterFormat(counter.InputFormat) 
                });
            }
            return result;
        }

        #endregion



        #region Account

        private void tbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            TabBackForward(sender, e);
        }


        private void tbAccount_Leave(object sender, EventArgs e)
        {
            AccountInfoLoad();
        }

        private void AccountInfoLoad()
        {
            
            
            //check if old value not ask server
            if (oldAccountValue == tbAccount.Text) return;

            try
            {
                SplashForm.ShowSplashScreen();
                var accountInfo = _paymentService.CheckPay(new CheckPayCommandParams
                {
                    Account = tbAccount.Text,
                    VendorId = _paymentViewModel.VendorId,
                    VendorServiceId = _paymentViewModel.VendorServiceId
                });
                

                //lbFioClient.Text = accountInfo.FullName;
                _paymentViewModel.ClientFullName = accountInfo.FullName;
                _paymentViewModel.ClientAddress = accountInfo.Address;
                _paymentViewModel.TransactionId = accountInfo.TransactionId;
                //lbClientAddress.Text = accountInfo.Address;
                _paymentViewModel.Amount = accountInfo.Amount;
                
                foreach (var counter in accountInfo.PaymentCounters)
                {
                    var find = _paymentViewModel.ListPaymentCounters.FirstOrDefault(x => x.CounterId == counter.CounterId);
                    if (find != null)
                    {
                        find.OldValue = counter.OldValue;
                    }
                }

            }
            catch (CheckPayException error)
            {
               
                tbAccount.Text = "";
                tbAccount.Focus();
                DisplayError(error.Message);
            }
            finally
            {
                SplashForm.CloseForm();
            }




            
            //Random rnd = new Random();
            //foreach (var counter in _paymentViewModel.ListPaymentCounters)
            //{
            //    counter.OldValue = rnd.Next(100000);
            //}
        }
        private void tbAccount_Enter(object sender, EventArgs e)
        {
            oldAccountValue = tbAccount.Text;
        }
        #endregion






        #region Amount
        private void tbAmount_KeyDown(object sender, KeyEventArgs e)
        {
            TabBackForward(sender, e);
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbersEnter(sender, e);
        }

        #endregion


        #region Utils

        private bool IsValid()
        {
            lbError.Text = "";
            lbError.Visible = false;

            if (String.IsNullOrEmpty(_paymentViewModel.VendorServiceId))
            {
                string msg = "Не верное значение услуги!";
                DisplayError(msg);

                MessageBox.Show(msg, "Валидация платежа",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(_paymentViewModel.VendorId))
            {
                string msg = "Не верное значение поставщика!";
                DisplayError(msg);

                MessageBox.Show(msg, "Валидация платежа",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(_paymentViewModel.PersonalNumber))
            {
                string msg = "Не задан номер абонента!";
                DisplayError(msg);

                MessageBox.Show(msg, "Валидация платежа",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_paymentViewModel.Amount <= 0)
            {
                string msg = "Не задана сумма!";
                DisplayError(msg);

                MessageBox.Show(msg, "Валидация платежа",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            foreach (var counter in _paymentViewModel.ListPaymentCounters)
            {
                if (counter.IsRequired && counter.NewValue <= 0)
                {
                    string msg = "Не задан счетчик " + counter.Name;
                    DisplayError(msg);

                    MessageBox.Show(msg, "Валидация платежа",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            foreach (var addInfo in _paymentViewModel.ListPaymentAddInfos)
            {
                if (addInfo.Required && string.IsNullOrEmpty(addInfo.Value))
                {
                    string msg = "Не задано доп. сведение " + addInfo.Name;
                    DisplayError(msg);

                    MessageBox.Show(msg, "Валидация платежа",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
 
            }


            return true;
        }

        private void TabBackForward(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            if (e.KeyCode == Keys.F4)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }
        private void OnlyNumbersEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.KeyChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)) && ((sender as TextBox).Text.IndexOf(Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)) > -1))
            {
                e.Handled = true;
            }
        }

        private void ClearPersonalInfo()
        {
            _paymentViewModel.Amount = 0;
            _paymentViewModel.AmountComission = 0;
            _paymentViewModel.PersonalNumber = "";

        }
        #endregion

        #region nested classes
        class VendorNumber
        {
            public string Number { get; set; }
            public string VendorId { get; set; }
        }
        #endregion

        private void btnAddInfo_Enter(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            };
        }













            
    }
}
