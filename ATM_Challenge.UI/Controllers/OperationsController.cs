using ATM_Challenge.Models;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ATM_Challenge.UI.Controllers
{
    public class OperationsController : Controller
    {
        /*private readonly ILogger<LoginController> _logger;

        public OperationsController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index(Models.Shared.RequestById request)
        {
            return View(request);
        }
        public IActionResult Balance(Models.Shared.RequestById request)
        {
            Models.Card.Detail response = new()
            {
                Card = Business.Card.Get(request)
            };            
            return View(response);
        }
        public IActionResult Withdrawal(Models.Shared.RequestById request)
        {
            Models.Card.Detail response = new()
            {
                Card = Business.Card.Get(request)
            };
            return View(response);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Withdrawal(Models.Withdrawal.Edit withdrawal)
        {
            if (!ModelState.IsValid)
            {
                return View(withdrawal.IdCard);
            }
            Business.Withdrawal.Save(withdrawal);
            Models.Shared.RequestById request = new()
            {
                Id = withdrawal.IdCard
            };
            Models.Balance.Edit Balance=new(){ 
                IdCard = withdrawal.IdCard,
                RegDate = withdrawal.RegDate,
                Amount = (Business.Card.Get(request).Balance - (withdrawal.Amount))
            };
            Business.Balance.Save(Balance);
            return RedirectToAction("Report", new { id = withdrawal.IdCard });
        }
        public IActionResult Report(Models.Shared.RequestById request)
        {
            request.Id = 1;
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