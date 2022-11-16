using System.ComponentModel.DataAnnotations;

namespace ImobiliariaDL.Models
{
    public class Imagem
    {
        public Imagem()
        {
        }
        public Imagem(byte[] img, int imovelId)
        {
            ImagemString = img;
            ImovelId = imovelId;
        }
        public int Id { get; set; }
        [Required]
        public byte[] ImagemString { get; set; }
        public int ImovelId { get; set; }
        public Imovel Imovel { get; set; }
    }
}
