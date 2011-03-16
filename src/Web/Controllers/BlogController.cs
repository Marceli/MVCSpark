using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Entities;
using Core.Repositories;
using NHibernate.Linq;

namespace MVCFirst.Controllers
{
    public class BlogController : Controller
    {
		private IDb db;

    	public BlogController(IDb db)
		{
			this.db = db;
		}
        //
        // GET: /Blog/

        public ActionResult Index()
        {
        	
			return View(db.Blogs.Take(10).Skip(0).ToList());
        }

        //
        // GET: /Blog/Details/5

        public ActionResult Details(int id)
        {
        	var blog = db.Blogs.Where(b => b.Id == id).Fetch(b => b.Comments).ToList()[0];
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
				db.Session.Save(blog);
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
			var blog = db.Blogs.Where(b=>b.Id==id).Fetch(b=>b.Comments).ToList()[0];
			return View("Create",blog);
		}

        //
        // POST: /Blog/Edit/5

        [HttpPost]
        public ActionResult Edit(long id,Blog blog)
        {
            try
            {
				db.Session.Save(blog);
				TempData["message"] = blog.Title + " has been saved.";
                return RedirectToAction("Index");
            }
            catch
            {
				return View("Create", blog);
			}
        }

        
        // GET: /Blog/Delete/5
 
        public ActionResult Delete(int id)
        {
        	var blog = db.Blogs.Where(b => b.Id == id).Fetch(b => b.Comments).ToList()[0];
			return View(blog);
            
        }

        
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
