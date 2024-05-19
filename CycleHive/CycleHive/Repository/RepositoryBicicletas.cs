using CycleHive.Models;
using Microsoft.EntityFrameworkCore;

namespace CycleHive.Repository
{
    public class RepositoryBicicletas : IRepositoryBicicletas
    {
        private readonly CycleHiveDbContext _context;

        public RepositoryBicicletas(CycleHiveDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bicicleta>> GetAll()
        {
            return await _context.Bicicletas.ToListAsync();
        }

        public async Task<Bicicleta?> Get(int id)
        {
            return await _context.Bicicletas.FindAsync(id);
        }

        public async Task<Bicicleta> Add(Bicicleta bicicleta)
        {
            await _context.Bicicletas.AddAsync(bicicleta);
            await _context.SaveChangesAsync();
            return bicicleta;
        }

        public async Task Update(int id, Bicicleta bicicleta)
        {
            var bicicletaToUpdate = await _context.Bicicletas.FindAsync(bicicleta.Id);
            if (bicicletaToUpdate != null)
            {
                bicicletaToUpdate.Marca = bicicleta.Marca;
                bicicletaToUpdate.Modelo = bicicleta.Modelo;
                bicicletaToUpdate.Color = bicicleta.Color;
                bicicletaToUpdate.Tamaño = bicicleta.Tamaño;
                bicicletaToUpdate.Tipo = bicicleta.Tipo;
                bicicletaToUpdate.Precio = bicicleta.Precio;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var bicicleta = await _context.Bicicletas.FindAsync(id);
            if (bicicleta != null)
            {
                _context.Bicicletas.Remove(bicicleta);
                await _context.SaveChangesAsync();
            }
        }
    }
}