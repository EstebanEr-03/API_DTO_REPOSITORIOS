using AutoMapper;
using BochaAPI.Domain;
using BochaAPI.Models.DTO;
using BochaAPI.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BochaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaminataController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICaminataRepositorio caminataRepositorio;

        public CaminataController(IMapper mapper, ICaminataRepositorio caminataRepositorio)
        {
            this.mapper = mapper;
            this.caminataRepositorio = caminataRepositorio;
        }


        //CRUD

        //CREAR CAMINATA
        [HttpPost]
        public async Task<IActionResult> CrearCaminataAsync([FromBody] AddCaminataRequestDTO nuevaCaminataCliente)
        {
            //Map DTO to Domain Model
            var caminataDomainModel = mapper.Map<Caminata>(nuevaCaminataCliente);

            await caminataRepositorio.CrearCaminataAsync(caminataDomainModel);

            //Map Domain model to DTO

            return Ok(mapper.Map<CaminataDTO>(caminataDomainModel));

        }
        //CREAR OBTENER TODO
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filtreQuery, [FromQuery] string? sortBy, [FromQuery] bool? isAscending)
        {
            var caminatasLista = await caminataRepositorio.GetAllAsync(filterOn,filtreQuery, sortBy, isAscending ?? true);


            //map Domain A DTO

            return Ok(mapper.Map<List<CaminataDTO>>(caminatasLista));

        }
        //CREAR OBTENER POR ID
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var caminataEncontrada = await caminataRepositorio.GetByIdAsync(id);
            if (caminataEncontrada == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CaminataDTO>(caminataEncontrada));

        }
        // EDITAR
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> PutAsync([FromRoute] Guid id, [FromBody] AddCaminataRequestDTO caminataDomain)
        {
            var caminataDomainModel = mapper.Map<Caminata>(caminataDomain);

            caminataDomainModel = await caminataRepositorio.PutAsync(id, caminataDomainModel);

            if (caminataDomainModel == null)
            {
                return NotFound();
            }

            var dtoCaminata = mapper.Map<CaminataDTO>(caminataDomainModel);
            return Ok(dtoCaminata);
        }

        // ELIMINAR

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id) 
        {
            var caminataEliminar = await caminataRepositorio.DeleteAsync(id);
            if (caminataEliminar == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CaminataDTO>(caminataEliminar));

        }
    }
}
