using BackEndAPI.Data.Models;
using BackEndAPI.Services.BusinessServices.CaseService;
using BackEndAPI.Services.NewsService;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers;

[ApiController]
public class CaseController : Controller
{
    private ICaseService _caseService;

    public CaseController(ICaseService caseService)
    {
        _caseService = caseService;
    }
    
    [Route("api/GetCases")]
    [HttpGet]
    // GET
    public async Task<List<Case>> GetCases()
    {
        var cases = await _caseService.GetCases();
        return cases;
    }
    
    [Route("api/GetCase")]
    [HttpGet]
    // GET
    public async Task<Case> GetCase(int id)
    {
        var _case = await _caseService.GetCase(id);
        return _case;
    }
    
    [Route("api/AddCase")]
    [HttpPost]
    // GET
    public async Task<string> AddCase(Case casetoadd)
    {
        var checkoperation = await _caseService.AddCase(casetoadd);
        if (checkoperation)
        {
            return "Adding Case operation successfull";
        }
        else
        {
            return "Adding Case FAILED";
        }
    }
    
    [Route("api/UpdateCase")]
    [HttpPut]
    // GET
    public async Task UpdateCase(int caseid,Case updatedcase)
    {
        await _caseService.UpdateCase(caseid, updatedcase);
    }
    
    [Route("api/DeleteCase")]
    [HttpDelete]
    // GET
    public async Task DeleteCase(int caseid)
    {
        await _caseService.DeleteCase(caseid);
    }
}