using BackEndAPI.Data.Models;
using BackEndAPI.Services.BusinessServices.CharityService;
using BackEndAPI.Services.NewsService;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers;

[Route("api/CharityController")]
[ApiController]
public class CharityController : Controller
{
    private ICharityService _charityService;

    public CharityController(ICharityService charityService)
    {
        _charityService = charityService;
    }
    
    [HttpGet("GetCharities")]
    public async Task<List<Charity>> GetCharities()
    {
        return await _charityService.GetCharities();
    }
    
    [HttpGet("GetCharity/{id}")]
    public async Task<Charity> GetCharity(int id)
    {
        return await _charityService.GetCharity(id);
    }
    
    [HttpPost("AddCharity")]
    public async Task<string> AddCharity(Charity charitytoadd)
    {
        return await _charityService.AddCharity(charitytoadd);
    }
    
    [HttpPut("UpdateCharity/{id}")]
    public async Task UpdateCharity(int id, Charity updatedcharity)
    {
         await _charityService.UpdateCharity(id, updatedcharity);
    }
    
    [HttpDelete("DeleteCharity/{id}")]
    public async Task<string> DeleteCharity(int id)
    {
        bool check = _charityService.DeleteCharity(id).IsCompletedSuccessfully;
        if (check)
        {
            return "Charity Deletion successfull";
        }
        else
        {
            return "Charity Deletion failed";
        }
    }
    
}