using ConsoleAppDevart.Enums;
using ConsoleAppDevart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using DbSetType = ConsoleAppDevart.Models.Grupo;
//using EnumType = ConsoleAppDevart.Enums.EnumAtivoInativoBool;


namespace TestProject1;

public class UnitGrupos2
{
    private readonly AppDataContext appDataContext;
    private readonly DbSet<DbSetType> dbSet;
    private readonly IQueryable<DbSetType> includeQueryable;
    private readonly EnumAtivoInativoBool enumValue;
    private readonly EnumAtivoInativoBool enumValue2;

    private readonly string name;

    public UnitGrupos2()
    {
        this.appDataContext = new AppDataContext(AppDataContext.ConnectionStringDefault);
        this.dbSet = appDataContext.Set<DbSetType>();
        this.includeQueryable = dbSet.Include(x => x.Persons);
        this.enumValue = EnumAtivoInativoBool.Ativo;
        this.enumValue2 = EnumAtivoInativoBool.Ativo;
        this.name = "Grupo1";
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
                .Where(x => x.Status == EnumAtivoInativoBool.Ativo)
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
                .Where(x => x.Status == EnumAtivoInativoBool.Ativo)
                .ToListAsync(CancellationToken.None);
        Assert.NotNull(records);
    }

    [Fact]
    public async Task Test_WhereEnum_Include_List3()
    {
        var records = await includeQueryable
                .Where(x => x.Status == enumValue2)
                .ToListAsync(CancellationToken.None);
        Assert.NotNull(records);
    }

    [Fact]
    public async Task Test_WhereEnum_Include_List4()
    {
        var enumv = EnumAtivoInativoBool.Ativo;
        var records = await includeQueryable
                .Where(x => x.Status == enumv)
                .ToListAsync(CancellationToken.None);
        Assert.NotNull(records);
    }

}
