using ImobiliariaDL.Models;
using ImobiliariaDL.Repository;
using ImobiliariaDL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ImobiliariaDL.Controllers
{
    public class ImovelController : Controller
    {
        private readonly IUnitOfWork _uf;
        public ImovelController(IUnitOfWork uf)
        {
            _uf = uf;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("imoveis")]
        public IActionResult Imoveis()
        {
            var imovelVM = new ImoveisVM();
            var imoveis = _uf.Imoveis.Get().ToList();

            for(int i = 0; i < imoveis.Count; i++)
            {
                List<Imagem> imagensList = new List<Imagem>();
                imagensList = _uf.Imagens.GetImagensImovel(imoveis[i].Id).ToList();
                imoveis[i].Imagens = imagensList;
            }
            //foreach (var imovel in imoveis.ToList())
            //{
            //    List<Imagem> imagensList = new List<Imagem>();
            //    imagensList = _uf.Imagens.GetImagensImovel(imovel.Id).ToList();
            //    imovel.Imagens = imagensList;
            //}
            imovelVM.Imoveis = imoveis;
            return View(imovelVM);
        }
    }
}
