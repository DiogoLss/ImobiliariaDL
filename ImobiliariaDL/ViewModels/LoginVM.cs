using System.ComponentModel.DataAnnotations;

namespace ImobiliariaDL.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Insira seu login ADM")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Insiria sua senha ADM")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
