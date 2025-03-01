using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace ApiLoja.Models
{
    [Table("Carrinho")]
    public class Carrinho
    {
       


        [Key]
        public int CarrinhoId { get; set; }


        [JsonIgnore]
        public User? User { get; set; }

  
        public List<CarrinhoProdutos> CarrinhoProdutos { get; set; } = new List<CarrinhoProdutos>();



    }
}
