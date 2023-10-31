using System.ComponentModel.DataAnnotations;

namespace BochaAPI.Domain
{
    public class Caminata
    {
        [Key]
        public Guid IdCaminata { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Distancia { get; set; }
        public string? ImagenCaminataURL { get; set; }

        public Guid IdDificultad { get; set; }
        public Guid IdRegion { get; set; }


        //Navigation properties

        //public Dificultad Dificultad { get; set; }
        //public Region Region { get; set; }
        
    }
}
