using ATM_Challenge.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace ATM_Challenge.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(Models.Shared.RequestById request)
        {
            Models.Card.Detail response = new()
            {
                Card = Business.Card.Get(request)
            };
            return View(response);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Models.Card.Edit Card)
        {
            
            /*if (!ModelState.IsValid)
            {
                return View(request);
            }*/

            if (Card.Attempts <4)
            {
                Card.Attempts = Card.Attempts + 1;
            }
            else
            {
                Card.Lock = true;              
            }
            Business.Card.Update(Card);
            Models.Shared.RequestById request = new()
            {
                Id = Card.IdCard
            };
            Models.Card.Detail response = new()
            {
                Card = Business.Card.Get(request)
            };
            return View(response);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}