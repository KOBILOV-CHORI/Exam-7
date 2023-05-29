using System.Data;
using Npgsql;

namespace Infrastructure.Context;

public class DapperContext
{
    string connString = "Server=localhost; port=5432; database=employeesdb; user id=postgres; password=01062007";
    public DapperContext()
    {
        
    }
    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(connString);
    }
}
