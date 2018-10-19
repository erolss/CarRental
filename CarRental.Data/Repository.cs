using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data
{
    public class Repository : IRepository
    {
        private CarRentalContext context;

        public CarRentalContext Context
        {
            get
            {
                return context;
            }
        }

        public Repository() : this(new CarRentalContext())
        {
        }
        
        public Repository(CarRentalContext ctx)
        {
            context = ctx;
        }

        public virtual void Add<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
        }

        public virtual void AddRange<T>(ICollection<T> entities) where T : class
        {
            context.Set<T>().AddRange(entities);
        }

        public virtual void Remove<T>(T entity) where T : class
        {
            context.Set<T>().Remove(entity);
        }

        public virtual void RemoveRange<T>(ICollection<T> entities) where T : class
        {
            context.Set<T>().RemoveRange(entities);
        }
        
        public  IQueryable<T> DataSet<T>() where T : class {
            return context.Set<T>();
        }
        public virtual ICollection<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return Context.Set<T>().Where(predicate).ToList<T>();
        }
        
        public virtual void SaveChanges() {
            context.SaveChanges();
        }
        
    }
}
