﻿using GestaoOcorrencias.Domain.Entities;

namespace GestaoOcorrencias.Domain.Interfaces
{
    public interface IOcorrenciaRepository
    {
        Task<IEnumerable<Ocorrencia>> GetAllAsync();
        Task<Ocorrencia> GetByIdAsync(int id);
        Task AddAsync(Ocorrencia ocorrencia);
        Task UpdateAsync(Ocorrencia ocorrencia);
        Task DeleteAsync(int id);
    }
}