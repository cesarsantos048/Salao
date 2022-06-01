using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<IEnumerable<Cliente>> Ordenar()
        {
            return await Db.Clientes.AsNoTracking()
                 .OrderBy(p => p.Nome).ToListAsync();
        }
    }
}
