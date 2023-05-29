namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

public class JobHistoryService
{
    DapperContext dapperContext;
    public JobHistoryService()
    {
        dapperContext = new DapperContext();
    }
    public int AddJobHistory(JobHistoryDto _jobHistoryDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"insert into job_history(employee_id, start_date, end_date, job_id, department_id) values(@EmployeeId, @StartDate, @EndDate, @JobId, @DepartmentId)";
            var result = conn.Execute(sql, _jobHistoryDto);
            return result;
        }
    }
    public int UpdateJobHistory(JobHistoryDto _jobHistoryDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"update job_history set employee_id = @EmployeeId, start_date=@StartDate, end_date=@EndDate, job_id=@JobId, department_id=@DepartmentId where employee_id = @EmployeeId";
            var result = conn.Execute(sql, _jobHistoryDto);
            return result;
        }
    }
    public int DeleteJobHistory(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"delete from job_history where employee_id = @EmployeeId";
            var result = conn.Execute(sql, new {id});
            return result;
        }
    }
    public List<JobHistoryDto> GetAllJobHistories()
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select employee_id EmployeeId, start_date StartDate, end_date EndDate, job_id JobId, department_id DepartmentId from job_history";
            var result = conn.Query<JobHistoryDto>(sql).ToList();
            return result;
        }
    }
}
