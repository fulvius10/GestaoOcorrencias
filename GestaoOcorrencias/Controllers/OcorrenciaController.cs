using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GestaoOcorrencias.Application.Services;
using GestaoOcorrencias.Domain.Entities;

namespace GestaoOcorrencias.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcorrenciasController : ControllerBase
    {
        private readonly OcorrenciaService _ocorrenciaService;

        public OcorrenciasController(OcorrenciaService ocorrenciaService)
        {
            _ocorrenciaService = ocorrenciaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _ocorrenciaService.GetAllOcorrenciasAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ocorrencia = await _ocorrenciaService.GetOcorrenciaByIdAsync(id);
            if (ocorrencia == null) return NotFound();
            return Ok(ocorrencia);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Ocorrencia ocorrencia)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _ocorrenciaService.AddOcorrenciaAsync(ocorrencia);


            return CreatedAtAction(nameof(GetById), new { id = ocorrencia.Id }, ocorrencia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Ocorrencia ocorrencia)
        {

            if (id != ocorrencia.Id)
                return BadRequest("ID na URL não corresponde ao ID da ocorrência.");

            var existingOcorrencia = await _ocorrenciaService.GetOcorrenciaByIdAsync(id);
            if (existingOcorrencia == null)
                return NotFound("Ocorrência não encontrada.");

            await _ocorrenciaService.UpdateOcorrenciaAsync(ocorrencia);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ocorrencia = await _ocorrenciaService.GetOcorrenciaByIdAsync(id);
            if (ocorrencia == null) return NotFound();
            await _ocorrenciaService.DeleteOcorrenciaAsync(id);
            return NoContent();
        }
    }
}
