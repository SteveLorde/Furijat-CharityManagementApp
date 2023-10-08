using Auth0.AspNetCore.Authentication;
using BackEndAPI.Data;
using BackEndAPI.Data.Models;
using BackEndAPI.Services.Authentication;
using BackEndAPI.Services.BusinessServices.CaseService;
using BackEndAPI.Services.BusinessServices.CharityService;
using BackEndAPI.Services.BusinessServices.DonatorService;
using BackEndAPI.Services.NewsService;
using Microsoft.EntityFrameworkCore;

//variables


var builder = WebApplication.CreateBuilder(args);

// Add services to the container

    builder.Services.AddControllers();

    builder.Services.AddScoped<ICharityService, CharityService>();
    builder.Services.AddScoped<ICaseService, CaseService>();
    builder.Services.AddScoped<IDonatorService, DonatorService>();
    builder.Services.AddScoped<ICharityService, CharityService>();
    builder.Services.AddScoped<INewsService, NewsService>();
    builder.Services.AddDbContext<DataContext>(options => {
        options.UseSqlite(builder.Configuration.GetConnectionString("FurijatConnection"));
    });
    //builder.Services.AddScoped<IAuthentication, Authentication>();
    builder.Services.AddSwaggerGen();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //Add Middlewares (Descendingly)
    //app.UseCors("CorsPolicy");
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.Run();


/*
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.Authority = "https://dev-274rp2wmih7hfjup.eu.auth0.com/";
        options.Audience = "FurijatAuthAPI";
    });
*/