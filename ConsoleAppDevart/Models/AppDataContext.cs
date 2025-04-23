using ConsoleAppDevart.Converters;
using ConsoleAppDevart.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDevart.Models;
public class AppDataContext : DbContext
{
    #region DbSet
    public virtual DbSet<Person> People { get; set; } = null!;
    public virtual DbSet<Grupo> Grupos { get; set; } = null!;
    #endregion

    public const string ConnectionStringDefault = "User Id=DOTNET;Password=DOTNETPASSWORD;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.32.1.114 ) (PORT=1521)))(CONNECT_DATA=(SID=FRB)));";
    //public const string DefaultUsername = "DOTNET";

    public const string DevartLicenceKey = "Wh/plBbpF2PVfZxmkUhVTr7BoanU8wjjxYRXsmsXZy8NLs9eqO5WFVily7ufYVRC0EHetSMu9cNkvUFELlppltb3dwuZKhCmeu4KjqhMb65du7kv+ygz3WLhbWJj9nqHM4fu7gfMEeVryqcm6VEtYbPJ+aZMmi+P5KYNkHulHgWolB0XyTVOUXZK4ckc65dfnJiASo4YzOHodq5ArYhzMhn4UX946WSQRg0dj+JIe7QkBpnZQ+y1FT9ZyJ9tVYQYwrbYStklGlEajwsc1kRbhkzLjRS5R6uPXljjHyezPGLaUsVC3DnfoyRVZ0wECD3gI7hOn4//W/BY6zq7OAn6Hw==";


    public AppDataContext(string connectionString) : base(new DbContextOptionsBuilder()
        .UseOracle(connectionString + "License Key=" + DevartLicenceKey + ";").Options)
    {

    }

    public AppDataContext(DbContextOptions<AppDataContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured == false)
        {
            optionsBuilder
            .UseOracle(ConnectionStringDefault + "License Key=" + DevartLicenceKey + ";"
           );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("TB_TST_PEOPLE", "DOTNET");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired()
                .HasColumnType(@"VARCHAR2")
                .ValueGeneratedNever()
                .HasColumnName("NAME");

            entity.Property(e => e.GrupoName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .ValueGeneratedNever()
                .HasColumnName("GRUPONAME");

            entity.Property(x => x.Status)
                .HasColumnName(@"STATUS")
                .HasColumnType(@"VARCHAR2")
                .IsRequired()
                .ValueGeneratedNever()
                .HasMaxLength(1)
                .HasConversion(new EnumToString1CharConverter<EnumAtivoInativo>(EnumAtivoInativo.Ativo, "A"));

            entity.HasOne(x => x.Grupo)
               .WithMany(x => x.Persons)
               .HasPrincipalKey(x => x.Name)
               .HasForeignKey(x => x.GrupoName)
               .IsRequired(false);
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("TB_TST_GRUPO", "DOTNET");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired()
                .HasColumnType(@"VARCHAR2")
                .ValueGeneratedNever()
                .HasColumnName("NAME");

            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false)
                .ValueGeneratedNever()
                .HasColumnName("DESCRIPTION");

            entity.Property(x => x.Status)
                .HasColumnName(@"STATUS")
                .HasColumnType(@"VARCHAR2")
                .IsRequired()
                .ValueGeneratedNever()
                .HasMaxLength(1)
                //.HasConversion(new EnumToString1CharConverter<EnumAtivoInativo>(EnumAtivoInativo.Ativo, "A"));
                .HasConversion(new EnumAttivoInattivoToStringConverter());

        });


        modelBuilder.Entity<Person>().HasData(
            new Person { Name = "User1-1", Status = EnumAtivoInativo.Ativo, GrupoName = "Grupo1" },
            new Person { Name = "User2-1", Status = EnumAtivoInativo.Ativo, GrupoName = "Grupo1" },
            new Person { Name = "User3-1", Status = EnumAtivoInativo.Inativo, GrupoName = "Grupo1" },
            new Person { Name = "User4-1", Status = EnumAtivoInativo.Ativo, GrupoName = "Grupo1" },
            new Person { Name = "User5-2", Status = EnumAtivoInativo.Ativo, GrupoName = "Grupo2" },
            new Person { Name = "User6-2", Status = EnumAtivoInativo.Ativo, GrupoName = "Grupo2" },
            new Person { Name = "User7-2", Status = EnumAtivoInativo.Inativo, GrupoName = "Grupo2" },
            new Person { Name = "User8-1", Status = EnumAtivoInativo.Ativo, GrupoName = "Grupo1" }

        );

        modelBuilder.Entity<Grupo>().HasData(
            new Grupo { Name = "Grupo1", Status = EnumAtivoInativoBool.Ativo, Description = "Descrizione Grupo1" },
            new Grupo { Name = "Grupo2", Status = EnumAtivoInativoBool.Ativo, Description = "Descrizione Grupo2" },
            new Grupo { Name = "Grupo3", Status = EnumAtivoInativoBool.Ativo, Description = "Descrizione Grupo3" },
            new Grupo { Name = "Grupo4", Status = EnumAtivoInativoBool.Ativo, Description = "Descrizione Grupo4" }
        );
    }



}