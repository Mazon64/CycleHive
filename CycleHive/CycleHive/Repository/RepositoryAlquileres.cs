using CycleHive.Models;
using Microsoft.EntityFrameworkCore;

namespace CycleHive.Repository
{
    public class RepositoryAlquileres : IRepositoryAlquileres
    {
        private readonly CycleHiveDbContext _context;

        public RepositoryAlquileres(CycleHiveDbContext context)
        {
            _context = context;
        }

        public async Task<List<Alquiler>> GetAll()
        {
            return await _context.Alquileres.ToListAsync();
        }

        public async Task<Alquiler?> Get(int id)
        {
            return await _context.Alquileres.FindAsync(id);
        }

        public async Task<Alquiler> Add(Alquiler alquiler)
        {
            _context.Alquileres.Add(alquiler);
            await _context.SaveChangesAsync();
            return alquiler;
        }

        public async Task Update(int id, Alquiler alquiler)
        {
            var alquilerToUpdate = await _context.Alquileres.FindAsync(alquiler.Id);
            if (alquilerToUpdate != null)
            {
                alquilerToUpdate.FechaInicio = alquiler.FechaInicio;
                alquilerToUpdate.FechaFin = alquiler.FechaFin;
                alquilerToUpdate.Cliente = alquiler.Cliente;
                alquilerToUpdate.Bicicleta = alquiler.Bicicleta;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var alquiler = await _context.Alquileres.FindAsync(id);
            if (alquiler != null)
            {
                _context.Alquileres.Remove(alquiler);
                await _context.SaveChangesAsync();
            }
        }
    }
}