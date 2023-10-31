using BochaAPI.Domain;

namespace BochaAPI.Repositorios
{
    //Imporatante implementar que es una interface
    public interface ICaminataRepositorio
    {
        Task<Caminata> CrearCaminataAsync(Caminata caminata);
        Task<List<Caminata>> GetAllAsync(string? filterOn=null,string? filtrerQuery=null,string? sortBy=null,bool isAscending=true);
        Task<Caminata?> GetByIdAsync(Guid id);

        Task<Caminata?> PutAsync(Guid id, Caminata caminata);
        Task<Caminata?> DeleteAsync(Guid id);
    }
}
