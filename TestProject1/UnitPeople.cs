using ConsoleAppDevart.Enums;
using ConsoleAppDevart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using DbSetType = ConsoleAppDevart.Models.Person;
using EnumType = ConsoleAppDevart.Enums.EnumAtivoInativo;


namespace TestProject1;

public class UnitPeople
{
    private readonly AppDataContext appDataContext;
    private readonly DbSet<DbSetType> dbSet;
    private readonly IQueryable<DbSetType> includeQueryable;
    private readonly EnumType enumValue;
    private readonly string name;

    public UnitPeople()
    {
        this.appDataContext = new AppDataContext(AppDataContext.ConnectionStringDefault);
        //this.dbSet = appDataContext.Set<DbSetType>();
        this.dbSet = appDataContext.People;
        this.includeQueryable = dbSet.Include(x => x.Grupo);
        this.enumValue = EnumType.Ativo;
        this.name = "User3-1";
    }

    //[Fact]
    //public void Test0()
    //{
    //    Assert.True(true);
    //}


    [Fact]
    public async Task Test_List()
    {
        var records = await dbSet.ToListAsync(CancellationToken.None);
        Assert.NotNull(records);
    }

    [Fact]
    public async Task Test_Include_List()
    {
        var records = await includeQueryable
            .ToListAsync(CancellationToken.None);
        Assert.NotNull(records);
    }

    [Fact]
    public async Task Test_SingleOrDefault()
    {
        var records = await dbSet.SingleOrDefaultAsync(x => x.Name == name, CancellationToken.None);
        Assert.NotNull(records);
    }

    [Fact]
    public async Task Test_Include_SingleOrDefault()
    {
        var records = await includeQueryable
            .SingleOrDefaultAsync(x => x.Name == name, CancellationToken.None);
        Assert.NotNull(records);
    }


    [Fact]
    public async Task Test_WhereEnum_List()
    {
        var records = await dbSet
                .Where(x => x.Status == enumValue)
                .ToListAsync(CancellationToken.None);
        Assert.NotNull(records);
    }

    [Fact]
    public async Task Test_WhereEnum_List2()
    {
        var records = await dbSet
                .Where(x => x.Status == EnumAtivoInativo.Ativo)
                .ToListAsync(CancellationToken.None);
        Assert.NotNull(records);
    }

    [Fact]
    public async Task Test_WhereEnum_Include_List()
    {
        var records = await includeQueryable
                .Where(x => x.Status == enumValue)
                .ToListAsync(CancellationToken.None);
        Assert.NotNull(records);
    }

    [Fact]
    public async Task Test_WhereEnum_Include_List2()
    {
        var records = await includeQueryable
                .Where(x => x.Status == EnumAtivoInativo.Ativo)
                .ToListAsync(CancellationToken.None);
        Assert.NotNull(records);
    }


}
