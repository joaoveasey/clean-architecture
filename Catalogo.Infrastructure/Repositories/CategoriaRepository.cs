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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DbContext _context;

        public CategoriaRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            return await _context.Set<Categoria>().ToListAsync();
        }

        public async Task<Categoria> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Set<Categoria>().FindAsync(id);
        }

        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            _context.Set<Categoria>().Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> UpdateAsync(Categoria categoria)
        {
            _context.Set<Categoria>().Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> RemoveAsync(Categoria categoria)
        {
            _context.Set<Categoria>().Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
    }
}
