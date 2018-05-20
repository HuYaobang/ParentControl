using ParentControl.Models.SqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentControl.Models
{
    public class UnitOfWork : IDisposable
    {
        private UserDbContext db = new UserDbContext();
        private UserInfoRepository userInfoRepository;

        public UserInfoRepository userInfoModels
        {
            get
            {
                return userInfoRepository ?? (userInfoRepository = new UserInfoRepository(db));
            }
        }
        

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
