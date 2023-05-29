using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobHistoryController : ControllerBase
{
    private JobHistoryService _jobHistoryService;
    public JobHistoryController()
    {
        _jobHistoryService = new JobHistoryService();
    }
    [HttpPost("Add JobHistory")]
    public int Add(JobHistoryDto _jobHistoryDto)
    {
        return _jobHistoryService.AddJobHistory(_jobHistoryDto);
    }
    [HttpPut("Update")]
    public int Update(JobHistoryDto _jobHistoryDto)
    {
        return _jobHistoryService.UpdateJobHistory(_jobHistoryDto);
    }
    [HttpDelete("Delete")]
    public int Delete(int id)
    {
        return _jobHistoryService.DeleteJobHistory(id);
    }
    [HttpGet("Get All")]
    public List<JobHistoryDto> GetAll()
    {
        return _jobHistoryService.GetAllJobHistories();
    }
}
