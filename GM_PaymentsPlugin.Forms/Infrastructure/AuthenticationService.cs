using GM_PaymentsPlugin.DataLayer.Entities;
using GM_PaymentsPlugin.Forms.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GM_PaymentsPlugin.Forms.Infrastructure
{

    public struct LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    
    public class AuthenticationService
    {


        public AuthenticationService(SettingService settingService)
        {
            _settingService = settingService;
        }
        
        private static User _currentUser;
        private SettingService _settingService;
        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
        }

        public bool IsRegistered
        {
            get
            {
                if (_currentUser != null)
                {
                    return true;
                }
                else return false;
            }
            
        }


        public LoginResult Login(User user)
        {

            using (var command = new GetPayKindCommand(_settingService.GetServerIP(), _settingService.GetPort(),user))
            {
                command.Execute();
                if (!command.Success)
                {
                    return new LoginResult { Message = command.ErrorMessage, Success = false };
                }
                else
                {
                    PaymentService.InitData(command.Vendors, command.VendorServices);
                    user.PostIndex = command.PostIndex;
                }
                    
            }

            _currentUser = user;

            
            return new LoginResult { Message="",Success=true};
        }


        public void Logout()
        {
            _currentUser = null;
        }





    }
}
