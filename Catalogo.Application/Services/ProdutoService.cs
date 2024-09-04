using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtosEntity = _produtoRepository.GetProdutosAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtosEntity);
        }

        public async Task<ProdutoDTO> GetById(int? id)
        {
            var produtoEntity = await _produtoRepository.GetByIdAsync(id.Value);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }

        public async Task Add(ProdutoDTO produtoDTO)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.CreateAsync(produtoEntity);
        }

        public async Task Update(ProdutoDTO produtoDTO)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.UpdateAsync(produtoEntity);
        }

        public async Task Remove(int? id)
        {
            var produtoEntity = await _produtoRepository.GetByIdAsync(id.Value);
            await _produtoRepository.RemoveAsync(produtoEntity);
        }
    }
}
