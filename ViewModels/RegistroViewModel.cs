using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "Preencha o nome")]
        [Display(Name = "Nome")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "Preencha o email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Preencha a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Preencha a confirmação da senha")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de Senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}