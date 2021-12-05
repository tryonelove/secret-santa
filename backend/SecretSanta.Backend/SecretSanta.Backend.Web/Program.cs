using SecretSanta.Backend.Configurations;
using SecretSanta.Backend.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccess(options =>
{
    options.ConnectionString = builder.Configuration.GetConnectionString(DataAccessConfiguration.ConnectionString);
});

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