using Microsoft.AspNetCore.Mvc;
using Votes.BL;
using Votes.Data;
using Votes.Models;

namespace Votes.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        ClsVotes voterContext = new ClsVotes();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit(int? Id)
        {
            var vote = new Voter();
            if(Id != null)
            {
                vote = voterContext.GetById(Convert.ToInt32(Id));
            }
            return View(vote);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Voter voter)
        {
            if (!ModelState.IsValid)
                View("Edit", voter);

            //Save in database
            voterContext.Save(voter);

            return RedirectToAction("List");
        }
        public IActionResult List()
        {
            return View(voterContext.GetAll());
        }
        public IActionResult Delete(int id)
        {
            voterContext.Delete(id);
            return RedirectToAction("List");
        }
}
}
