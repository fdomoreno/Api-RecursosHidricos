using Api_RecursosHidricos.AppContext;
using Api_RecursosHidricos.Models;

namespace Api_RecursosHidricos.Services{
    public class RecursosHidricosService
    {
        private readonly AppDbContext _context;
        public RecursosHidricosService(AppDbContext context)
        {
            _context = context;
        }

        public List<RecursosHidricos> GetAll()
        {
            return _context.RecursosHidricos.ToList();
        }

        public RecursosHidricos GetById(int id)
        {
            try{
                return _context.RecursosHidricos.FirstOrDefault(x => x.Id == id);
            }catch(Exception ex)
            {
                throw new Exception("Error al obtener el recurso hidrico", ex);
            }
        }

        public RecursosHidricos Create(RecursosHidricos recursoHidrico)
        {
            try{
                _context.RecursosHidricos.Add(recursoHidrico);
                _context.SaveChanges();
                return recursoHidrico;
            }catch(Exception ex)
            {
                throw new Exception("Error al crear el recurso hidrico", ex);
            }
        }

        public RecursosHidricos Update(RecursosHidricos recursoHidrico)
        {
            try{
                _context.RecursosHidricos.Update(recursoHidrico);
                _context.SaveChanges();
                return recursoHidrico;
            }catch(Exception ex)
            {
                throw new Exception("Error al actualizar el recurso hidrico", ex);
            }
        }

        public void Delete(int id)
        {
            try{
                var recursoHidrico = _context.RecursosHidricos.FirstOrDefault(x => x.Id == id);
                if(recursoHidrico != null)
                {
                    _context.RecursosHidricos.Remove(recursoHidrico);
                    _context.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw new Exception("Error al eliminar el recurso hidrico", ex);
            }
        }
    }
}
