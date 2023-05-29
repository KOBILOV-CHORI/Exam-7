namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

public class JobService
{
    DapperContext dapperContext;
    public JobService()
    {
        dapperContext = new DapperContext();
    }
    public int AddJob(JobDto _jobDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"insert into jobs(Job_title, min_salary, max_salary) values(@JobTitle, @MinSalary, @MaxSalary)";
            var result = conn.Execute(sql, _jobDto);
            return result;
        }
    }
    public int UpdateJob(JobDto _jobDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"update jobs set job_title = @JobTitle, min_salary=@MinSalary, max_salary=@MaxSalary where job_id = @JobId";
            var result = conn.Execute(sql, _jobDto);
            return result;
        }
    }
    public int DeleteJob(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"delete from jobs where job_id = @JobId";
            var result = conn.Execute(sql, new {id});
            return result;
        }
    }
    public List<JobDto> GetAllJobs()
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select job_id JobId, Job_title JobTitle, min_salary MinSalary, max_salary MaxSalary from jobs";
            var result = conn.Query<JobDto>(sql).ToList();
            return result;
        }
    }
}
