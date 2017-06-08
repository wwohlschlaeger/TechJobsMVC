using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

		// TODO #1 - Create a Results action method to process 
		// search request and display results

		// What I'm doing doesnt work.  I'm not sure I'm understanding what is required

		public IActionResult Results(string searchType, string searchTerm)
		{
			List<Dictionary<string, string>> results;
			if (searchType.Equals("all"))
			{
				results = JobData.FindByValue(searchTerm);
				ViewBag.title = "All Listings for " + searchTerm;
				ViewBag.columns = ListController.columnChoices;
				ViewBag.jobs = results;
				return View("Index");
			}

			else
			{
				results = JobData.FindByColumnAndValue(searchType, searchTerm);
				ViewBag.title = "Results containing " + searchTerm;
				ViewBag.columns = ListController.columnChoices;
				ViewBag.jobs = results;
				return View("Index");
				
			}
		}
    }
}
