namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

public class LocationService
{
    DapperContext dapperContext;
    public LocationService()
    {
        dapperContext = new DapperContext();
    }
    public int AddLocation(LocationDto _locationDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"insert into locations(street_address, postal_code, city, state_province, country_id) values(@StreetAddress, @PostalCode, @City, @StateProvince, @CountryId)";
            var result = conn.Execute(sql, _locationDto);
            return result;
        }
    }
    public int UpdateLocation(LocationDto _locationDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"update locations set street_address=@StreetAddress, postal_code=@PostalCode, city=@City, state_province=@StateProvince, country_id=@CountryId where location_id = @LocationId";
            var result = conn.Execute(sql, _locationDto);
            return result;
        }
    }
    public int DeleteLocation(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"delete from locations where location_id = @LocationId";
            var result = conn.Execute(sql, new {id});
            return result;
        }
    }
    public List<LocationDto> GetAllLocations()
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select location_id LocationId, street_address StreetAddress, postal_code PostalCode, city City, state_province StateProvince, country_id CountryId from locations";
            var result = conn.Query<LocationDto>(sql).ToList();
            return result;
        }
    }
}
