using Api_RecursosHidricos.Models;

namespace Api_RecursosHidricos.Repository{

    public interface IRecursoHidricoRepository
    {
        Task<IEnumerable<RecursoHidrico>> GetAllAsync();
        Task<RecursoHidrico> GetByIdAsync(int id);
        Task AddAsync(RecursoHidrico recursosHidricos);
        Task UpdateAsync(RecursoHidrico recursosHidricos);
        Task DeleteAsync(int id);
    }

}