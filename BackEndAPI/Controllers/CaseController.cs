using BackEndAPI.Data.Models;
using BackEndAPI.Services.BusinessServices.CaseService;
using BackEndAPI.Services.NewsService;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers;

[Route("api/CaseController")]
[ApiController]
public class CaseController : Controller
{
    private ICaseService _caseService;

    public CaseController(ICaseService caseService)
    {
        _caseService = caseService;
    }
    
    [HttpGet("GetCases")]
    // GET
    public async Task<List<Case>> GetCases()
    {
        try
        {
            return await _caseService.GetCases();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    [HttpGet("GetCase/{id}")]
    // GET
    public async Task<Case> GetCase(int id)
    {
        try
        {
            return await _caseService.GetCase(id);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    [HttpPost("AddCase")]
    // GET
    public async Task<string> AddCase(Case casetoadd)
    {
        try
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
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    [HttpPut("UpdateCase/{caseid}")]
    // PUT
    public async Task UpdateCase(int caseid,Case updatedcase)
    {
        try
        {
            await _caseService.UpdateCase(caseid, updatedcase);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    [HttpDelete("DeleteCase/{caseid}")]
    // GET
    public async Task DeleteCase(int caseid)
    {
        try
        {
            await _caseService.DeleteCase(caseid);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}