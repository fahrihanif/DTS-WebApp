using DTS_WebApp.Models;
using DTS_WebApp.ViewModels;

namespace DTS_WebApp.Repository.Contracts;

public interface IAccountRepository : IGeneralRepository<Account, string>
{
    int Register(RegisterVM registerVM);
}
