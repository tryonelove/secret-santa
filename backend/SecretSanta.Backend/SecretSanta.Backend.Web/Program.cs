using SecretSanta.Backend.Configurations;
using SecretSanta.Backend.DataAccess;
using SecretSanta.Backend.Foundation.UserServices;

var builder = WebApplication.CreateBuilder(args);
var corsConfiguration = builder.Configuration.GetSection(CorsConfiguration.Name).Get<CorsConfiguration>();

builder.Services.AddCors(corsOptions =>
    corsOptions.AddPolicy(CorsConfiguration.Name, corsPolicyBuilder =>
    {
        corsPolicyBuilder
            .WithOrigins(corsConfiguration.Origins)
            .AllowAnyHeader()
            .AllowAnyMethod();
    }));

builder.Services.AddDataAccess(options =>
{
    options.ConnectionString = builder.Configuration.GetConnectionString(DataAccessConfiguration.ConnectionString);
});

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddFoundation();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseRouting();

app.UseCors(CorsConfiguration.Name);

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();