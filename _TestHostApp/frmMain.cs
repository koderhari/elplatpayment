using System;
using System.Configuration;
using System.Windows.Forms;
using ElPlat_PaymentsPlugin.PaymentsPlugin;
using GM_PluginCommon.Payments;

namespace _TestHostApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaymentsPlugin plugin = new PaymentsPlugin();
            plugin.Host = new TestHost();

            var payments = plugin.RecievePayments(new RecievePaymentParameters()
            {
                IsMultiMode = false,
                PaymentType = PaymentType.Utility,
                ClientInfo = new ClientInfo(),
                VendorKeyInfo = new VendorKeyInfo() { INN = "8602067215", KPP = "997450001" }
            });

            MessageBox.Show(String.Format("Внесено {0} платежей", payments.Count));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PaymentsPlugin plugin = new PaymentsPlugin();
            plugin.Host = new TestHost();

            var payments = plugin.RecievePayments(new RecievePaymentParameters()
            {
                IsMultiMode = true,
                PaymentType = PaymentType.Utility,
                ClientInfo = new ClientInfo(),
                VendorKeyInfo = new VendorKeyInfo() { INN = "8602067215", KPP = "997450001" }
            });

            MessageBox.Show(String.Format("Внесено {0} платежей", payments.Count));

            if (payments.Count >= 2)
            {
                 plugin.PaymentConfirm(new PaymentKeyInfo() { PaymentId = payments[0].PaymentId });
                 plugin.PaymentCancel(new PaymentKeyInfo() { PaymentId = payments[1].PaymentId });
                //plugin.PaymentCancel(new PaymentKeyInfo() { PaymentId = payments[0].PaymentId });
            }
        }
    }

    public class TestHost : IPaymentsPluginHost
    {
        public bool IsScannerEnabled()
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString()
        {
            // Здесь задать строку подключения к БД... Базу создавать не нужно, плагин сам создаст базу в указанном каталоге
            //return "Data Source=SERGPC;Initial Catalog=PaymentsDB;Integrated Security=True;";
            return ConfigurationManager.ConnectionStrings["PluginDBConnection"].ConnectionString;
        }
    }
}
