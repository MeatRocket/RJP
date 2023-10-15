using Microsoft.AspNetCore.Mvc;
using RJP.DataAccess;
using RJP.Model;
using RJP_FrontEnd.Models;
using System.Diagnostics;

namespace RJP_FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCustomerInformation(int CustomerId)
        {
            Customer? customer = new Customer();

            CustomersDataAccess customersDataAccess = new CustomersDataAccess();

            customer = customersDataAccess.GetCustomerById(CustomerId);

            if (customer == null)
            {
                return Json(new { success = false });
            }

            return Json(new { success = true, customer = customer });
        }

        [HttpPost]
        public JsonResult CreateAccount(int CustomerId, double InitialCredit)
        {
            AccountsDataAccess accountsDataAccess = new AccountsDataAccess();

            bool IsAccountCreated = accountsDataAccess.CreateAccount(CustomerId, InitialCredit);

            if (IsAccountCreated)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }
}