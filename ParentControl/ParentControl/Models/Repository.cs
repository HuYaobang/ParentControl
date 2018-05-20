using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentControl.Models
{
    interface IRepository<T> where T : class
    {

        T Get(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);
    }
}
