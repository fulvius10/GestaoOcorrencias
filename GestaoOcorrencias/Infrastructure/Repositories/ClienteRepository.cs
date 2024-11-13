using GestaoOcorrencias.Domain.Entities;
using GestaoOcorrencias.Domain.Interfaces;
using GestaoOcorrencias.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoOcorrencias.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync() => await _context.Clientes.ToListAsync();

        public async Task<Cliente> GetByIdAsync(int id) => await _context.Clientes.FindAsync(id);

        public async Task AddAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
