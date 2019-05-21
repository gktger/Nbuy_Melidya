using Melidya.BusinessLayer;
using Melidya.Entity;
using Melidya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Melidya.Controllers
{
    public class HomeController : Controller
    {
        ProductManager productManager = new ProductManager();

        public ActionResult Index()
        {
            List<Products> products = productManager.GetProducts();
            return View(products);
        }

        public ActionResult AddBasket(int id)
        {
            if (Session["Basket"] == null)
            {
                List<SepetModel> basket = new List<SepetModel>();
                Session["Basket"] = basket;
            }
            List<SepetModel> sepet = Session["Basket"] as List<SepetModel>;
            Products product = productManager.GetProduct(id);
            if (sepet.Find(x => x.ProductID == id) != null)
            {
                SepetModel sepetModel = sepet.Find(x => x.ProductID == id);
                sepetModel.Stock += 1;
            }
            else
            {
                SepetModel model = new SepetModel();
                model.ProductID = product.ProductID;
                model.ProductName = product.ProductName;
                model.UnitPrice = product.UnitPrice;
                model.Stock = 1;
                sepet.Add(model);
            }

            Session["Basket"] = sepet;

            return RedirectToAction("Index");
        }

        public ActionResult Basket()
        {
            List<SepetModel> products = Session["Basket"] as List<SepetModel>;

            return View(products);
        }
    }
}