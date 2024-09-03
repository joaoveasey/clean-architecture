using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await _categoriaService.GetCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id}", Name = "GetCategorias")]
        public async Task<ActionResult<CategoriaDTO>> Get(int? id)
        {
            if (id == null)
                return NotFound();

            var categoria = await _categoriaService.GetById(id);

            if (categoria == null)
                return NotFound();

            return categoria;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
                return BadRequest();

            await _categoriaService.Add(categoriaDTO);

            return new CreatedAtRouteResult("GetCategorias", new { id = categoriaDTO.Id }, categoriaDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int? id, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (id == null)
                return NotFound();

            if (categoriaDTO == null || categoriaDTO.Id != id)
                return BadRequest();

            await _categoriaService.Update(categoriaDTO);

            return new CreatedAtRouteResult("GetCategorias", new { id = categoriaDTO.Id }, categoriaDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            await _categoriaService.Remove(id);

            return new CreatedAtRouteResult("GetCategorias", new { id = id }, null);
        }
    }
}
