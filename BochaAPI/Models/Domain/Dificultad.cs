using System.ComponentModel.DataAnnotations;

namespace BochaAPI.Domain
{
    public class Dificultad
    {
        [Key]
        public Guid IdDificultad { get; set; }
        public string Nombre { get; set; }

    }
}
