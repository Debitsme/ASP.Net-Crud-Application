using Microsoft.AspNetCore.Mvc;
using MyApp.Models; 
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using System.Runtime.Intrinsics.X86;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    //Every controller inherits this  base controller class so that we could work with multiple methods
    {
        //public IActionResult Overview()
        ////Iactionresult--- this is used to return  different kind of stuff.
        //////like we could return a page, a json or redirect a user to somewhere else.
        //// public IActionResult Index()---we change its name to overview so user are redirected to this route

        //{    
        //    //why items bcz the controller class name is item
        //     var item = new Item()
        //     { 
        //         Name = "Shaka Laka Boom Boom"
        //     };
        //    return View(item);
        //}

        //public IActionResult Edit(int id)
        //{
        //    return Content("Id: " + id);
        //}
        ////This is the url where the id will be shown and that why we put Edit name or the Overview name
        ////https://localhost:7182/items/edit/2

        ////itme is the name of the controller
        ///


        //the above code is the hard coded data. now we will get values from the database

        private readonly MyAppContext _context;
        //The readonly keyword means that once it’s set, it cannot be changed

        //_context
        //_context is a private field that holds a reference to the database context.
        //A database context is a class that represents a session with your database.
        //_context lets you access the tables in your database.
        //For example, if you have a DbSet<Item> in your MyAppContext, you can use _context.Items to:

        public ItemsController(MyAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        //Index is a method (called an "action") that handles requests to the /Items/Index URL.

        {
            var item = await _context.Items.ToListAsync();
            return View(item);
        }

        //handles requests to display the form where users can input data for a new Item.
        public IActionResult Create()
        //When a user navigates to /Items/Create, this method is called
        {
            return View();
        }

        //When you add [HttpPost] above a method,
        //you're telling ASP.NET Core that this method should only respond to POST requests
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id","Name","Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                //This adds the new Item object to the database context (_context) but does not save it to the database yet.

                return RedirectToAction("Index");
                //Saves the new record to the database. This sends a SQL INSERT query to the database
                //This sends a SQL INSERT command to the database to actually save the item data.

            }
            return View(item);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item= await _context.Items.FirstOrDefaultAsync(m => m.Id == id);
            //FirstOrDefaultAsync
            //This is an asynchronous LINQ method provided by Entity Framework Core
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Name", "Price")] Item item)
        { 
            if (ModelState.IsValid)  //the model we have defined in the Item.cs file
            {
                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(m => m.Id == id);
            return View(item);
        }
        [HttpPost, ActionName("Delete")]  //whenever the html form post something it will land here
                                            //why write this separately cuz the name delete and delete confirmed are diff
        public async Task<IActionResult> DeleteConfirmed(int id)  //cannot use 2 delete methods(cause their parameter are the same)

        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }

    }
}
