using System;
using System.Linq;
using GM_PaymentsPlugin.DataLayer.Entities;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace GM_PaymentsPlugin.Forms
{
    public partial class RecievePaymentsForm : Form
    {
        private List<PaymentOld> _recievedPayments;
        
        /// <summary>
        /// Список оформленных платежей
        /// </summary>
        public IEnumerable<PaymentOld> RecievedPayments
        {
            get
            {
                return _recievedPayments ?? (_recievedPayments = new List<PaymentOld>());
            }
        }

        /// <summary>
        /// Конфигурация формы
        /// </summary>
        private RecievePaymentsFormSettings Settings { get; set; }

        /// <summary>
        /// Свойство для установки заголовка формы
        /// </summary>
        private String FormTitle
        {
            get
            {
                return this.lblTitle.Text;
            }
            set
            {
                this.lblTitle.Text = value ?? String.Empty;
            }
        }

        private PaymentOld EditValue { get; set; }

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="settings">Начальная конфигурация формы</param>
        public RecievePaymentsForm(RecievePaymentsFormSettings settings)
        {
            InitializeComponent();

            if (settings == null)
                throw new ArgumentNullException("settings");

            Settings = settings;
            _recievedPayments = new List<PaymentOld>();
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void RecievePaymentsForm_Load(object sender, EventArgs e)
        {
            cmbPaymentType.DataSource = Settings.AvailablePaymentTypes;
            cmbPaymentType.DisplayMember = "Name";
            cmbPaymentType.ValueMember = "PaymentTypeId";

            cmbVendor.DataSource = Settings.AvailableVendors;
            cmbVendor.DisplayMember = "Name";
            cmbVendor.ValueMember = "VendorId";

            ResetForm();
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        private void RecievePaymentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (IsValid())
                    _recievedPayments.Add(GetFormPaymentData());
                else
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// Сохранить и продолжить
        /// </summary>
        private void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                _recievedPayments.Add(GetFormPaymentData());
                ResetForm();
            }
        }

        /// <summary>
        /// Выбор типа перевода
        /// </summary>
        private void cmbPaymentType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var paymentId = (sender as ComboBox).SelectedValue.ToString();

            if (EditValue.Vendor == null || EditValue.Vendor.PaymentTypeId != paymentId)
            {
                // Датасорс для комбобокса с поставщиками
                var vendors = Settings.AvailableVendors
                    .Where(x => x.PaymentTypeId.Equals(paymentId))
                    .OrderBy(x => x.Name).ToList();
                
                cmbVendor.DataSource = vendors;
                EditValue.Vendor = vendors.FirstOrDefault();
            }
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            var separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.First();

            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != separator)
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == separator
                && (sender as TextBox).Text.IndexOf(separator) > -1)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Сбросить данные формы
        /// </summary>
        private void ResetForm()
        {
            FormTitle = "Прием платежей";

            if (Settings.CurrentPaymentType == null)
            {
                Settings.CurrentPaymentType = Settings.AvailablePaymentTypes.OrderBy(x => x.PaymentTypeId).First();
            }

            if (Settings.CurrentVendor == null || Settings.CurrentVendor.PaymentTypeId != Settings.CurrentPaymentType.PaymentTypeId)
            {
                Settings.CurrentVendor = Settings.AvailableVendors
                    .Where(x => x.PaymentTypeId.Equals(Settings.CurrentPaymentType.PaymentTypeId))
                    .OrderBy(x => x.Name)
                    .FirstOrDefault();
            }

            // Датасорс для комбобокса с поставщиками
            cmbVendor.DataSource = Settings.AvailableVendors
                .Where(x => x.PaymentTypeId.Equals(Settings.CurrentPaymentType.PaymentTypeId))
                .OrderBy(x => x.Name).ToList();

            EditValue = new PaymentOld()
            {
                Description = "Платеж в адрес ОАО «Тюменская энергосбытовая компания»",
                AmountComission = 0,
                PaymentType = Settings.CurrentPaymentType,
                Vendor = Settings.CurrentVendor
            };
            bsFormData.DataSource = EditValue;

            if (Settings.IsMultiMode)
            {
                cmbPaymentType.Enabled = true;
                cmbVendor.Enabled = true;
                btnSaveAndNext.Enabled = true;
            }
            else
            {
                cmbPaymentType.Enabled = false;
                cmbVendor.Enabled = Settings.CurrentVendor == null;
                btnSaveAndNext.Enabled = false;
            }

            //BindingList<A>
            List<A> test= new List<A>();
            test.Add(new A { Field1 = "asd", Field2 = "das" });
            dataGridView1.DataSource = test;
            cmbVendor.DisplayMember = "Name";
            cmbVendor.ValueMember = "VendorId";
        }
        public class A
        {
            public string Field1 { get; set; }
            public string Field2 { get; set; }
        }

        /// <summary>
        /// Выполняет валидацию данных формы
        /// </summary>
        private bool IsValid()
        {
            if (EditValue.PaymentType == null)
            {
                MessageBox.Show("Не верное значение типа платежа!", "Валидация платежа",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (EditValue.Vendor == null)
            {
                MessageBox.Show("Не верное значение поставщика!", "Валидация платежа",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (EditValue.Amount <= 0)
            {
                MessageBox.Show("Сумма должна быть больше нуля!", "Валидация платежа",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Получить данные платежа с формы
        /// </summary>
        private PaymentOld GetFormPaymentData()
        {
            Settings.CurrentPaymentType = EditValue.PaymentType;
            Settings.CurrentVendor = EditValue.Vendor;

            return EditValue;
        }

 
    }

    /// <summary>
    /// Настройки формы
    /// </summary>
    public sealed class RecievePaymentsFormSettings
    {
        /// <summary>
        /// Доступный список видов платежей
        /// </summary>
        public List<PaymentType> AvailablePaymentTypes { get; set; }

        /// <summary>
        /// Текущий вид платежа
        /// </summary>
        public PaymentType CurrentPaymentType { get; set; }

        /// <summary>
        /// Доступный список поставщиков
        /// </summary>
        public List<Vendor> AvailableVendors { get; set; }

        /// <summary>
        /// Текущий поставщик
        /// </summary>
        public Vendor CurrentVendor { get; set; }

        public bool IsMultiMode { get; set; }
    }
}
