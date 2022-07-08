using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }

    }
}
