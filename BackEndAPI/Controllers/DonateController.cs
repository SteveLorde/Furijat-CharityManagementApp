using BackEndAPI.Data.Models;
using BackEndAPI.Services.BusinessServices.CaseService;
using BackEndAPI.Services.BusinessServices.DonatorService;
using BackEndAPI.Services.NewsService;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers;

[Route("api/DonateController")]
[ApiController]
public class DonateController : Controller
{
    private IDonatorService _donatorService;

    public DonateController(IDonatorService donatorService)
    {
        _donatorService = donatorService;
    }

    [HttpPost("Donate")]
    public async Task<bool> Donate(Donation donation)
    {
        return await _donatorService.Donate(donation);
    }
    
    [HttpPost("CharityAcceptDonation")]
    public async Task AcceptDonation()
    {
        
    }
    
    [HttpPost("CharityRejectDonation")]
    public async Task RejectDonation()
    {
        
    }
    
    
    
}