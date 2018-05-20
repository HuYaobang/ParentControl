using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using ParentControl.Views;

namespace ParentControl.Models
{
    class EmailConfirmationMethods
    {
        public int GenerateConfirmationKey()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }

        public void SendEmail(UserInfoModel user, int confirmationKey)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.Credentials = new NetworkCredential("Essay.storage1337@gmail.com", "rodionegor1337");
                client.EnableSsl = true;
                client.Send(GenerateMessage(user, confirmationKey));
            }
        }

        public MailMessage GenerateMessage(UserInfoModel user, int confirmationKey)
        {
            MailMessage message = new MailMessage
                (
                    new MailAddress("Essay.storage1337@gmail.com", "ParentControl administration"),
                    new MailAddress(user.Email)
                );
            message.Subject = "Email confirmation";
            message.Body = String.Format("Пожалуйста, используйте этот код для подтверждения Вашей почты:\n\t{0}", confirmationKey);
            return message;
        }

        public bool UpdateConfirmationStatus(UserInfoModel user)
        {
            user.IsEmailConfirmed = true;
            using (UnitOfWork unit = new UnitOfWork())
            {
                unit.userInfoModels.Update(user);
                unit.Save();
                return true;
            }
        }

        public bool UserEmailConfirmed(UserInfoModel user)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                if (unit.userInfoModels.GetByEmail(user.Email).IsEmailConfirmed)
                    return true;
                else
                    return false;
            }
        }

        public void RedirectToEmailConfirmation(UserInfoModel user)
        {
            EmailConfirmationWindow emailConfirmationWindow = new EmailConfirmationWindow(user);
            emailConfirmationWindow.Show();            
        }
    }
}
