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
            var imoveis = _uf.Imoveis.Get();
            var imagensImovel = _uf.Imagens.Get();
            imovelVM.Imoveis = imoveis;
            imovelVM.Imagens = imagensImovel;
            return View(imovelVM);
        }
    }
}
