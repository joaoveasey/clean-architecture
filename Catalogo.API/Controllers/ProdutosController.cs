using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController(IProdutoService ProdutoService)
        {
            _produtoService = ProdutoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var Produtos = await _produtoService.GetProdutos();
            return Ok(Produtos);
        }

        [HttpGet("{id}", Name = "GetProdutos")]
        public async Task<ActionResult<ProdutoDTO>> Get(int? id)
        {
            if (id == null)
                return NotFound();

            var Produto = await _produtoService.GetById(id);

            if (Produto == null)
                return NotFound();

            return Produto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO ProdutoDTO)
        {
            if (ProdutoDTO == null)
                return BadRequest();

            await _produtoService.Add(ProdutoDTO);

            return new CreatedAtRouteResult("GetProdutos", new { id = ProdutoDTO.Id }, ProdutoDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int? id, [FromBody] ProdutoDTO ProdutoDTO)
        {
            if (id == null)
                return NotFound();

            if (ProdutoDTO == null || ProdutoDTO.Id != id)
                return BadRequest();

            await _produtoService.Update(ProdutoDTO);

            return new CreatedAtRouteResult("GetProdutos", new { id = ProdutoDTO.Id }, ProdutoDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            await _produtoService.Remove(id);

            return new CreatedAtRouteResult("GetProdutos", new { id = id }, null);
        }
    }
}
