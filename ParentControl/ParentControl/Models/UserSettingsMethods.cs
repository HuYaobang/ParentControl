using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ParentControl.Models
{
    class UserSettingsMethods
    {
        private const string name = "ParentControl";

        public UserInfoModel GetUserSettingsFromDb(UserInfoModel user)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                return unit.userInfoModels.GetByEmail(user.Email);
            }
        }

        public bool SaveUserSettingsInDb(UserInfoModel user)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                unit.userInfoModels.Update(user);
                unit.Save();
                return true;
            }
        }

        public void CheckAutoStart(bool autoStart)
        {
            string ExePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            if (autoStart)
                reg.SetValue(name, ExePath);
            else
            {
                try { reg.DeleteValue(name); }
                catch { }
            }
           
        }
    }
}
