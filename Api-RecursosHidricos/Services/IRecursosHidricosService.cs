using Api_RecursosHidricos.Models;

namespace Api_RecursosHidricos.Services{
    public interface IRecursosHidricosService
    {
        public Task<IEnumerable<RecursoHidrico>> GetAllAsync();
        public Task<RecursoHidrico> GetByIdAsync(int id);
        public Task<RecursoHidrico> AddAsync(RecursoHidrico recursoHidrico);
        public Task<RecursoHidrico> UpdateAsync(RecursoHidrico recursoHidrico);
        public Task DeleteAsync(int id);
    }
}
