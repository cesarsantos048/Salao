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
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context) { }

        public Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ObterProdutosPorCategoria(Guid categoriaId)
        {
            throw new NotImplementedException();
        }
    }
}
