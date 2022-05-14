using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRecipes.Domain.Models
{
    [Table("Categoria")]
    public class Categoria : BaseEntity
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }
    }
}
