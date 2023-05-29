using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private CountryService _countryService;
    public CountryController()
    {
        _countryService = new CountryService();
    }
    [HttpPost("Add Country")]
    public int Add(CountryDto _countryDto)
    {
        return _countryService.AddCountry(_countryDto);
    }
    [HttpPut("Update")]
    public int Update(CountryDto _countryDto)
    {
        return _countryService.UpdateCountry(_countryDto);
    }
    [HttpDelete("Delete")]
    public int Delete(int id)
    {
        return _countryService.DeleteCountry(id);
    }
    [HttpGet("Get All")]
    public List<CountryDto> GetAll()
    {
        return _countryService.GetAllCountrys();
    }
}
