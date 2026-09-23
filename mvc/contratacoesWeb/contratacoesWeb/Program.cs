using contratacoesWeb.Data;
using contratacoesWeb.Endpoints;
using contratacoesWeb.Models;
using contratacoesWeb.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

var mongoDbSettings = builder.Configuration
    .GetSection("MongoDbSettings")
    .Get<Configuracoes>();

if (mongoDbSettings != null)
{
    builder.Services.AddIdentity<AplicacaoUser, Roles>()
        .AddMongoDbStores<AplicacaoUser, Roles, Guid>(
            mongoDbSettings.ConnectionString,
            mongoDbSettings.DatabaseName
        );

    builder.Services.AddDbContext<AplicacaoDbContext>(options =>
    {
        options.UseMongoDB(mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName);
    });
}
else
{
    Console.WriteLine("MongoDB settings are not configured properly.");
    return;
}

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IPainelAdminService, PainelAdminService>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapOpenApi();

app.MapScalarApiReference(options =>
{
    options
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PainelAdmin}/{action=Index}/{id?}")
    .WithStaticAssets();


app.MapApiEndpoints();

app.Run();

//https://medium.com/c-sharp-programming/implementing-mongodb-with-net-bbedcbb0caf4
//https://www.yogihosting.com/aspnet-core-identity-mongodb/#identity-role-mongodb