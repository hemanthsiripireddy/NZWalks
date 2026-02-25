using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilter;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : Controller
    {

       

        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
           
            this.regionRepository = regionRepository;
            this.mapper= mapper;

        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await regionRepository.GetAllAsync();
            //var regionDtos = new List<RegionDTO>();

            //foreach (var region in regionsDomain)
            //{

            //    var regionDto = new RegionDTO
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        RegionImageUrl = region.RegionImageUrl
            //    };
            //    regionDtos.Add(regionDto);
            //}
             var regionDtos = mapper.Map<List<RegionDto>>(regionsDomain);
            return Ok(regionDtos);

        }


        //Get Single Region (Get Region By Id)
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

           // var regionDomain = dbContext.Regions.Find(id);

            var regionDomain = await regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            var regionDto = mapper.Map<RegionDto>(regionDomain);
            //var regionDto = new RegionDTO
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl

            //};
            return Ok(regionDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionDto addRegionDto)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);
            var regionDomain = mapper.Map<Region>(addRegionDto);
            var createdRegion = await regionRepository.CreateAsync(regionDomain);
            var regionDto = mapper.Map<RegionDto>(createdRegion);
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);
            //var regionDomain = dbContext.Regions.Find(id);
            var regionDomain=mapper.Map<Region>(updateRegionDto);
             regionDomain = await regionRepository.UpdateAsync(id,regionDomain);
            if (regionDomain == null)
            {
                return NotFound();
            }
            var regionDto =mapper.Map<RegionDto>(regionDomain);
            return Ok(regionDto);


        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            //var regionDomain = dbContext.Regions.Find(id);
            var regionDomain = await regionRepository.DeleteAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            
            var regionDto = mapper.Map<RegionDto>(regionDomain);
            return Ok(regionDto);

        }

        

    }
}
