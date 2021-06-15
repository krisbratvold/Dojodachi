using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojodachi.Models;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet("")]
        public IActionResult Index(string message)
        {
            Pet sessionPet = HttpContext.Session.GetObjectFromJson<Pet>("pet");
            if (sessionPet == null)
            {
                sessionPet = new Pet();
                HttpContext.Session.SetObjectAsJson("pet", sessionPet);
            }
            ViewBag.message = message;
            return View("Index", sessionPet);
        }

        [HttpGet("/play")]
        public IActionResult Play()
        {
            Pet sessionPet = HttpContext.Session.GetObjectFromJson<Pet>("pet");
            sessionPet.Play();
            HttpContext.Session.SetObjectAsJson("pet", sessionPet);
            return RedirectToAction("Index" , new {message = "You played with your pet!"});
        }

        [HttpGet("/feed")]
        public IActionResult Feed()
        {
            Pet sessionPet = HttpContext.Session.GetObjectFromJson<Pet>("pet");
            sessionPet.Feed();
            HttpContext.Session.SetObjectAsJson("pet", sessionPet);
            return RedirectToAction("Index", new {message = "You fed your pet!"});
        }

        [HttpGet("/work")]
        public IActionResult Work()
        {
            Pet sessionPet = HttpContext.Session.GetObjectFromJson<Pet>("pet");
            sessionPet.Work();
            HttpContext.Session.SetObjectAsJson("pet", sessionPet);
            return RedirectToAction("Index" , new {message = "You went to work!"});
        }

        [HttpGet("/sleep")]
        public IActionResult Sleep()
        {
            Pet sessionPet = HttpContext.Session.GetObjectFromJson<Pet>("pet");
            sessionPet.Sleep();
            HttpContext.Session.SetObjectAsJson("pet", sessionPet);
            return RedirectToAction("Index", new {message = "You went to sleep!"});
        }
        [HttpGet("/reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
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
