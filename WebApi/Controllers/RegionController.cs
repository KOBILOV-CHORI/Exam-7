using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionController : ControllerBase
{
    private RegionService _regionService;
    public RegionController()
    {
        _regionService = new RegionService();
    }
    [HttpPost("Add Region")]
    public int Add(RegionDto _regionDto)
    {
        return _regionService.AddRegion(_regionDto);
    }
    [HttpPut("Update")]
    public int Update(RegionDto _regionDto)
    {
        return _regionService.UpdateRegion(_regionDto);
    }
    [HttpDelete("Delete")]
    public int Delete(int id)
    {
        return _regionService.DeleteRegion(id);
    }
    [HttpGet("Get All")]
    public List<RegionDto> GetAll()
    {
        return _regionService.GetAllRegions();
    }
}
