﻿using GestaoOcorrencias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}
