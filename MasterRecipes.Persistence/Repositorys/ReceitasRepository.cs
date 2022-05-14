using MasterRecipes.Domain.Interfaces;
using MasterRecipes.Domain.Models;
using MasterRecipes.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRecipes.Data.Repositorys
{
    //Aqui é onde é implementado os comandos proprios desta entidade
    public class ReceitasRepository : BaseRepository<Receita>, IReceitasRepository
    {
        public ReceitasRepository(MasterRecipes.Data.Context.Context context) : base(context)
        {

        }
    }
}
