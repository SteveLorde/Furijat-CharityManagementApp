namespace BackEndAPI.Data.Models;

public class DonationLog
{
    
    public int Id { get; set; }
    public int donationamount { get; set; }
    public string timeanddate { get; set; }
    public Donator Donator { get; set; }
    public Case Case { get; set; }
    public Charity Charity { get; set; }
    public string donationstatus { get; set; }
    
}