using SHOPPINGCARTPROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOPPINGCARTPROJECT.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ShoppingCartDbEntities obj;
        public HomeController()
        {
            obj = new ShoppingCartDbEntities();
        }

        public ActionResult Index()
        {
            IEnumerable<Shopping> listOfShopping = (from objItem in obj.Product
                                                    select new Shopping()
                                                    {
                                                        Image = objItem.Image,
                                                        ProductName = objItem.ProductName,
                                                        Description = objItem.Description,
                                                        Price = objItem.Price,
                                                        ProductId = objItem.ProductId,

                                                    }).ToList();
            return View(listOfShopping);
        }
        
        public ActionResult GetDescription(Shopping m)
        {

            return View(m);
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}