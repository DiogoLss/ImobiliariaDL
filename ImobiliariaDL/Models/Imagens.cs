﻿using System.ComponentModel.DataAnnotations;

namespace ImobiliariaDL.Models
{
    public class Imagem
    {
        public int? Id { get; set; }
        [Required]
        public byte[] ImagemString { get; set; }
        public int ImovelId { get; set; }
        public Imovel Imovel { get; set; }
    }
}
