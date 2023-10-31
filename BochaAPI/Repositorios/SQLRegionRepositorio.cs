using BochaAPI.Data;
using BochaAPI.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BochaAPI.Repositorios
{
    public class SQLRegionRepositorio : IRegionRepositorio
    {

        //Inyectar DbContextClass
        private readonly BochaDbContext dbContext;

        public SQLRegionRepositorio(BochaDbContext dbContext)
        {
            this.dbContext=dbContext;
        }

        public async Task<Region> CreateAsync(Region regionDomainModel)
        {
             await dbContext.Regiones.AddAsync(regionDomainModel);
             await dbContext.SaveChangesAsync();
            return regionDomainModel;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
           var regionBuscar= await dbContext.Regiones.FirstOrDefaultAsync(x => x.IdRegion == id);
            if (regionBuscar == null) 
            {
                return null;
            }
             dbContext.Regiones.Remove(regionBuscar);
            await dbContext.SaveChangesAsync();
            return regionBuscar;
        }



        //Implementar interfaz
        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regiones.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regiones.FirstOrDefaultAsync(x => x.IdRegion == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region regionDomainModel)
        {
            var regionEncontrada = await dbContext.Regiones.FirstOrDefaultAsync(x => x.IdRegion == id);
            if (regionEncontrada == null)
            {
                return null;
            }
            regionEncontrada.Nombre = regionDomainModel.Nombre;
            regionEncontrada.Code = regionDomainModel.Code;
            regionEncontrada.RegionImageURL = regionDomainModel.RegionImageURL;

            await dbContext.SaveChangesAsync();
            return regionEncontrada;
        }
    }
}
