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
        public IActionResult NovoImovel(AddImovelVM imovel, List<IFormFile> files)
        {
            //imovel.Imovel = JsonConvert.DeserializeObject<Imovel>(imovel.ImovelDescription);
            var random = new Random();
            int id = random.Next(1, 1000000);
            if (imovel.EApartamento && imovel.ECondominio)
            {
                //ViewData["Erro"] = "Escolha entre apartamento ou condominio";
                return View();
            }
            Imovel imovelAdd = new Imovel()
            {
                Id = id,
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
            if (files != null)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    if (i == 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            files[i].CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            imovelAdd.ImagemThumb = fileBytes;

                            _uf.Imoveis.Adicionar(imovelAdd);
                            _uf.Commit();
                        }
                    }
                    else
                    {
                        using (var ms = new MemoryStream())
                        {
                            files[i].CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            var imagem = new Imagem()
                            {
                                ImovelId = id,
                                ImagemString = fileBytes,
                            };
                            _uf.Imagens.Adicionar(imagem);
                            _uf.Commit();
                        }
                    }
                }
                return View();
                //return RedirectToAction("Index", "Home");
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
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    Imagem imagem = new Imagem()
                    {
                        ImovelId=idImovel,
                        ImagemString=fileBytes
                    };
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
