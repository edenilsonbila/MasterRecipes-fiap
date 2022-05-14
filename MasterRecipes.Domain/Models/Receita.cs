using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRecipes.Domain.Models
{
    public class Receita : BaseEntity
    {
        public Receita()
        {
            DataCadastro = DateTime.Now;
            Igredientes = new List<ReceitaIgrediente>();
            Imagens = new List<ReceitaImagem>();
            Tags = new List<ReceitaTags>();
        }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public int CategoriaId { get; set; }

        public int TempoPreparo { get; set; }

        public string Dificuldade { get; set; }

        public string ModoPreparo { get; set; }

        public DateTime DataCadastro { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<ReceitaIgrediente> Igredientes { get; set; }

        public virtual ICollection<ReceitaImagem> Imagens { get; set; }

        public virtual ICollection<ReceitaTags> Tags { get; set; }
    }
}
