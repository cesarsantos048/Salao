using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<Categoria> ObterCategoriaProdutos(Guid id);


        Task<IEnumerable<Categoria>> ObterCategoriaProdutos();
    }
}
