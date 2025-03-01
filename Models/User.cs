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

        [Required]
        [StringLength(80)]

        public string? UserName { get; set; }

        [Required]
        [StringLength(80)]

        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? Password { get; set; }

        [Required]
        [ForeignKey("Carrinho")]
        public int CarrinhoId { get; set; }

        [JsonIgnore]
        public Carrinho? Carrinho { get; set; }

        
               

    }
}
