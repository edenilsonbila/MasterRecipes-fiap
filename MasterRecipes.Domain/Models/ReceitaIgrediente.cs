using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRecipes.Domain.Models
{
    public class ReceitaIgrediente
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal Quantidade { get; set; }

        public string UnidadeMedida { get; set; }

        public int ReceitaId { get; set; }
    }
}
