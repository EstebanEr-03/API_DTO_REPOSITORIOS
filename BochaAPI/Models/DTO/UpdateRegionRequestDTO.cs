namespace BochaAPI.Models.DTO
{
    public class UpdateRegionRequestDTO
    {
        public string Code { get; set; }
        public string Nombre { get; set; }

        public string? RegionImageURL { get; set; }
    }
}
