using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace MCVControldeErrores.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
       

            return View();
        }
        [HandleError(View="VistaError",ExceptionType =typeof(DivideByZeroException))]
        [HandleError(View = "VistaSql", ExceptionType = typeof(SqlException))]
        public ActionResult Contact()
        {
            int num1 = 7;
            int num2 = 0;
            int resultado = num1 / num2;
            ViewBag.Message = "Your contact page.";
           

            return View();
        }
    }
}