namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

public class EmployeeService
{
    DapperContext dapperContext;
    public EmployeeService()
    {
        dapperContext = new DapperContext();
    }
    public int AddEmployee(EmployeeDto _employeeDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"insert into employees(first_name, last_name, email, phone_number, department_id, manager_id, commission, salary, job_id, hire_date)"+ 
                      " values(@FirstName, @LastName, @Email, @PhoneNumber, @DepartmentId, @ManagerId, @Commission, @Salary, @JobId, @HireDate)";
            var result = conn.Execute(sql, _employeeDto);
            return result;
        }
    }
    public int UpdateEmployee(EmployeeDto _employeeDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"update employees set first_name = @FirstName, last_name=@LastName, email=@Email, phone_number=@PhoneNumber, department_id=@DepartmentId, manager_id=@ManagerId, commission=@Commission, salary=@Salary, job_id=@JobId, hire_date=HireDate where employee_id = @EmployeeId";
            var result = conn.Execute(sql, _employeeDto);
            return result;
        }
    }
    public int DeleteEmployee(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"delete from Employees where employee_id = @EmployeeId";
            var result = conn.Execute(sql, new {id});
            return result;
        }
    }
    public List<EmployeeDto> GetAllEmployees()
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select first_name FirstName, last_name LastName, email Email, phone_number PhoneNumber, department_id DepartmentId, manager_id ManagerId, commission Commission, salary Salary, job_id JobId, hire_date HireDate from employees";
            var result = conn.Query<EmployeeDto>(sql).ToList();
            return result;
        }
    }
}
