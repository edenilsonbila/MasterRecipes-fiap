using Microsoft.AspNetCore.Mvc;
using MasterRecipes.Data.Context;
using MasterRecipes.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Configuration;

namespace MasterRecipes.Mvc.Controllers
{
    public class ReceitaController : Controller
    {
        protected Context _ctx;
        private IWebHostEnvironment Environment;

        public ReceitaController(Context context, IWebHostEnvironment _environment)
        {
            _ctx = context;
            Environment = _environment;
        }

        public IActionResult Nova()
        {
            ViewBag.Categorias = _ctx.Categorias.Select(c => new SelectListItem()
            { Text = c.Titulo.ToUpper(), Value = c.Id.ToString() }).ToList();

            return View(new Receita());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Nova(Receita receita)
        {
            foreach (var item in Request.Form["Tags"].ToString().Split(","))
            {
                receita.Tags.Add(new ReceitaTags()
                {
                    Tag = item.ToString()
                });
            }

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                Formatting = Formatting.None,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };

            var igredientes = JsonConvert.DeserializeObject<IList<ReceitaIgrediente>>(Request.Form["Igredientes"].ToString(), settings);

            foreach (var item in igredientes)
            {
                receita.Igredientes.Add(item);
            }


            _ctx.Add(receita);
            await _ctx.SaveChangesAsync();
            return Ok(receita.Id);
        }

        [HttpPost]
        public async Task<IActionResult> Imagens(List<FormFile> arquivos,int modelId)
        {
            var files = Request.Form.Files;
            long size = files.Sum(f => f.Length);

            var path = Path.Combine(Environment.WebRootPath, @"img\uploaded");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var indice = 0;
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var fileName = formFile.FileName;

                    var filePath = Path.Combine(path, fileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    var receitaImagem = new ReceitaImagem()
                    {
                        ReceitaId = modelId,
                        Source = fileName,
                        Principal = indice == 0 ? "S" : "N"
                    };
                    _ctx.ReceitaImagens.Add(receitaImagem);
                }
            }
            _ctx.SaveChanges();

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size });
        }

        public IActionResult Visualizar(int id)
        {
            if (id == 0)
                return BadRequest();

            var receita = _ctx.Receitas.Find(id);

            return View(receita);
        }

        public IActionResult Imagens(int id)
        {
            var receita = _ctx.Receitas.Find(id);

            return View(receita);
        }

        public IActionResult View()
        {
            return View(new Receita());
        }
    }
}
