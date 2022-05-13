using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRecipes.Domain.Models
{
    public class Receita : BaseEntity
    {

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public virtual ICollection<ReceitaIgrediente> Igredientes { get; set; }

        public virtual ICollection<ReceitaImagem> Imagens { get; set; }

        public virtual ICollection<ReceitaTags> Tags { get; set; }
    }
}
