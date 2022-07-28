namespace ImobiliariaDL.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string ImagemString { get; set; }
        public int ImovelId { get; set; }
        public Imovel Imovel { get; set; }
    }
}
