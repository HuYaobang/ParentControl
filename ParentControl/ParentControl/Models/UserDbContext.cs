using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ParentControl.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() : base("DefaultConnection") { }

        public DbSet<UserInfoModel> UserInfoModels { get; set; }
    }
}
