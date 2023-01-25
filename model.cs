using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class SQLiteContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public string DbPath { get; }

    public SQLiteContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "shadowprops.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)  {
        modelBuilder.Entity <Employee> ()  
        .Property < string > ("Custom");  
    }
}

public class Employee
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
}
