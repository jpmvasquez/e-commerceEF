using E_Commerce_Project.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text;

namespace E_Commerce_Project.Controllers
{
    public class UsersController : Controller
    {
        public SqlConnection Conn;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNewUser()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult AddNewUser(Person person)
        //{
        //    //Person person = new Person(firstName, lastName, email);



            
        //    return View(person);
        //}

    }    
}
