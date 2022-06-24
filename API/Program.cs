using API;
using API.Extensions;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Persistence;

var builder = WebApplication.CreateBuilder(args);
var _config = builder.Configuration; //Configuration variable


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adds IdentityCore services to container
builder.Services.AddIdentityServiceExtension(_config);


//Adds Oracle services to container
//builder.Services.AddOracleServiceExtension(_config);

//Adds SqlLite services to container
builder.Services.AddSqlLiteServiceExtension(_config);

var app = builder.Build();

//creating migrations automatically
IServiceScope scope = app.Services.CreateScope();
IServiceProvider serviceProvider = scope.ServiceProvider;
UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();

try
{
    DataContext context = serviceProvider.GetRequiredService<DataContext>();
    if (await context.Database.EnsureCreatedAsync())
    {
        Console.WriteLine("La base de datos no esta creada");
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        await context.Database.MigrateAsync();
        await Seed.SeedData(context, userManager);
        
    }else
    {
        Console.WriteLine("La base de datos esta creada");
        await context.Database.MigrateAsync();
        await Seed.SeedData(context, userManager);
    }
}
catch (OracleException ex)
{
    Console.WriteLine("Error de la base de datos: \n" + ex.ToString());
    Console.WriteLine("Error desde: " + ex.StackTrace?.ToString());
    Console.WriteLine(ex.DataSource?.ToString());
}
catch(Exception ex){
    Console.WriteLine("Error en el proceso: \n" + ex.ToString());
    Console.WriteLine("Error desde: " + ex.StackTrace?.ToString());
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/*Adds Authentication to container
This comes authenticates from our IdentityServiceExtension*/
app.UseAuthentication(); //We must specify which Controller methods requires authentication

app.UseAuthorization();

app.MapControllers();

app.Run();
