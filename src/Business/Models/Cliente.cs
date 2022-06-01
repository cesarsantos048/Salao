using System.Collections.Generic;

namespace Business.Models
{
    public class Cliente : Entity
    {

        public string Nome { get; set; }

        public string Apelido { get; set; }
        
        public string Telefone { get; set; }

        public IEnumerable<Servico> Servicos { get; set; }

    }
}
