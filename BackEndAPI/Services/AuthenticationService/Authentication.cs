using System.Net.Http;
using BackEndAPI.Data;
using BackEndAPI.Data.Models;
using BackEndAPI.Services.Authentication.Models;
using BackEndAPI.Services.BusinessServices.CaseService;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace BackEndAPI.Services.Authentication;

class Authentication : IAuthentication
{
    //variables & Injections
    //---------
    private IPasswordHash _passwordHash;
    private DataContext _db;

    public Authentication(IPasswordHash passwordHash, DataContext db)
    {
        _passwordHash = passwordHash;
        _db = db;
    }


    public async Task<bool> LocalLogin(LoginModel loginrequest)
    {
        var usertocheck = _db.Users.Any(x => x.username == loginrequest.username);
        if (usertocheck)
        {
            var userpasswordtocheck = await _db.Users.FirstAsync(x => x.username == loginrequest.username);
            bool check = _passwordHash.VerifyPassword(loginrequest.password , userpasswordtocheck.passwordhash);
            if (check)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }

    public async Task<bool> LocalRegister(RegisterModel usertoregister)
    {
        var hashedpassword = _passwordHash.HashPassword(usertoregister.registerpassword);
        
        switch (usertoregister.usertype)
        {
            case "case":
                
                Case newusercase = new Case
                {
                    username = usertoregister.username,
                    email = usertoregister.email,
                    password = usertoregister.registerpassword,
                    passwordhash = hashedpassword,
                    usertype = "case",
                    Name = usertoregister.CaseName,
                    description = usertoregister.casedescription,
                    Address = usertoregister.Address,
                    Totalneeded = usertoregister.totalneeded,
                    Status = "pending",
                    CharityId = usertoregister.ReferencedCharityId,
                    Charity = usertoregister.charity
                };
                await _db.Cases.AddAsync(newusercase);
                await _db.SaveChangesAsync();
                break;
            
            case "charity":
                Charity newusercharity = new Charity
                {
                    username = usertoregister.username,
                    email = usertoregister.email,
                    password = usertoregister.registerpassword,
                    passwordhash = hashedpassword,
                    usertype = "charity",
                    charityname = usertoregister.CharityName,
                    description = usertoregister.Charitydescription,
                    phonenumber = usertoregister.phonenumber,
                    Cases = null
                };
                await _db.Charities.AddAsync(newusercharity);
                await _db.SaveChangesAsync();
                break;
            case "donator":
                Donator newdonator = new Donator
                {
                    username = usertoregister.username,
                    email = usertoregister.email,
                    password = usertoregister.registerpassword,
                    passwordhash = hashedpassword,
                    usertype = "donator",
                    paymenttype = null,
                    phonenumber = usertoregister.phonenumber,
                    DonatedCase = null
                };
                await _db.Donators.AddAsync(newdonator);
                await _db.SaveChangesAsync();
                break;
        }

        return true;
    }
}



    
/*
    private IPasswordHash _passwordservice;
    private DataContext _db;
    AuthenticationApiClient client = new AuthenticationApiClient(new Uri("dev-274rp2wmih7hfjup.eu.auth0.com"));
    private HttpClient httpclient = new HttpClient();

    public Authentication(IPasswordHash passwordservice, DataContext db)
    {
        
        _passwordservice = passwordservice;
        _db = db;
    }


    public async Task<AccessTokenResponse> Login(UserSign userSign)
    {
        var tokenrequest = new ResourceOwnerTokenRequest()
        {
            Username = userSign.username,
            Password = userSign.password,
            ClientId = userSign.clientId,
        };

        var token = await this.client.GetTokenAsync(tokenrequest);

        return token;
    }

    public void LocalLogin(UserSign userSign)
    {
        //IMPLEMENT GETTING USER HASHED PASSWORD FROM DATABASE O
        var hashedpasswordtocheck = _passwordservice.HashPassword(userSign.password);
        //var usertologin = _db.Users.FirstOrDefault(x => x.username == userSign.username);
    }

    public void LocalRegister(UserSign userSign)
    {
        //throw new NotImplementedException();
    }

    public void LocalLogout()
    {
        //throw new NotImplementedException();
    }
*/