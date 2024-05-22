using CycleHive.Models;

namespace CycleHive.Repository
{
    public interface IRepositoryAlquileres
    {
        Task<List<Alquiler>> GetAll();
        Task<Alquiler?> Get(int id);
        Task<List<Bicicleta>> GetBicicletas();
        Task<List<Cliente>> GetClientes();
        Task<Alquiler> Add(Alquiler alquiler);
        Task Update(int id, Alquiler alquiler);
        Task Delete(int id);
    }
}
