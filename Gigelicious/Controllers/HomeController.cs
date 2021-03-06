﻿using Gigelicious.Models;
using Gigelicious.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Gigelicious.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var upcomingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g=>g.Genre)
                .Where(g => g.DateTime > DateTime.Now && g.IsCancelled == false);


            var viewModel = new GigViewModel()
            {
                UpCominGigs = upcomingGigs,
                IsAuthenticated = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs"

            };






            return View("Gigs", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        


    }
}