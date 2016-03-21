using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using PusherServer;


namespace Unicorn.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }



        public ActionResult HelloWorld()
        {
            var pusher = new Pusher("181640", "c691d4eeb0c0aa00d2bc", "174ae11faf7d6a247e9f", new PusherOptions() { Encrypted = true });

            for (int ctr = 1; ctr <= 10; ctr++) { 

                var result = pusher.Trigger("test_channel", "my_event", new { message = "hello world"  + ctr.ToString() });

            }
            return View();
        }

     
    }
}
