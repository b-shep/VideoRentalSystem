using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalSystem.Models;
using VideoRentalSystem.ViewModels;

namespace VideoRentalSystem.Controllers
{

    public class MoviesController : Controller
    {

        [Route("Movies")]
        public ActionResult Movies()
        {
            return View();
        }




    }
}