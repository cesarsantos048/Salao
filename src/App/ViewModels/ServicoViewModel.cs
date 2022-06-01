using App.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.ViewModels
{
    public class ServicoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [DisplayName("Cliente")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório!")]
        [StringLength(200, ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public decimal Valor { get; set; }

        [DisplayName("Pagamento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [DisplayName("Realizado")]
        [DataType(DataType.DateTime, ErrorMessage = "Data em formato inválido")]
        public DateTime DataServico { get; set; }


        [DisplayName("Data de cadastro")]
        public DateTime DataCadastro { get; set; }

        [NotMapped]
        public ClienteViewModel Cliente { get; set; }
        [NotMapped]
        public IEnumerable<ClienteViewModel> Clientes { get; set; }

        public ServicoViewModel()
        {
            DataServico = DateTime.Today.Date;
        }
    }
}
