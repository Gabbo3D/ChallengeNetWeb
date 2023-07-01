using ATM_Challenge.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Diagnostics;

namespace ATM_Challenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int i)
        {
            if(ViewBag.IdCard==null) ViewBag.IdCard = "";
            if(ViewBag.Title == null) ViewBag.Title = "";

            return View(i); //    <a id="search" name="id" value="    @foreach (var card in Model.Cards){string number = ((IEnumerable<ATM_Challenge.Models.Card.Objects.Card>)ViewBag.response).ToList().Where(x => x.Number == card.Number).Select(x => x.IdCard.ToString()).FirstOrDefault();}">  </a>
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(String Number)
        {            
            if(Number!=null){
                long IdCard = Business.Card.GetByNumber(Number).Value;
                ViewBag.IdCard = IdCard;
                ViewBag.Title = Number;
            }    
            else{
                ViewBag.IdCard = "";
                ViewBag.Title = "";
            }
            return View();
        }
        public ActionResult Details(Models.Shared.RequestById request)
        {
            Models.Card.Detail response = new()
            {
                Card = Business.Card.Get(request)
            };
            //response.Balance = Business.Balance.GetAllForActor(response.Card.IdCard);
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