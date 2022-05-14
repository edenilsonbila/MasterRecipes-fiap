using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRecipes.Domain.Models
{
    public class ReceitaImagem
    {
        public int Id { get; set; }

        public string Source { get; set; }

        public int ReceitaId { get; set; }

        public string Principal { get; set; }
    }
}
