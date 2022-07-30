using System.ComponentModel.DataAnnotations;

namespace ImobiliariaDL.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe a cidade do imóvel")]
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
        public int ImovelId { get; set; }
        public Imovel Imovel { get; set; }
    }
}
