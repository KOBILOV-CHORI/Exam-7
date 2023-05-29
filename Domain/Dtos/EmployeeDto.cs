namespace Domain.Dtos;

public class EmployeeDto
{
    public int EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int DepartmentId { get; set; }
    public int ManagerId { get; set; }
    public decimal Commission { get; set; }
    public int JobId { get; set; }
    public DateTime HireDate { get; set; }
}
