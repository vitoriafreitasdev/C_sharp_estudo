using Microsoft.EntityFrameworkCore;
using API_PIMV.Services;
using Scalar.AspNetCore;
using API_PIMV.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEventsServices, EventsServices>();
builder.Services.AddScoped<IUsersServices, UsersService>();
builder.Services.AddScoped<ISiteService, SiteService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseHttpsRedirection();
app.UseCors("Allow");
app.UseAuthorization();
app.MapControllers();
app.Run();

