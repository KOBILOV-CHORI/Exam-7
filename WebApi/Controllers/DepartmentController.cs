using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private DepartmentService _departmentService;
    public DepartmentController()
    {
        _departmentService = new DepartmentService();
    }
    [HttpPost("Add Department")]
    public int Add(DepartmentDto _departmentDto)
    {
        return _departmentService.AddDepartment(_departmentDto);
    }
    [HttpPut("Update")]
    public int Update(DepartmentDto _departmentDto)
    {
        return _departmentService.UpdateDepartment(_departmentDto);
    }
    [HttpDelete("Delete")]
    public int Delete(int id)
    {
        return _departmentService.DeleteDepartment(id);
    }
    [HttpGet("Get All")]
    public List<DepartmentDto> GetAll()
    {
        return _departmentService.GetAllDepartments();
    }
}
