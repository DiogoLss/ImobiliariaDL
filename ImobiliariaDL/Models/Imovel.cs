using ImobiliariaDL.Repository;
using ImobiliariaDL.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImobiliariaDL.Models
{
    public class Imovel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required]
        public byte[] ImagemThumb { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Required]
        [Display(Name ="Valor")]
        public decimal Preco { get; set; }
        [Required]
        [Range(1,100,ErrorMessage ="A quantidade de {0} deve ser entre {1} e {2}")]
        public int Quartos { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "A quantidade de {0} deve ser entre {1} e {2}")]
        public int Banheiros { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "A quantidade de {0} deve ser entre {1} e {2}")]
        public int Salas { get; set; }
        [Range(0, 100, ErrorMessage = "A quantidade de {0} deve ser entre {1} e {2}")]
        public int Garagens { get; set; }
        [Required]
        public bool ECondominioOuApartamento { get; set; }
        public int? NumeroDoApCd { get; set; }

        //ENDERECO
        [Required]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Informe o bairro do imóvel")]
        public string? Bairro { get; set; }
        [Required(ErrorMessage = "Informe a rua do imóvel}")]
        public string? Rua { get; set; }
        [Required(ErrorMessage = "Informe o número do imóvel}")]
        public int? Numero { get; set; }
        [Required]
        [StringLength(16)]
        public string CEP { get; set; }
        public List<Imagem> Imagens { get; set; }


        //public ImoveisVM Imoveis(IUnitOfWork _uf)
        //{
        //    var imovelVM = new ImoveisVM();
        //    var imoveis = _uf.Imoveis.Get().ToList();

        //    for (int i = 0; i < imoveis.Count; i++)
        //    {
        //        List<Imagem> imagensList = new List<Imagem>();
        //        imagensList = _uf.Imagens.GetImagensImovel(imoveis[i].Id).ToList();
        //        imoveis[i].Imagens = imagensList;
        //    }
        //    imovelVM.Imoveis = imoveis;
        //    return imovelVM;
        //} POSSIVEL MUDANÇA
    }
}
