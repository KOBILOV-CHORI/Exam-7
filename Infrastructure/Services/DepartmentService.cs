namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

public class DepartmentService
{
    DapperContext dapperContext;
    public DepartmentService()
    {
        dapperContext = new DapperContext();
    }
    public int AddDepartment(DepartmentDto _departmentDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"insert into departments(department_name, manager_id, location_id) values(@DepartmentName, @ManagerId, @LocationId)";
            var result = conn.Execute(sql, _departmentDto);
            return result;
        }
    }
    public int UpdateDepartment(DepartmentDto _departmentDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"update departments set department_name = @DepartmentName, manager_id=@ManagerId, location_id=@LocationId where department_id = @DepartmentId";
            var result = conn.Execute(sql, _departmentDto);
            return result;
        }
    }
    public int DeleteDepartment(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"delete from departments where department_id = @DepartmentId";
            var result = conn.Execute(sql, new {id});
            return result;
        }
    }
    public List<DepartmentDto> GetAllDepartments()
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select department_id DepartmentId, Department_name DepartmentName, manager_id ManagerId, location_id LocationId from departments";
            var result = conn.Query<DepartmentDto>(sql).ToList();
            return result;
        }
    }
}
