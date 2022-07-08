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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(MeuDbContext context) : base(context) { }

        public async Task<Categoria> ObterCategoriaProdutos(Guid id)
        {
            return await Db.Categorias.AsNoTracking()
                .Include(c => c.Produtos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Categoria>> ObterCategoriaProdutos()
        {
            return await Db.Categorias.AsNoTracking()
                .Include(f => f.Produtos)
                .ToListAsync();
        }
    }
}
