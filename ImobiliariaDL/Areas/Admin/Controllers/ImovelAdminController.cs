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
        public IActionResult NovoImovel(AddImovelVM imovel, IFormFile file)
        {
            //imovel.Imovel = JsonConvert.DeserializeObject<Imovel>(imovel.ImovelDescription);
            if (imovel.EApartamento && imovel.ECondominio)
            {
                //ViewData["Erro"] = "Escolha entre apartamento ou condominio";
                return View();
            }
            Imovel imovelAdd = new Imovel()
            {
                Nome = imovel.Nome,
                Preco = imovel.Preco,
                Quartos = imovel.Quartos,
                Banheiros = imovel.Banheiros,
                Salas = imovel.Salas,
                Garagens = imovel.Garagens,
                ECondominio = imovel.ECondominio,
                EApartamento = imovel.EApartamento,
                NumeroDoApCd = imovel.NumeroDoApCd,
                Cidade = imovel.Cidade,
                Bairro = imovel.Bairro,
                Rua = imovel.Rua,
                Numero = imovel.Numero,
                CEP = imovel.CEP
            };
            if (file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    imovelAdd.ImagemThumb = fileBytes;

                    _uf.Imoveis.Adicionar(imovelAdd);
                    _uf.Commit();

                    return View(imovel);
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
