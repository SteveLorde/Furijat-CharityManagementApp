using BackEndAPI.Data;
using BackEndAPI.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace BackEndAPI.Services.BusinessServices.DonatorService;

class DonatorService : IDonatorService
{
    private DataContext _db;
    public DonatorService(DataContext db)
    {
        _db = db;
    }
    public async Task<bool> Donate(Donation donation)
    {
        return await LogDonation(donation);
    }
    
    public Task AcceptDonation(int donationid)
    {
        return null;
    }

    public Task RejectDonation(int donationid)
    {
        return null;
    }

    private async Task<bool> LogDonation(Donation donation)
    {
        bool donatortocheck = await _db.Donators.AnyAsync(x => x.DonatorId == donation.donatorid);
        if (donatortocheck)
        {
            var casetolog = await _db.Cases.FirstAsync(x => x.CaseId == donation.caseid);
            var charitytolog = await _db.Charities.FirstAsync(x => x.CharityId == donation.charityid);
            var donatortolog = await _db.Donators.FirstAsync(x => x.DonatorId == donation.donatorid);
            DonationLog donationtolog = new DonationLog
            {
                donationamount = donation.donationamount,
                timeanddate = "1-1-2024",
                Donator = donatortolog,
                Case = casetolog,
                Charity = charitytolog,
                donationstatus = "waiting_approval"
            };
            //add donation to case
            casetolog.currentdonations += donation.donationamount;
            //update case after adding donation
            _db.Cases.Update(casetolog);
            //log the donation
            await _db.DonationLogs.AddAsync(donationtolog);
            //return TRUE
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
}
