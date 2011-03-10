using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Entities;
using Core.Repositories;

namespace MVCFirst.Controllers
{
    public class BlogController : Controller
    {
    	private IBlogRepository repository;

    	public BlogController(IBlogRepository repository)
		{
			this.repository = repository;
		}
        //
        // GET: /Blog/

        public ActionResult Index()
        {
        	
			return View(repository.GetPage(0,10));
        }

        //
        // GET: /Blog/Details/5

        public ActionResult Details(int id)
        {
        	var blog = repository.Get(id);
        	return View(blog);
        }

        //
        // GET: /Blog/Create

        public ActionResult Create()
        {
            return View();
        }


		
		
        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            try
            {
				repository.Save(blog);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
//        
        //
        // GET: /Blog/Edit/5

		public ActionResult Edit(int id)
		{
			var blog = repository.Get(id);
			return View("Create",blog);
		}

        //
        // POST: /Blog/Edit/5

        [HttpPost]
        public ActionResult Edit(long id,Blog blog)
        {
            try
            {
				repository.Save(blog);
				TempData["message"] = blog.Title + " has been saved.";
                return RedirectToAction("Index");
            }
            catch
            {
				return View("Create", blog);
			}
        }
//
        //
        // GET: /Blog/Delete/5
// 
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }
//
        //
        // POST: /Blog/Delete/5
//
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
                // TODO: Add delete logic here
// 
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
    }

	
}
