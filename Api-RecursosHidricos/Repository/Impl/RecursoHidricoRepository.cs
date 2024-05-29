using Api_RecursosHidricos.AppContext;
using Api_RecursosHidricos.Models;
using Api_RecursosHidricos.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api_RecursosHidricos.Repository.Impl {

    public class RecursoHidricoRepository : IRecursoHidricoRepository
    {
        private readonly AppDbContext _context;

        public RecursoHidricoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecursoHidrico>> GetAllAsync()
        {
            try
            {
                return await _context.RecursoHidrico.ToListAsync();
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
                return await _context.RecursoHidrico.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el recurso hidrico", ex);
            }
        }

        public async Task AddAsync(RecursoHidrico recursoHidrico)
        {
            await _context.RecursoHidrico.AddAsync(recursoHidrico);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RecursoHidrico recursoHidrico)
        {
            _context.RecursoHidrico.Update(recursoHidrico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.RecursoHidrico.FindAsync(id);
            if (product != null)
            {
                _context.RecursoHidrico.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}