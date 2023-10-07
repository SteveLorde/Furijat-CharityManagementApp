using BackEndAPI.Data.Models;

namespace BackEndAPI.Services.BusinessServices.CharityService;

public interface ICharityService
{
    public Task<List<Charity>> GetCharities();
    public Task<Charity> GetCharity(int id);
    public Task<string> AddCharity(Charity charitytoadd);
    public Task UpdateCharity(int id , Charity updatedcharity);
    public Task DeleteCharity(int id);
}