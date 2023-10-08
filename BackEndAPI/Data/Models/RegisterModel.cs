namespace BackEndAPI.Data.Models;

public class RegisterModel
{
    public string username { get; set; }
    public string registerpassword { get; set; }
    public string usertype { get; set; }
    public string email { get; set; }
    public int phonenumber { get; set; }
    public string Address { get; set; }
    //case
    public string CaseName { get; set; }
    public string casedescription { get; set; }
    public int totalneeded { get; set; }
    public int ReferencedCharityId { get; set; }
    public Charity charity { get; set; }

    //charity
    public string CharityName { get; set; }
    public string Charitydescription { get; set; }
}