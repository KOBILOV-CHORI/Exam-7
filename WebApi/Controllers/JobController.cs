using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController : ControllerBase
{
    private JobService _jobService;
    public JobController()
    {
        _jobService = new JobService();
    }
    [HttpPost("Add Job")]
    public int Add(JobDto _jobDto)
    {
        return _jobService.AddJob(_jobDto);
    }
    [HttpPut("Update")]
    public int Update(JobDto _jobDto)
    {
        return _jobService.UpdateJob(_jobDto);
    }
    [HttpDelete("Delete")]
    public int Delete(int id)
    {
        return _jobService.DeleteJob(id);
    }
    [HttpGet("Get All")]
    public List<JobDto> GetAll()
    {
        return _jobService.GetAllJobs();
    }
}
