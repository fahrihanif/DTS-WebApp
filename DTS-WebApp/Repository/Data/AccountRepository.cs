using DTS_WebApp.Contexts;
using DTS_WebApp.Handlers;
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
        using var transaction = _context.Database.BeginTransaction();
        try {
            University university = new University {
                Name = registerVM.UniversityName
            };

            // Bikin kondisi untuk mengecek apakah data university sudah ada
            if (_context.Universities.Any(u => u.Name == university.Name)) {
                university.Id = _context.Universities
                                        .First(u => u.Name == university.Name)
                                        .Id;
            } else {
                _context.Universities.Add(university);
                _context.SaveChanges();
            }

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
                Password = Hashing.HashPassword(registerVM.Password),
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();

            var profiling = new Profiling {
                EmployeeNIK = registerVM.NIK,
                EducationId = education.Id,
            };
            _context.Profilings.Add(profiling);
            _context.SaveChanges();

            var accountRole = new AccountRole {
                EmployeeNIK = registerVM.NIK,
                RoleId = 1
            };
            _context.AccountRoles.Add(accountRole);
            _context.SaveChanges();
            transaction.Commit();

            return 1;
        } catch {
            transaction.Rollback();
            return 0;
        }
    }

    public bool Login(LoginVM loginVM)
    {
        var getUserData = _context.Employees.Join(_context.Accounts, e => e.NIK, a => a.EmployeeNIK, (e, a) => new LoginVM {
            Email = e.Email,
            Password = a.Password
        }).FirstOrDefault(e => e.Email == loginVM.Email);

        return getUserData is not null && Hashing.ValidatePassword(loginVM.Password, getUserData.Password);
    }
}
