using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoOcorrencias.Domain.Entities;
using GestaoOcorrencias.Domain.Interfaces;
using GestaoOcorrencias.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoOcorrencias.Infrastructure.Repositories
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly AppDbContext _context;

        public OcorrenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ocorrencia>> GetAllAsync()
        {
            return await _context.Ocorrencias.ToListAsync();
        }

        public async Task<Ocorrencia> GetByIdAsync(int id)
        {
            return await _context.Ocorrencias.FindAsync(id);
        }

        public async Task AddAsync(Ocorrencia ocorrencia)
        {
            await _context.Ocorrencias.AddAsync(ocorrencia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ocorrencia ocorrencia)
        {
            _context.Ocorrencias.Update(ocorrencia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);
            if (ocorrencia != null)
            {
                _context.Ocorrencias.Remove(ocorrencia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
