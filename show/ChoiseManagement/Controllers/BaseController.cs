using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChoiseManagement.Models.Hotel;

namespace ChoiseManagement.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        HotelModel db = new HotelModel();
        public BaseController()
        {

            ViewBag.Categories = db.Food_Categories.OrderBy(c => c.Category).ToList();
        }
    }
}