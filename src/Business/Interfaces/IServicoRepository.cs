using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IServicoRepository : IRepository<Servico>
    {
        Task<IEnumerable<Servico>> ObterServicosPorCliente(Guid clienteId);
        Task<IEnumerable<Servico>> ObterServicosClientes();
        Task<Servico> ObterServicoCliente(Guid id);

        Task<List<Servico>> BuscarPorData(DateTime? minDate, DateTime? maxDate);
    }
}
