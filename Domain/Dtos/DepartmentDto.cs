namespace Domain.Dtos;

public class DepartmentDto
{
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public int ManagerId { get; set; }
    public int LocationId { get; set; }
}
