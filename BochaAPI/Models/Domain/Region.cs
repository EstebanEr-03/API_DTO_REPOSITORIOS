using System.ComponentModel.DataAnnotations;

namespace BochaAPI.Domain
{
    public class Region
    {
        [Key]
        public Guid IdRegion { get; set; }
        public string Code { get; set; }
        public string Nombre { get; set; }

        public string? RegionImageURL { get; set; }
    }
}
