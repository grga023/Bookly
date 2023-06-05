using Bookly.Domain.Apstrakcije;
using Bookly.Domain.Apstrakcije.Baza;
using Bookly.Domain.Servisi.Korisnik;
using Bookly.Domain.Servisi.Rezervacija;
using Bookly.Domain.Servisi.Smestaj;
using Bookly.Infrastructure.Email;
using Bookly.Infrastructure.Identity;
using Bookly.Infrastructure.Identity.Entiteti;
using Bookly.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AplikacioniDbContext>(
    opts => opts.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("BooklyDb")));

builder.Services.AddDbContext<IdentityDbContext>(
    opts => opts.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("IdentityDb")));


builder.Services.Configure<SmtpGoogleKonfiguracija>(builder.Configuration.GetSection("SmtpGoogleKonfiguracija"));


builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<IdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.User.RequireUniqueEmail = true;
});

CookieBuilder cookie = new CookieBuilder
{
    SameSite = SameSiteMode.None,
    SecurePolicy = CookieSecurePolicy.Always,
    HttpOnly = true,
    IsEssential = true,
    Name = IdentityConstants.ApplicationScheme,
};

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = (context) =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };

    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.SlidingExpiration = true;

    options.Cookie = cookie;
});




builder.Services.AddScoped<IAplikacioniDbContext>(sp => sp.GetRequiredService<AplikacioniDbContext>());
builder.Services.AddScoped<IAplikacioniUnitOfWork, AplikacioniUnitOfWork>();
builder.Services.AddScoped<IIdentityServis, IdentityServis>();
builder.Services.AddTransient<IEmailServis, EmailServis>();
builder.Services.AddScoped<KorisnikServis>();
builder.Services.AddScoped<SmestajServis>();
builder.Services.AddScoped<RezervacijaServis>();

builder.Configuration.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json").AddEnvironmentVariables();


builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using (var scope = app.Services.CreateScope())
    {
        var aplikacioniDb = scope.ServiceProvider.GetRequiredService<AplikacioniDbContext>();
        aplikacioniDb.Database.Migrate();
        var identityDb = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
        identityDb.Database.Migrate();
    }
}

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
