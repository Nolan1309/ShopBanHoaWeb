using ShopBanHoa.Connection;
using ShopBanHoa.Model_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHoa.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DataConnection db = new DataConnection();
        public ActionResult Index()
        {
            Product_USER sp = new Product_USER();
            ViewBag.listsp = sp.GetAccountList();
            return View();
        }
    }
}