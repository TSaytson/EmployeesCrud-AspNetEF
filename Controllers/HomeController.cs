using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aspnetefcore.Models;
using aspnetefcore.Database;
using Microsoft.EntityFrameworkCore;

namespace aspnetefcore.Controllers
{
  public class HomeController : Controller
  {

    private readonly ApplicationDBContext database;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ApplicationDBContext database)
    {
      _logger = logger;
      this.database = database;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    public IActionResult Test()
    {
      /*Categorie c1 = new Categorie();
      c1.Name = "Victor";
      Categorie c2 = new Categorie();
      c2.Name = "Thiago";
      Categorie c3 = new Categorie();
      c3.Name = "Erik";
      Categorie c4 = new Categorie();
      c4.Name = "Mariana";
      Categorie[] categorieArray = { c1, c2, c3, c4 };

      database.AddRange(categorieArray);
      database.SaveChanges();*/

      List<Categorie> categorieList = 
        database.Categories.Where(c => c.Id <= 2).ToList();

      Console.WriteLine("============== Categories =============");

      categorieList.ForEach(categorie =>
      {
        Console.WriteLine(categorie.ToString());
      });

      Console.WriteLine("==========================");
      return Content("Data saved");
    }

    public IActionResult Relationship(){

      /*Product p1 = new Product();
      p1.Name = "Ruffles";
      p1.Categorie = database.Categories.First(categorie => 
        categorie.Name.Equals("Thiago"));
        
      Product p2 = new Product();
      p2.Name = "God of War";
      p2.Categorie = database.Categories.First(categorie => 
        categorie.Name.Equals("Victor"));

      Product p3 = new Product();
      p3.Name = "Donzinho";
      p3.Categorie = database.Categories.First(categorie => 
        categorie.Name.Equals("Mariana"));

      Product[] products = { p1, p2, p3 };

      database.AddRange(products);
      database.SaveChanges();*/

      /*List<Product> productList = 
        database.Products.Include(p => p.Categorie).ToList();

      productList.ForEach(product =>
      {
        Console.WriteLine(product.ToString());
      });*/

      List<Product> productsFromCategorie = 
      database.Products.Where(p => p.Categorie.Id == 1).ToList(); //using LazyLoading

      productsFromCategorie.ForEach(p =>
      {
        Console.WriteLine(p.ToString());
      });

      return Content("Relationship");
    }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
