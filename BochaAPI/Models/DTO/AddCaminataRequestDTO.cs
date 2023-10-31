using BochaAPI.Domain;

namespace BochaAPI.Models.DTO
{
    public class AddCaminataRequestDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Distancia { get; set; }
        public string? ImagenCaminataURL { get; set; }

        public Guid IdDificultad { get; set; }
        public Guid IdRegion { get; set; }

    }
}
