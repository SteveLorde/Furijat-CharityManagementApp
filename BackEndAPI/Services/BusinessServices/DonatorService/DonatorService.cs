using BackEndAPI.Data;
using BackEndAPI.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging.Abstractions;

namespace BackEndAPI.Services.BusinessServices.DonatorService;

class DonatorService : IDonatorService
{
    private DataContext _db;
    public DonatorService(DataContext db)
    {
        _db = db;
    }
    public string Donate(Donation donation)
    {
        var donationrequest = LogDonation(donation);
        if (donationrequest)
        {
            return "Donation registered successfully";
        }
        else
        {
            //ELSE REJECT DONATION
            return "DONATION REJECTED DUE TO ERROR";
        }
    }
    
    public Task AcceptDonation(int donationid)
    {
        return null;
    }

    public Task RejectDonation(int donationid)
    {
        return null;
    }

    private bool LogDonation(Donation donation)
    {
        bool donatortocheck = _db.Donators.Any(x => x.DonatorId == donation.donatorid);
        if (donatortocheck)
        {
            var casetolog = _db.Cases.First(x => x.CaseId == donation.caseid);
            var charitytolog = _db.Charities.First(x => x.CharityId == donation.charityid);
            var donatortolog = _db.Donators.First(x => x.DonatorId == donation.donatorid);
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
            _db.DonationLogs.Add(donationtolog);
            //return TRUE
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
}
