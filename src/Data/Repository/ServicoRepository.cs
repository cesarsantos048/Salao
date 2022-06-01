using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(MeuDbContext context) : base(context){}

        public async Task<List<Servico>> BuscarPorData(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in Db.Servicos select obj;
            if(minDate.HasValue)
            {
                result = result.Where(x => x.DataServico >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.DataServico >= maxDate.Value);
            }


            return await result
                .Include(x=> x.Cliente)
                .OrderByDescending(x => x.DataServico)
                .ToListAsync();
        }

        public async Task<Servico> ObterServicoCliente(Guid id)
        {
            return await Db.Servicos.AsNoTracking()
               .Include(f => f.Cliente)
               .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IEnumerable<Servico>> ObterServicosClientes()
        {
            return await Db.Servicos.AsNoTracking()
                .Include(f => f.Cliente)
                .OrderByDescending(p => p.DataServico ).ToListAsync();
        }

        public async Task<IEnumerable<Servico>> ObterServicosPorCliente(Guid clienteId)
        {
            return await Buscar(p => p.ClienteId == clienteId);
        }

    }
}
