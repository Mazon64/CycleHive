using CycleHive.Models;
using Microsoft.EntityFrameworkCore;

namespace CycleHive.Repository
{
    public class RepositoryClientes : IRepositoryClientes
    {
        private readonly CycleHiveDbContext _context;

        public RepositoryClientes(CycleHiveDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> Get(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> Add(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task Update(int id, Cliente cliente)
        {
            var clienteToUpdate = await _context.Clientes.FindAsync(cliente.Id);
            if (clienteToUpdate != null)
            {
                clienteToUpdate.Nombre = cliente.Nombre;
                clienteToUpdate.Direccion = cliente.Direccion;
                clienteToUpdate.Telefono = cliente.Telefono;
                clienteToUpdate.Correo = cliente.Correo;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}