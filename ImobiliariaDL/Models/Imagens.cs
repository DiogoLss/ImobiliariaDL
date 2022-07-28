namespace ImobiliariaDL.Models
{
    public class Imagens
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public int ImovelId { get; set; }
        public Imovel Imovel { get; set; }
    }
}
