using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data
{
    public interface IRepository : IDisposable
    {
        void Add<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        
        void SaveChanges();
    }
}
