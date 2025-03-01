using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiLoja.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set;}

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        
        [Required]
        [StringLength(80)]
        public string? Marca { get; set; }


        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }


        [Required]
        [Column(TypeName = "double(10,2)")]
        public double Preco { get; set; }

        [Required]
        [StringLength(80)]
        public string? ImagemUrl { get; set; }
        

        [Required]  
        public List<Categoria> Categorias { get; set; } = new List<Categoria>();    
       

       [JsonIgnore]
        public List<CarrinhoProdutos> CarrinhoProdutos { get; set; } = new List<CarrinhoProdutos>();


    }
}
