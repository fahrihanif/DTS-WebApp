using DTS_WebApp.Contexts;
using DTS_WebApp.Models;
using DTS_WebApp.Repository.Contracts;

namespace DTS_WebApp.Repository;

public class EducationRepository : GeneralRepository<Education, int, MyContext>, IEducationRepository
{
    public EducationRepository(MyContext context) : base(context) { }
}