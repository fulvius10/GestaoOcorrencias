using GestaoOcorrencias.Domain.Entities;
using GestaoOcorrencias.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Application.Services
{
    public class OcorrenciaService
    {
        private readonly IOcorrenciaRepository _ocorrenciaRepository;

        public OcorrenciaService(IOcorrenciaRepository ocorrenciaRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
        }

        public async Task<IEnumerable<Ocorrencia>> GetAllOcorrenciasAsync()
        {
            return await _ocorrenciaRepository.GetAllAsync();
        }

        public async Task<Ocorrencia> GetOcorrenciaByIdAsync(int id)
        {
            return await _ocorrenciaRepository.GetByIdAsync(id);
        }

        public async Task AddOcorrenciaAsync(Ocorrencia ocorrencia)
        {
            await _ocorrenciaRepository.AddAsync(ocorrencia);
        }

        public async Task UpdateOcorrenciaAsync(Ocorrencia ocorrencia)
        {
            await _ocorrenciaRepository.UpdateAsync(ocorrencia);
        }

        public async Task DeleteOcorrenciaAsync(int id)
        {
            await _ocorrenciaRepository.DeleteAsync(id);
        }
    }
}
