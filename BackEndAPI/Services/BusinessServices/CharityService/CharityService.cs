using BackEndAPI.Data;
using BackEndAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Services.BusinessServices.CharityService;

class CharityService : ICharityService
{
    private DataContext _db;
    public CharityService(DataContext db)
    {
        _db = db;
    }
    
    public async Task<List<Charity>> GetCharities()
    {
        return await _db.Charities.ToListAsync();
    }

    public async Task<Charity> GetCharity(int id)
    {
        return await _db.Charities.FirstAsync(x => x.CharityId == id);
    }

    public async Task<string> AddCharity(Charity charitytoadd)
    {
        bool isCompletedSuccessfully =  _db.Charities.AddAsync(charitytoadd).IsCompletedSuccessfully;
        if (isCompletedSuccessfully)
        {
            return "Adding Charity successfull";
        }
        else
        {
            return "Adding Charity FAILED";
        }
    }

    public async Task UpdateCharity(int id, Charity updatedcharity)
    {
        var charitytoupdate = await _db.Charities.FindAsync(updatedcharity);
        charitytoupdate = updatedcharity;
        _db.Charities.Update(charitytoupdate);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteCharity(int id)
    {
        var charitytodelete = await _db.Cases.FirstAsync(x => x.CaseId == id);
        _db.Cases.Remove(charitytodelete);
        await _db.SaveChangesAsync();
    }
}