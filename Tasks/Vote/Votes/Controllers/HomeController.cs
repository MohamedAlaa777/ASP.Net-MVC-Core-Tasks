using Microsoft.AspNetCore.Mvc;
using Votes.Data;
using Votes.Models;
namespace Votes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View(new Voter());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Voter voter)
        {
            if (!ModelState.IsValid) 
                View("Index",voter);

            //Save in data base
            VoteContext voterContext = new VoteContext();
            voterContext.TbVotes.Add(voter);
            voterContext.SaveChanges();
            
            return RedirectToAction("List");
        }
        public IActionResult List (Voter voter)
        {
            VoteContext voterContext = new VoteContext();
            var Lstvotes = voterContext.TbVotes.ToList();
            return View(Lstvotes);
        }
    }
}
