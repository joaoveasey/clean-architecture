using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.Repositories
{
    internal class ProdutoRepository : IProdutoRepository
    {
        public Task<Produto> CreateAsync(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Produto> RemoveAsync(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> UpdateAsync(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
