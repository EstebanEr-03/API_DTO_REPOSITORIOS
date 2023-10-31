namespace BochaAPI.Models.DTO
{
    public class RegionDTO
    {
        public Guid IdRegion { get; set; }
        public string Code { get; set; }
        public string Nombre { get; set; }

        public string? RegionImageURL { get; set; }

    }
}
