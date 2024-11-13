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
    public async Task<IActionResult> Create([FromBody] Cliente cliente)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Adiciona o cliente usando o serviço
        await _clienteService.AddClienteAsync(cliente);

        // Retorna o cliente criado com o ID gerado pelo banco
        return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Cliente cliente)
    {
        // Verifica se o ID na URL corresponde ao ID no corpo da solicitação
        if (id != cliente.Id)
            return BadRequest("ID na URL não corresponde ao ID do cliente.");

        // Busca o cliente no banco de dados para verificar se ele existe
        var existingCliente = await _clienteService.GetClienteByIdAsync(id);
        if (existingCliente == null)
            return NotFound("Cliente não encontrado.");

        // Atualiza o cliente no serviço
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
