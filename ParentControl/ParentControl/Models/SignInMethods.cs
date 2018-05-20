using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParentControl.Models
{
    class SignInMethods
    {
        public bool SignInSuccess(string[] data)
        {
            if (TryGetUser(new UserInfoModel { Email = data[0], Password = data[1] }))
                return true;
            else
                return false;
        }

        public bool TryGetUser(UserInfoModel user)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                if (unit.userInfoModels.GetByEmail(user.Email) != null)
                    return true;
                else
                {
                    MessageBox.Show("Неверные логин и(или) пароль.");
                    return false;
                }                   
            }
        }

        public bool ConfirmUserLogIn(UserInfoModel user, string password)
        {
            if (password.Equals(user.Password))
                return true;
            else
                return false;
        }

    }
}
