using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : Controller
    {

        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var regionsDomain = dbContext.Regions.ToList();
            var regionDtos = new List<RegionDTO>();

            foreach (var region in regionsDomain)
            {

                var regionDto = new RegionDTO
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                };
                regionDtos.Add(regionDto);
            }
            return Ok(regionDtos);

        }


        //Get Single Region (Get Region By Id)
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {

            var regionDomain = dbContext.Regions.Find(id);

            //var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            var regionDto = new RegionDTO
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl

            };
            return Ok(regionDto);
        }


        public IActionResult AddRegion([FromBody] AddRegionDTO addRegionDTO)
        {
            var regionDomain = new Region
            {
                Id = Guid.NewGuid(),
                Code = addRegionDTO.Code,
                Name = addRegionDTO.Name,
                RegionImageUrl = addRegionDTO.RegionImageUrl
            };
            dbContext.Regions.Add(regionDomain);
            dbContext.SaveChanges();
            var regionDto = new RegionDTO
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            var regionDomain = dbContext.Regions.Find(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            regionDomain.Code = updateRegionDTO.Code;
            regionDomain.Name = updateRegionDTO.Name;
            regionDomain.RegionImageUrl = updateRegionDTO.RegionImageUrl;
            dbContext.SaveChanges();
            var regionDto = new RegionDTO
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return Ok(regionDto);


        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteRegion([FromRoute] Guid id)
        {
            var regionDomain = dbContext.Regions.Find(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            dbContext.Regions.Remove(regionDomain);
            dbContext.SaveChanges();
            var regionDto = new RegionDTO
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return Ok(regionDto);

        }

    }
}
