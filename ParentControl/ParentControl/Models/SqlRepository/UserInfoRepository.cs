using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentControl.Models.SqlRepository
{
    public class UserInfoRepository : IRepository<UserInfoModel>
    {
        private UserDbContext db;

        public UserInfoRepository(UserDbContext context)
        {
            this.db = context;
        }

        public UserInfoModel Get(int id)
        {
            return db.UserInfoModels.Find(id);
        }

        public UserInfoModel GetByEmail(string Email)
        {
            return db.UserInfoModels.Where(u => u.Email == Email).FirstOrDefault();
        }

        public void Create(UserInfoModel userInfoModel)
        {
            db.UserInfoModels.Add(userInfoModel);
        }

        public void Update(UserInfoModel userInfoModel)
        {
            db.Entry(userInfoModel).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            UserInfoModel userInfoModel = db.UserInfoModels.Find(id);
            if (userInfoModel != null)
                db.UserInfoModels.Remove(userInfoModel);
        }
    }
}
