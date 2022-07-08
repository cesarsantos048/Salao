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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MeuDbContext context) : base(context) {}

        public async Task<Cliente> ObterClienteServicos(Guid id)
        {
            return await Db.Clientes.AsNoTracking()
                .Include(c => c.Servicos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cliente>> Ordenar(int skip, int take)
        {
            return await Db.Clientes
                .AsNoTracking()
                .OrderBy(p => p.Nome)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
        public async Task<int> Total()
        {
            return await Db.Clientes.CountAsync();
        }
    }
}
