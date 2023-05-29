namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

public class RegionService
{
    DapperContext dapperContext;
    public RegionService()
    {
        dapperContext = new DapperContext();
    }
    public int AddRegion(RegionDto _regionDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"insert into Regions(region_name) values(@RegionName)";
            var result = conn.Execute(sql, _regionDto);
            return result;
        }
    }
    public int UpdateRegion(RegionDto _regionDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"update Regions set region_name = @RegionName where region_id = @RegionId";
            var result = conn.Execute(sql, _regionDto);
            return result;
        }
    }
    public int DeleteRegion(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"delete from Regions where region_id = @RegionId";
            var result = conn.Execute(sql, new {id});
            return result;
        }
    }
    public List<RegionDto> GetAllRegions()
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select region_id RegionId, region_name RegionName from Regions";
            var result = conn.Query<RegionDto>(sql).ToList();
            return result;
        }
    }
}
