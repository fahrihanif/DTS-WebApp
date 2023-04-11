using DTS_WebApp.Models;

namespace DTS_WebApp.Repository.Contracts;

public interface IUniversityRepository
{
    IEnumerable<University> GetAll();
    University? GetById(int id);
    IEnumerable<University> Search(string name);
    int Insert(University university);
    int Update(University university);
    int Delete(int id);
}
