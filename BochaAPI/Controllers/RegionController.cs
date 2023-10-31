using AutoMapper;
using BochaAPI.Data;
using BochaAPI.Domain;
using BochaAPI.Models.DTO;
using BochaAPI.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BochaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RegionController : ControllerBase
    {
        private readonly BochaDbContext dbContext;

        //Con esta implementacion se denota buenas practicas ya que se usa directamente regionRepositorio para usar la DB
        private readonly IRegionRepositorio regionRepositorio;//Es una capa entre la data y la apliacion
        private readonly IMapper mapper;

        public RegionController(BochaDbContext dbContext,IRegionRepositorio regionRepositorio,IMapper mapper)
        {

            this.dbContext = dbContext;
            this.regionRepositorio = regionRepositorio;
            this.mapper = mapper;
        }
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll() {

            //Se obtiene la data de la database
            var regionesDomain = await regionRepositorio.GetAllAsync();


            //Mapear Domain Models to DTOs
            /*var regionesDto = new List<RegionDTO>();
            foreach (var region in regionesDomain)
            {
                regionesDto.Add(new RegionDTO()
                {
                    IdRegion = region.IdRegion,
                    Nombre = region.Nombre,
                    Code = region.Code,
                    RegionImageURL = region.RegionImageURL

                });
            }*/

            //MAPEAR DOMAIN MODELS A DTO
            var regionesDto= mapper.Map<List<RegionDTO>>(regionesDomain);


            //Retornamos DTOS para el cliente
            return Ok(regionesDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region=dbContext.Regiones.Find(id);
            //se obtiene la regiion de la base de datos
            //var region =await dbContext.Regiones.FirstOrDefaultAsync(x => x.IdRegion == id); //con esta se pude buscar otras parametros
            var region =await regionRepositorio.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }
            //Mapear regiones domain model to DTO

            mapper.Map<RegionDTO>(region);

            /*var regionDto = new RegionDTO
            {

                IdRegion = region.IdRegion,
                Nombre = region.Nombre,
                Code = region.Code,
                RegionImageURL = region.RegionImageURL

            };*/


            //Retorna el DTO al cliente
            return Ok(mapper.Map<RegionDTO>(region));

        }
        //Post crear nueva region
        [HttpPost]
        //[Authorize(Roles = "Writer")]
        //[FromBody] nos da el cliente
        public async Task<IActionResult> Crear([FromBody] AddRegionRequestDto nuevaRegion)
        {
            //Convertir el DTO que recibo del cliente a Domain

            var regionDomainModel=mapper.Map<Region>(nuevaRegion);//<DESTINO ES REGION(DOMAIN MODEL)>

            /*var regionDomainModel = new Region
            {
                Code = nuevaRegion.Code,
                Nombre = nuevaRegion.Nombre,
                RegionImageURL = nuevaRegion.RegionImageURL

            };*/

            /*Usar el domain para cerar una region
            await dbContext.Regiones.AddAsync(regionDomainModel);
            await dbContext.SaveChangesAsync();*/

            //Crear con el repositorio 
            regionDomainModel = await regionRepositorio.CreateAsync(regionDomainModel);

            //Se debe enviar el DTO NO EL DOMEIN

            var regionDto = mapper.Map<RegionDTO>(regionDomainModel);
            /*var regionDto = new RegionDTO
            {
                IdRegion = regionDomainModel.IdRegion,
                Code = regionDomainModel.Code,
                Nombre = regionDomainModel.Nombre,
                RegionImageURL = regionDomainModel.RegionImageURL
            };*/
            //Invoca metodo con el nombre para presentarlo en Swagger

            return CreatedAtAction(nameof(GetById), new { id = regionDto.IdRegion }, regionDto);
        }
        //Update region

        [HttpPut]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO actualizarRegion)
        {
            //Mapear el dto para el domainmodel

            var regionDomainModel = mapper.Map<Region>(actualizarRegion);
            /*{
                Code = actualizarRegion.Code,
                Nombre = actualizarRegion.Nombre,
                RegionImageURL = actualizarRegion.RegionImageURL

            };*/

            /*Checkea si existe esta region
            var regionBuscar = await dbContext.Regiones.FirstOrDefaultAsync(x => x.IdRegion == id);*/
            regionDomainModel = await regionRepositorio.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Mapear el dto para el domainmodel
            /*regionDomainModel.Code = actualizarRegion.Code;
            regionDomainModel.Nombre= actualizarRegion.Nombre;
            regionDomainModel.RegionImageURL = actualizarRegion.RegionImageURL;

            await dbContext.SaveChangesAsync();*/

            //convertir el domain model en un dto

            var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

            /*{
                IdRegion = regionDomainModel.IdRegion,
                Code = regionDomainModel.Code,
                Nombre= regionDomainModel.Nombre,
                RegionImageURL = regionDomainModel.RegionImageURL

            };*/

            return Ok(regionDTO);
        }
        //Borrar una region
        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Eliminar([FromRoute]Guid id)
        {
            var regionBuscar = await regionRepositorio.DeleteAsync(id);
            if (regionBuscar == null)
            {
                return NotFound();
            }

            //retornar el objeto borrado
            //map domain model to DTO
            var DtoRegion =mapper.Map<RegionDTO>(regionBuscar);
                
                /*new RegionDTO
            {
                Nombre = regionBuscar.Nombre,
                IdRegion = regionBuscar.IdRegion,
                Code = regionBuscar.Code,
                RegionImageURL = regionBuscar.RegionImageURL

            };*/

            return Ok(DtoRegion);
        }
    }
}
