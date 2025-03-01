using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiLoja.Models
{
    [Table("CarrinhoProdutos")]
    public class CarrinhoProdutos
    {
        [Key]
        public int CarrinhoProdutosId { get; set; }

        [Required]
        [ForeignKey("Carrinho")]
        public int CarrinhoId { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        [JsonIgnore]
        public Carrinho? Carrinho { get; set; }

        
        [JsonIgnore]
        public Produto? Produto { get; set; }
    }
}
