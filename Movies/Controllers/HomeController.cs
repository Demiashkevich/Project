using Movies.Database;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new IndexPageModel();

            return View(model);
        }

        public ActionResult Movies(string genre)
        {
            MoviesPageModel model;

            if (String.IsNullOrEmpty(genre))            
                model = new MoviesPageModel();            
            else
                model = new MoviesPageModel(genre);

            return View(model);
        }

        public ActionResult AboutMovies(int id) 
        {
            var reader = new DataAboutMovie();
            return View(reader.GetAboutMovieModel(id));
        }

        public ActionResult FindMovie(string genre)
        {
            return RedirectToAction("Movies", "Home", new { genre = genre });
        }

    }
}
