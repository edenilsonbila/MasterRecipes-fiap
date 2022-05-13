using MasterRecipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRecipes.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);

        T FindByID(long id);

        List<T> FindAll();

        void Delete(long id);

        bool Exists(long id);
    }
}
