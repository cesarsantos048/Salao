using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClienteServicos(Guid id);
        Task<IEnumerable<Cliente>> Ordenar(int skip, int take);

        Task<int> Total();
    }
}
