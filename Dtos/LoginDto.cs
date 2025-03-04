using System.ComponentModel.DataAnnotations;    
namespace ApiLoja.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "O campo Nome de usuário é obrigatório.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo de Senha é obrigatório.")]
        [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres.")]
        public string Password { get; set; }

    }
}
