using BackEndAPI.Data.Models;

namespace BackEndAPI.Services.BusinessServices.DonatorService;

public interface IDonatorService
{
    public string Donate(Donation donation);
    public Task AcceptDonation(int donationid);
    public Task RejectDonation(int donatorid);

}