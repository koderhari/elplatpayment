using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using GM_PaymentsPlugin.DataLayer;
using GM_PaymentsPlugin.DataLayer.Entities;
using GM_PaymentsPlugin.Forms;
using GM_PluginCommon.Payments;
using GM_PaymentsPlugin.Forms.Infrastructure;

namespace GM_PaymentsPlugin.PaymentsPlugin.Helpers
{
    public static class AutorizationHelper
    {

        public static bool CheckAutorizaton()
        {
            var result = false;
            var setServ = new SettingService();
            var authService = new AuthenticationService(setServ);
            //var paymentService = new PaymentService();
            if (authService.IsRegistered) return true;

            using (var form = new AutorizationForm(authService))
            {
                form.ShowDialog();
                result = form.IsAutorizationSuccess;
            }

            return result;
        }

    }
}
