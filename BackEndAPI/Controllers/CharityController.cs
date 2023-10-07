using BackEndAPI.Data.Models;
using BackEndAPI.Services.BusinessServices.CharityService;
using BackEndAPI.Services.NewsService;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers;

[ApiController]
public class CharityController : Controller
{
    private ICharityService _charityService;

    public CharityController(ICharityService charityService)
    {
        _charityService = charityService;
    }
    
    [Route("api/GetCharities")]
    [HttpGet]
    // GET
    public async Task<List<Charity>> GetCharities()
    {
        var charities = await _charityService.GetCharities();
        return charities;
    }
    
    [Route("api/GetCharity")]
    [HttpGet]
    // GET
    public async Task<Charity> GetCharity(int id)
    {
        var charity = await _charityService.GetCharity(id);
        return charity;
    }
    
    [Route("api/AddCharity")]
    [HttpPost]
    // GET
    public async Task<string> AddCharity(Charity charitytoadd)
    {
        return await _charityService.AddCharity(charitytoadd);
    }
    
    [Route("api/UpdateCharity")]
    [HttpPut]
    // GET
    public async Task UpdateCharity(int id, Charity updatedcharity)
    {
         await _charityService.UpdateCharity(id, updatedcharity);
    }
    
    [Route("api/DeleteCharity")]
    [HttpDelete]
    // GET
    public async Task DeleteCharity(int id)
    {
        await _charityService.DeleteCharity(id);
    }
    
}