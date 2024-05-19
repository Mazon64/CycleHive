using CycleHive.Models;

namespace CycleHive.Repository
{
    public interface IRepositoryBicicletas
    {
        Task<List<Bicicleta>> GetAll();
        Task<Bicicleta?> Get(int id);
        Task<Bicicleta> Add(Bicicleta bicicleta);
        Task Update(int id, Bicicleta bicicleta);
        Task Delete(int id);
    }
}