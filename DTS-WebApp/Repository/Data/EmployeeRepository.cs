using DTS_WebApp.Contexts;
using DTS_WebApp.Models;
using DTS_WebApp.Repository.Contracts;

namespace DTS_WebApp.Repository.Data;

public class EmployeeRepository : GeneralRepository<Employee, string, MyContext>, IEmployeeRepository
{
    public EmployeeRepository(MyContext context) : base(context) { }
}
