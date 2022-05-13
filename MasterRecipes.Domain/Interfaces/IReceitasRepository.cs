using MasterRecipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRecipes.Domain.Interfaces
{
    //Aqui é onde é mapeado os comando proprios desta entidade
    public interface IReceitasRepository : IBaseRepository<Receita>
    {

    }
}
