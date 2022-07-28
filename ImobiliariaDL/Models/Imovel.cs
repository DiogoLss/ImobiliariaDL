namespace ImobiliariaDL.Models
{
    public class Imovel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quartos { get; set; }
        public int Banheiros { get; set; }
        public int Salas { get; set; }
        public int Garagens { get; set; }
    }
}
