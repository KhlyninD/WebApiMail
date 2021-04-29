using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMail.DbModels;

namespace WebApiMail.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);

        IEnumerable<T> FindAll();
    }
}
