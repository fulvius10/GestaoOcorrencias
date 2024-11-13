using GestaoOcorrencias.Domain.Entities;
using GestaoOcorrencias.Domain.Interfaces;
using GestaoOcorrencias.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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
            
            return await _context.Ocorrencias.AsNoTracking().ToListAsync();
        }

        public async Task<Ocorrencia> GetByIdAsync(int id)
        {
           
            return await _context.Ocorrencias.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Ocorrencia ocorrencia)
        {
            await _context.Ocorrencias.AddAsync(ocorrencia);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Ocorrencia ocorrencia)
        {
            var existingOcorrencia = await _context.Ocorrencias
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == ocorrencia.Id);

            if (existingOcorrencia != null)
            {
                _context.Entry(ocorrencia).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Ocorrência não encontrada para atualização.");
            }
        }


        public async Task DeleteAsync(int id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);
            if (ocorrencia != null)
            {
                _context.Ocorrencias.Remove(ocorrencia);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Ocorrência não encontrada para exclusão.");
            }
        }
    }
}
