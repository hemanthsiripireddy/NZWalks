using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionDto
    {
        [Required]
        [MaxLength(3, ErrorMessage = "Code must not be more than 3 characters")]
        [MinLength(3, ErrorMessage = "Code must be at least 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name must not be more than 100 characters")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
