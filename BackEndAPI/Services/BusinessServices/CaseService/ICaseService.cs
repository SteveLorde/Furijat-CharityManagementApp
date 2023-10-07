using BackEndAPI.Data.Models;

namespace BackEndAPI.Services.BusinessServices.CaseService;

public interface ICaseService
{
    public Task<List<Case>> GetCases();
    public Task<List<Case>> GetCasesOfCharity(int charityid);
    public Task<Case> GetCase(int id);
    public Task<bool> AddCase(Case casetoadd);
    public Task UpdateCase(int id, Case updatedcase);
    public Task DeleteCase(int id);
    
}