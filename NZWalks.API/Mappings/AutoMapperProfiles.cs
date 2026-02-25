using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() { 
            CreateMap<Region,RegionDto>()
                .ReverseMap();
            CreateMap<AddRegionDto, Region>()
               .ReverseMap();
            CreateMap<UpdateRegionDto, Region>()
               .ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>()
               .ReverseMap();
            CreateMap<WalkDto, Walk>()
               .ReverseMap();
            CreateMap<DifficultyDto, Difficulty>()
               .ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>()
               .ReverseMap();



        }
    }
}
