using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRecipes.Domain.Models
{
    public class ReceitaTags
    {
        public int Id { get; set; }

        public string Tag { get; set; }

        public int ReceitaId { get; set; }
    }
}
