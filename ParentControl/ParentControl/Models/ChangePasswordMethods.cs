using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParentControl.Models
{
    class ChangePasswordMethods
    {
        public bool ChangePasswordInDb(UserInfoModel user, string[] passwords)
        {
            if (passwords[0].Equals(user.Password) && passwords[1].Equals(passwords[2]))
            {
                AddNewPasswordToDb(user, passwords[1]);
                MessageBox.Show("Password successfully changed");
                return true;
            }
            else
                return false;               
        }

        public void AddNewPasswordToDb(UserInfoModel user, string password)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                UserInfoModel userFromDb = unit.userInfoModels.GetByEmail(user.Email);
                userFromDb.Password = password;
                unit.Save();
            }
        }
    }
}
