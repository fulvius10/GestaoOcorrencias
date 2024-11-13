using GestaoOcorrencias.Application.Services;
using GestaoOcorrencias.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public ClientesController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _clienteService.GetAllClientesAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => Ok(await _clienteService.GetClienteByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(Cliente cliente)
    {
        await _clienteService.AddClienteAsync(cliente);
        return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Cliente cliente)
    {
        if (id != cliente.Id) return BadRequest();
        await _clienteService.UpdateClienteAsync(cliente);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _clienteService.DeleteClienteAsync(id);
        return NoContent();
    }
}
