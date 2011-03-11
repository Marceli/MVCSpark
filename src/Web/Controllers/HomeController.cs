using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Entities;
using MVCFirst.Models;

namespace MVCFirst.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			int hour = DateTime.Now.Hour;
			ViewData["greetings"] = (hour < 12 ? "Good morning" : "Good afternoon");
			

			return View();
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult RsvpForm(GuestResponse response)
		{
			return View("Thanks",response);
		}
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult RsvpForm()
		{
			return View();
		}
		public ActionResult Details()
		{
			return View(new Blog());
		}
	}
}
