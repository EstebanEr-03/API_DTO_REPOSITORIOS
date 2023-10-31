using BochaAPI.Domain;
using System.ComponentModel.DataAnnotations;

namespace BochaAPI.Models.DTO
{
    public class CaminataDTO
    {
        public Guid IdCaminata { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Distancia { get; set; }
        public string? ImagenCaminataURL { get; set; }

        public Guid IdDificultad { get; set; }
        public Guid IdRegion { get; set; }

        //public RegionDTO Region { get; set; }
        //public DificultadDTO Dificultad { get; set; }

    }
}
