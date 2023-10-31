using BochaAPI.Domain;

namespace BochaAPI.Repositorios
{
    public interface IRegionRepositorio
    {
        //definicion 
       Task<List<Region>> GetAllAsync();
       Task<Region?> GetByIdAsync(Guid id);//?nulleable region 
       Task<Region> CreateAsync(Region regionDomainModel);
       Task<Region?> UpdateAsync(Guid id,Region regionDomainModel);//?nulleable region  porque el id puede que no se encuentre
       Task<Region?> DeleteAsync(Guid id);//?nulleable region  porque el id puede que no se encuentre
    }
}
