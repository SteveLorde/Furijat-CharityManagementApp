using Auth0.AspNetCore.Authentication;
using BackEndAPI.Data;
using BackEndAPI.Services.Authentication;
using Microsoft.EntityFrameworkCore;

//variables


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
    builder.Services.AddControllers();
    builder.Services.AddDbContext<DataContext>(options => {
        options.UseSqlite(builder.Configuration.GetConnectionString("FurijatConnection"));
    });
    //builder.Services.AddScoped<IAuthentication, Authentication>();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //Add Middlewares (Descendingly)
    app.UseCors("CorsPolicy");
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