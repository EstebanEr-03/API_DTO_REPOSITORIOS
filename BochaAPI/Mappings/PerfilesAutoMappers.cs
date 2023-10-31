using AutoMapper;
using BochaAPI.Domain;
using BochaAPI.Models.DTO;

namespace BochaAPI.Mappings
{
    public class PerfilesAutoMappers:Profile
    {
        public PerfilesAutoMappers()
        {
            //necesita dos parametros, source y destino
            CreateMap<Region, RegionDTO>().ReverseMap();

            CreateMap<AddRegionRequestDto, Region>().ReverseMap();//AddRegionRequestDto source-----Region(DomainModel)destino
            CreateMap<UpdateRegionRequestDTO, Region>().ReverseMap();//AddRegionRequestDto source-----Region(DomainModel)destino

            //MapearCaminatas

            CreateMap<AddCaminataRequestDTO, Caminata>().ReverseMap();//AddRegionRequestDto source-----Region(DomainModel)destino
            CreateMap<Caminata, CaminataDTO>().ReverseMap();
            CreateMap<Dificultad, DificultadDTO>().ReverseMap();
        }
    }
}
