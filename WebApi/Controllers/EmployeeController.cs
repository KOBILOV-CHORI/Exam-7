using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private EmployeeService _employeeService;
    public EmployeeController()
    {
        _employeeService = new EmployeeService();
    }
    [HttpPost("Add Employee")]
    public int Add(EmployeeDto _employeeDto)
    {
        return _employeeService.AddEmployee(_employeeDto);
    }
    [HttpPut("Update")]
    public int Update(EmployeeDto _employeeDto)
    {
        return _employeeService.UpdateEmployee(_employeeDto);
    }
    [HttpDelete("Delete")]
    public int Delete(int id)
    {
        return _employeeService.DeleteEmployee(id);
    }
    [HttpGet("Get All")]
    public List<EmployeeDto> GetAll()
    {
        return _employeeService.GetAllEmployees();
    }
}
