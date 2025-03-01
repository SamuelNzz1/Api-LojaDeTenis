using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace ApiLoja.Models
{
    [Table("Users")]
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [StringLength(80)]

        public string? UserName { get; set; }

        [Required(ErrorMessage = "O nome de é obrigatório")]
        [StringLength(80)]

        public string? Name { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres.")]
        public string? Password { get; set; }



        [JsonIgnore]
        public Carrinho? Carrinho { get; set; }




    }
}
