
using contratacoesWeb.Data;
using contratacoesWeb.Models;
using contratacoesWeb.Services;
using MongoDB.Driver;
using System.Security.Authentication;

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
}
else
{
    Console.WriteLine("MongoDB settings are not configured properly.");
    return;
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var configuracaoString = builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString");

var configuracoes = MongoClientSettings.FromUrl(new MongoUrl(configuracaoString));

configuracoes.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

builder.Services.AddSingleton<IMongoClient>(new MongoClient(configuracoes));

builder.Services.AddScoped<BancoDeDados>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IPainelAdminService, PainelAdminService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PainelAdmin}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

//https://medium.com/c-sharp-programming/implementing-mongodb-with-net-bbedcbb0caf4
//https://www.yogihosting.com/aspnet-core-identity-mongodb/#identity-role-mongodb