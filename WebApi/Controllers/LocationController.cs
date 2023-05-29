using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private LocationService _locationService;
    public LocationController()
    {
        _locationService = new LocationService();
    }
    [HttpPost("Add Location")]
    public int Add(LocationDto _locationDto)
    {
        return _locationService.AddLocation(_locationDto);
    }
    [HttpPut("Update")]
    public int Update(LocationDto _locationDto)
    {
        return _locationService.UpdateLocation(_locationDto);
    }
    [HttpDelete("Delete")]
    public int Delete(int id)
    {
        return _locationService.DeleteLocation(id);
    }
    [HttpGet("Get All")]
    public List<LocationDto> GetAll()
    {
        return _locationService.GetAllLocations();
    }
}
