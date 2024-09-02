using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public Task<Categoria> CreateAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> RemoveAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> UpdateAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
