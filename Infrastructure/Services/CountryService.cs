namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

public class CountryService
{
    DapperContext dapperContext;
    public CountryService()
    {
        dapperContext = new DapperContext();
    }
    public int AddCountry(CountryDto _countryDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"insert into countries(country_name, region_id) values(@CountryName, @RegionId)";
            var result = conn.Execute(sql, _countryDto);
            return result;
        }
    }
    public int UpdateCountry(CountryDto _countryDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"update countries set country_name = @CountryName, region_id=@RegionId where country_id = @CountryId";
            var result = conn.Execute(sql, _countryDto);
            return result;
        }
    }
    public int DeleteCountry(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"delete from Countries where country_id = @CountryId";
            var result = conn.Execute(sql, new {id});
            return result;
        }
    }
    public List<CountryDto> GetAllCountrys()
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select country_id CountryId, country_name CountryName, region_id RegionId from Countries";
            var result = conn.Query<CountryDto>(sql).ToList();
            return result;
        }
    }
}
