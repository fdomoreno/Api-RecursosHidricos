using Api_RecursosHidricos.Models;
using Api_RecursosHidricos.Repository;

namespace Api_RecursosHidricos.Services.Impl
{
    public class RecursosHidricosService : IRecursosHidricosService
    {
        private readonly IRecursoHidricoRepository _repository;
        public RecursosHidricosService(IRecursoHidricoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RecursoHidrico>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los recursos hidricos", ex);
            }
        }

        public async Task<RecursoHidrico> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el recurso hidrico", ex);
            }
        }

        public async Task<RecursoHidrico> AddAsync(RecursoHidrico recursoHidrico)
        {
            try
            {
                await _repository.AddAsync(recursoHidrico);
                return recursoHidrico;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el recurso hidrico", ex);
            }
        }

        public async Task<RecursoHidrico> UpdateAsync(RecursoHidrico recursoHidrico)
        {
            try
            {
                await _repository.UpdateAsync(recursoHidrico);
                return recursoHidrico;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el recurso hidrico", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var recursoHidrico = await _repository.GetByIdAsync(id);
                if (recursoHidrico != null)
                {
                    await _repository.DeleteAsync(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el recurso hidrico", ex);
            }
        }

    }
}
