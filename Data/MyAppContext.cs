
using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyAppContext : DbContext
    //DbContext is a class that is provided by Entity Framework Core.
    //We add this class to our project so that we can work with the database.
    // this is inheritence
    {


        //we need a constructor now
        //this is a constructor that takes an argument of type DbContextOptions

        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        //: base() syntax in C# is a way to explicitly call the constructor of the base class(DbContext)
        //Important--It simply ensure that the constructor of the base class is called to make sure it exists.
        //(also known as the parent class) when a derived class constructor is executed
        //. It is part of the constructor chaining mechanism in C#.
        {

        }

        public DbSet<Item> Items { get; set; }
        // A DbSet in Entity Framework Core represents a table in the database.


        //for authentication

         
    }
}
