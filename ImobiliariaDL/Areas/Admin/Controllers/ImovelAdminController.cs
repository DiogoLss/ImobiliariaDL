using ImobiliariaDL.Areas.Admin.ViewModelsAdmin;
using ImobiliariaDL.Models;
using ImobiliariaDL.Repository;
using ImobiliariaDL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ImobiliariaDL.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ImovelAdminController : Controller
    {
        private readonly IUnitOfWork _uf;
        public ImovelAdminController(IUnitOfWork uf)
        {
            _uf = uf;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NovoImovel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NovoImovel(AddImovelVM imovel)
        {
            //imovel.Imovel = JsonConvert.DeserializeObject<Imovel>(imovel.ImovelDescription);

            if (imovel.Imovel.EApartamento && imovel.Imovel.ECondominio)
            {
                ViewData["Erro"] = "Escolha entre apartamento ou condominio";
                return View(ViewData);
            }

            if (imovel.File != null)
            {
                using (var ms = new MemoryStream())
                {
                    imovel.File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    imovel.Imovel.ImagemThumb = fileBytes;

                    _uf.Commit();

                    return View(imovel.Imovel);
                }
            }
            else
            {
                //ViewData["Erro"] = "Nenhuma foto selecionada";
                return View();
            }
        }
        
        [HttpPost]
        public void SalvarImagensImovel(List<IFormFile> files, int idImovel)
        {
            List<Imagem> imagens = new List<Imagem>();
            foreach (IFormFile file in files)
            {
                using(var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    Imagem imagem = new Imagem(fileBytes, idImovel);
                    imagens.Add(imagem);
                }
            }
        }
        [HttpGet]
        public JsonResult ImoveisAdm()
        {
            var imovelVM = new ImoveisVM();
            var imoveis = _uf.Imoveis.Get().ToList();

            for (int i = 0; i < imoveis.Count; i++)
            {
                imoveis[i].Imagens = _uf.Imagens.GetImagensImovel(imoveis[i].Id).ToList();
            }
            imovelVM.Imoveis = imoveis;
            return Json(imovelVM);
        }
    }
}
