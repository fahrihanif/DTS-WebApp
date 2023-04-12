using DTS_WebApp.Contexts;
using DTS_WebApp.Models;
using DTS_WebApp.Repository.Contracts;
using DTS_WebApp.ViewModels;

namespace DTS_WebApp.Repository.Data;

public class AccountRepository : GeneralRepository<Account, string, MyContext>, IAccountRepository
{
    public AccountRepository(MyContext context) : base(context) { }
    public int Register(RegisterVM registerVM)
    {
        // Validasi untuk input masing" entitas jika gagal lakukan rollback
        // Validasi apakah input university name ada di database/ tidak

        var university = new University {
            Name = registerVM.UniversityName,
        };
        _context.Universities.Add(university);
        _context.SaveChanges();

        var education = new Education {
            Major = registerVM.Major,
            Degree = registerVM.Degree,
            GPA = registerVM.GPA,
            UniversityId = university.Id,
        };
        _context.Educations.Add(education);
        _context.SaveChanges();

        var employee = new Employee {
            NIK = registerVM.NIK,
            FirstName = registerVM.FirstName,
            LastName = registerVM.LastName,
            BirthDate = registerVM.BirthDate,
            Gender = registerVM.Gender,
            PhoneNumber = registerVM.PhoneNumber,
            Email = registerVM.Email,
            HiringDate = DateTime.Now
        };
        _context.Employees.Add(employee);
        _context.SaveChanges();

        var account = new Account {
            EmployeeNIK = registerVM.NIK,
            Password = registerVM.Password,
        };
        _context.Accounts.Add(account);
        _context.SaveChanges();

        var profiling = new Profiling {
            EmployeeNIK = registerVM.NIK,
            EducationId = education.Id,
        };
        _context.Profilings.Add(profiling);
        return _context.SaveChanges();

    }
}
