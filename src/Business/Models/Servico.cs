using System;

namespace Business.Models
{
    public class Servico :Entity
    {
        public Guid ClienteId { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }

        public DateTime DataServico { get; set; }

        public DateTime DataCadastro { get; set; }

        public Cliente Cliente { get; set; }
    }
}
