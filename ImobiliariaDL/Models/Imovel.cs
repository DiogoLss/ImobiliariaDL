using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImobiliariaDL.Models
{
    public class Imovel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required]
        [StringLength(300)]
        public string Descricao { get; set; }
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
    }
}
