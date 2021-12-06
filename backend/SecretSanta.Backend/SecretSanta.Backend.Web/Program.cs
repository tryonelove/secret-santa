using Microsoft.AspNetCore.Mvc.ApplicationModels;
using SecretSanta.Backend.Configurations;
using SecretSanta.Backend.DataAccess;
using SecretSanta.Backend.DomainModel;
using SecretSanta.Backend.Foundation.Account;
using SecretSanta.Backend.Foundation.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccess(options =>
{
    options.ConnectionString = builder.Configuration.GetConnectionString(DataAccessConfiguration.ConnectionString);
});

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddSecurity();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();