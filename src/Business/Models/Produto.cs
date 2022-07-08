using Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class Produto : Entity
    {

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public TipoUnidade Unidade { get; set; }

        public decimal PrecoCompra { get; set; }

        public decimal PrecoVenda { get; set; }

        public int Estoque { get; set; }

        public bool Status { get; set; }

        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }
}
