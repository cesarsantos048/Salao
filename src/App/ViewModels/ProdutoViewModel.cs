using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }
         [DisplayName("Fornecedor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public int Unidade { get; set; }

        [DisplayName("Preço de compra")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public decimal PrecoCompra { get; set; }

        [DisplayName("Preço de venda")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public decimal PrecoVenda { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public int Estoque { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [DisplayName("Categoria")]
        public Guid CategoriaId { get; set; }

        public CategoriaViewModel Categoria { get; set; }
        [NotMapped]
        public IEnumerable<CategoriaViewModel> Categorias { get; set; }





    }
}
