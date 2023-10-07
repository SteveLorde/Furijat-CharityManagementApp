using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Data.Models;

[NotMapped]
public class Donation
{
    public string paymenttype { get; set; }
    public int donationamount { get; set; }
    public int charityid { get; set; }
    public int caseid { get; set; }
    public int donatorid { get; set; }
}