// See https://aka.ms/new-console-template for more information
using ConsoleAppDevart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");






Console.WriteLine("Hello, World!");

var builder = Host.CreateDefaultBuilder();

var host = builder.ConfigureServices(ConfigureServices)
    .Build();


var dbContext = host.Services.GetRequiredService<AppDataContext>();

var people = await dbContext.People.ToListAsync();
var gruppi = await dbContext.Grupos.ToListAsync();


//work well
var peopleAt = await dbContext.People
    .Where(x => x.Status == ConsoleAppDevart.Enums.EnumAtivoInativo.Ativo)
    .ToListAsync();

var peopleAt2 = await dbContext.People
    .Include(x => x.Grupo)
    .ToListAsync();

//error in Convert.cs
//System.InvalidCastException: 'Invalid cast from 'System.Int32' to 'ConsoleAppDevart.Enums.EnumAtivoInativo'.'
var peopleAtError = await dbContext.People
    .Include(x => x.Grupo)
    .Where(x => x.Status == ConsoleAppDevart.Enums.EnumAtivoInativo.Ativo)
    .ToListAsync();


//Work well
var grupos2 = await dbContext.Grupos
    .Include(x => x.Persons)
    .ToListAsync();

//error in Convert.cs
//System.InvalidCastException: 'Invalid cast from 'System.Int32' to 'ConsoleAppDevart.Enums.EnumAtivoInativo'.'
var grupos3 = await dbContext.Grupos
    .Where(x => x.Status == ConsoleAppDevart.Enums.EnumAtivoInativoBool.Ativo)
    //.Include(x => x.Persons)
    .ToListAsync();

//error in Convert.cs
//System.InvalidCastException: 'Invalid cast from 'System.Int32' to 'ConsoleAppDevart.Enums.EnumAtivoInativo'.'
var grupos3b = await dbContext.Grupos
    .Where(x => x.Status == ConsoleAppDevart.Enums.EnumAtivoInativoBool.Ativo)
    .Include(x => x.Persons)
    .ToListAsync();


Console.WriteLine(people.Count);

static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
{

    services.AddDbContext<AppDataContext>(options =>
    {
        options.UseOracle(AppDataContext.ConnectionStringDefault + "License Key=" + AppDataContext.DevartLicenceKey + ";");


    });
}

