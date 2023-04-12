using DTS_WebApp.Contexts;
using DTS_WebApp.Models;
using DTS_WebApp.Repository.Contracts;

namespace DTS_WebApp.Repository.Data;

public class RoleRepository : GeneralRepository<Role, int, MyContext>, IRoleRepository
{
    public RoleRepository(MyContext context) : base(context) { }
}
