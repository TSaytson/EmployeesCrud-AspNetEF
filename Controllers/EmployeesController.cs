using System.Linq;
using Microsoft.AspNetCore.Mvc;
using aspnetefcore.Models;
using aspnetefcore.Database;

namespace aspnetefcore.Controllers
{
  public class EmployeesController : Controller
  {
    private readonly ApplicationDBContext database;
    public EmployeesController(ApplicationDBContext database)
    {
      this.database = database;
    }

    public IActionResult Index()
    {
      var employees = database.Employees.ToList();
      return View(employees);
    }
    public IActionResult Signup()
    {
      return View();
    }

    public IActionResult Edit(int id){
      Employee employee = database.Employees.First(employee => employee.Id == id);
      return View("Signup", employee);
    }

    public IActionResult Delete(int id){
      Employee employee = database.Employees.First(employee => employee.Id == id);
      database.Employees.Remove(employee);
      database.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Save(Employee employee)
    {
      if (employee.Id == 0){
        database.Employees.Add(employee);

      } else {
        Employee existentEmployee = database.Employees.First(
          databaseEmployee => databaseEmployee.Id == employee.Id);
        existentEmployee.Nome = employee.Nome;
        existentEmployee.Salario = employee.Salario;
        existentEmployee.Cpf = employee.Cpf;
      }
      database.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}