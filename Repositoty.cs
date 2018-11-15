using JKCS.SM.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace JKCS.SM.Repository
{
   public class Repository<T> : IRepository<T> where T : class
    {
        //private ILogger _logger;
        private readonly SMDbContext _context;

        // [InjectionConstructor]
        public Repository()   //ILogger _logger
        {
            _context = new SMDbContext();

           
        }
        // InsuranceDBContext _context = new InsuranceDBContext();
        public bool Create(T obj)
        {
           // _logger.LogError("Test Error Log******");
            try
            {
                _context.Set<T>().Add(obj);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool Delete(T obj)
        {
            try
            {
                _context.Set<T>().Remove(obj);
                return true;
            }
            catch (Exception edb)
            {
                return false;
            }
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault<T>(predicate);
        }

        public List<T> FindList(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where<T>(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception edb)
            {
                return false;
            }
        }

        //public bool Save(T obj)
        //{
        //    try
        //    {
        //        _context.Set<T>().Add(obj);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception edb)
        //    {
        //        return false;
        //    }
        //}

        public bool Update(T obj)
        {
            try
            {
                var edbstate = _context.Entry(obj);
                _context.Set<T>().Attach(obj);
                edbstate.State = EntityState.Modified;
                return true;
            }
            catch (Exception edb)
            {
                return false;
            }
        }
    }
}
