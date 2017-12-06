using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class FormController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("/submit")]
        public IActionResult Submit(string firstName, string lastName, int age, string email, string password)
        {
            Form user = new Form
            {
                firstName = firstName,
                lastName = lastName,
                age = age,
                email = email,
                password = password
            };
            TryValidateModel(user);
            if(ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
            }
            return View("Index");
        }

        [HttpGet]
        [Route("/success")]
        public IActionResult Success()
        {
            return View("Success");
        }
    }
}