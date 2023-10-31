using BochaAPI.Data;
using BochaAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace BochaAPI.Repositorios
{
    public class SQLCaminataRepositorio : ICaminataRepositorio //NO OLVIDARSE QUE SE DEBE INYECTAR EL REPOSITORIO EN PROGRAM
    {
        private readonly BochaDbContext dbContext;

        public SQLCaminataRepositorio(BochaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Caminata> CrearCaminataAsync(Caminata caminata)
        {
           await dbContext.Caminatas.AddAsync(caminata);
           await dbContext.SaveChangesAsync();
           return caminata;
        }

        public async Task<Caminata?> DeleteAsync(Guid id)
        {
            var CaminataBuscar = await dbContext.Caminatas.FirstOrDefaultAsync(x => x.IdCaminata == id);
            if (CaminataBuscar == null)
            {
                return null;
            }
            dbContext.Caminatas.Remove(CaminataBuscar);
            await dbContext.SaveChangesAsync();
            return CaminataBuscar;
        }

        public async Task<List<Caminata>> GetAllAsync(string? filterOn = null, string? filtrerQuery = null, string? sortBy = null, bool isAscending = true)
        {
            var walks = dbContext.Caminatas.AsQueryable();


            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filtrerQuery) ==false)
            {
                if (filterOn.Equals("Nombre", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Nombre.Contains(filtrerQuery));


                }
            }
            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Nombre", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Nombre) : walks.OrderByDescending(x => x.Nombre);
                }
                else if (sortBy.Equals("Distancia", StringComparison.OrdinalIgnoreCase))
                { 
                    walks = isAscending ? walks.OrderBy(x => x.Distancia) : walks.OrderByDescending(x => x.Distancia);
                }
            }


            return await walks.ToListAsync();
            
        }

        public async Task<Caminata?> GetByIdAsync(Guid id)
        {
            var CaminataBuscar = await dbContext.Caminatas.FirstOrDefaultAsync(x => x.IdCaminata == id);
            if (CaminataBuscar == null)
            {
                return null;
            }
            return CaminataBuscar;
        }

        public async Task<Caminata?> PutAsync(Guid id, Caminata caminata)
        {
            var CaminataBuscar = await dbContext.Caminatas.FirstOrDefaultAsync(x => x.IdCaminata == id);
            if (CaminataBuscar == null)
            {
                return null;
            }
            CaminataBuscar.Descripcion = caminata.Descripcion;
            CaminataBuscar.ImagenCaminataURL = caminata.ImagenCaminataURL;
            CaminataBuscar.IdDificultad = caminata.IdDificultad;
            CaminataBuscar.Distancia = caminata.Distancia;
            CaminataBuscar.IdRegion = caminata.IdRegion;
            CaminataBuscar.Nombre   = caminata.Nombre;

            await dbContext.SaveChangesAsync();
            return CaminataBuscar;


        }
    }


}
