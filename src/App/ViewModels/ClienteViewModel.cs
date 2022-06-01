using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string _nome;
        public string Nome
        {
            get {
                
                
                return _nome.Length > 1 ? char.ToUpper(_nome[0]) + _nome.Substring(1) : _nome.ToUpper(); }
            set { _nome = value; }
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 9)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Apelido { get; set; }

        public IEnumerable<ServicoViewModel> Servicos { get; set; }
    }
}
