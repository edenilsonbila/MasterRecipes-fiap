using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterRecipes.Domain.Interfaces;
using MasterRecipes.Domain.Models;
using MasterRecipes.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MasterRecipes.Data.Repositorys
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected Context.Context _context;
        private DbSet<T> _dataset;

        public BaseRepository(Context.Context context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(long id)
        {
            throw new NotImplementedException();
        }

        public List<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public T FindByID(long id)
        {
            throw new NotImplementedException();
        }

        public T Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
