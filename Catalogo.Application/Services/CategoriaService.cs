using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Interfaces;
using Catalogo.Domain.Entities;

namespace Catalogo.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categoriasEntity = await _categoriaRepository.GetCategoriasAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
        }

        public async Task<CategoriaDTO> GetById(int? id)
        {
            var categoriaEntity = await _categoriaRepository.GetByIdAsync(id.Value);
            return _mapper.Map<CategoriaDTO>(categoriaEntity);
        }

        public async Task Add(CategoriaDTO categoriaDTO)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.CreateAsync(categoriaEntity);
        }

        public async Task Update(CategoriaDTO categoriaDTO)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.UpdateAsync(categoriaEntity);
        }

        public async Task Remove(int? id)
        {
            var categoriaEntity = await _categoriaRepository.GetByIdAsync(id.Value);
            await _categoriaRepository.RemoveAsync(categoriaEntity);
        }
    }
}
