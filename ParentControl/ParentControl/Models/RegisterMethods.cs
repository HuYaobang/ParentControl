using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ParentControl.Models
{
    class RegisterMethods
    {
        public bool Register(UserInfoModel user, string[] data)
        {
            if (PasswordConfirmation(data) && FindEmailInDb(user) && EmailValidator(user.Email))
                return AddNewUserToDb(user);
            else
                return false;
        }

        public bool EmailValidator(string email)
        {
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            if (Regex.IsMatch(email, emailPattern))
                return true;
            else
            {
                MessageBox.Show("Укажите верный формат электронной почты.");
                return false;
            }
        }

        public bool PasswordConfirmation(string[] data)
        {
            if (data[0].Equals(data[1]))
                return true;
            else
            {
                MessageBox.Show("Пароли не совпадают.");
                return false;
            }                
        }

        public bool FindEmailInDb(UserInfoModel user)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                if (unit.userInfoModels.GetByEmail(user.Email) == null)
                    return true;
                else
                {
                    MessageBox.Show("Почта уже занята.");
                    return false;
                }
            }
        }

        public bool AddNewUserToDb(UserInfoModel user)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                unit.userInfoModels.Create(user);
                unit.Save();
                return true;
            }
        }
    }
}
