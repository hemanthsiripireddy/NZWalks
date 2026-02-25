namespace NZWalks.API.Models.DTO
{
    public class UpdateWalkRequestDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string? WalkImageUrl { get; set; }
        public double LengthInKM { get; set; }
        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }
    }
}
