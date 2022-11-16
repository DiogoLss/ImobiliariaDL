using ImobiliariaDL.Models;

namespace ImobiliariaDL.Areas.Admin.ViewModelsAdmin
{
    public class AddImovelVM
    {
        public Imovel Imovel { get; set; }
        public IFormFile? File { get; set; }
        //public string ImovelStringTest { get; set; }

        //public AddImovelVM()
        //{
        //    Imovel = new Imovel();
        //}
    }
}
