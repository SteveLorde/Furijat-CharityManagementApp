using BackEndAPI.Data;
using BackEndAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Services.BusinessServices.CaseService;

class CaseService : ICaseService
{
    
    private DataContext _db;
    public CaseService(DataContext db)
    {
        _db = db;
    }
    
    public async Task<List<Case>> GetCases()
    {
        return await _db.Cases.ToListAsync();
    }
    
    public async Task<List<Case>> GetCasesOfCharity(int charityid)
    {
        return await _db.Cases.Where(x => x.CharityId == charityid).ToListAsync();
    }

    public async Task<Case> GetCase(int id)
    {
        return await _db.Cases.FirstAsync(x => x.CaseId == id);
    }

    public async Task<bool> AddCase(Case casetoadd)
    {
        var checkadd =  _db.Cases.AddAsync(casetoadd).IsCompletedSuccessfully;

        if (checkadd)
        {
            await _db.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task UpdateCase(int id, Case updatedcase)
    {
        Case casetoupdate = await _db.Cases.FirstAsync(x => x.CaseId == updatedcase.CaseId);
        casetoupdate = updatedcase;
        _db.Cases.Update(casetoupdate);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteCase(int id)
    {
        var casetodelete = await _db.Cases.FirstAsync(x => x.CaseId == id);
        _db.Cases.Remove(casetodelete);
        await _db.SaveChangesAsync();
    }
}