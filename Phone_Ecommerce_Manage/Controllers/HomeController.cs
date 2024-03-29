﻿using Microsoft.AspNetCore.Mvc;
using Phone_Ecommerce_Manage.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Phone_Ecommerce_Manage.Utilities;

namespace Phone_Ecommerce_Manage.Controllers
{
    public class HomeController : Controller
    {

        private readonly MobileShop_DBContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MobileShop_DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        

        public async Task<IActionResult> Index()
        {
            ViewBag.News = _context.News.OrderByDescending(x => x.CreateDate).Take(3).ToList();
            ViewBag.Managers = _context.Managers.ToList();
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Categorys = _context.CategoryNews.ToList();
            ViewBag.CommentRatings = _context.CommentRatings.OrderByDescending(x => x.CreateDate).Take(4).ToList();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}