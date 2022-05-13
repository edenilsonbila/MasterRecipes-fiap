using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRecipes.Domain.Models
{
    public class Categoria : BaseEntity
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }
    }
}
