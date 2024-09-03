using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DbContext _context;

        public ProdutoRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _context.Set<Produto>().ToListAsync();
        }

        public async Task<Produto> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Set<Produto>().FindAsync(id);
        }

        public async Task<Produto> CreateAsync(Produto produto)
        {
            _context.Set<Produto>().Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> UpdateAsync(Produto produto)
        {
            _context.Set<Produto>().Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> RemoveAsync(Produto produto)
        {
            _context.Set<Produto>().Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
    }
}
