using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EugeneFavsShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EugeneFavsShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {

            IDbConnection db = new SqlConnection("Server=.;Database=EugeneFavsShop;user id=sa; password=Inari2007");
            db.Open();

            List<Products> product = db.Query<Products>("select * from Product").AsList<Products>();

            db.Close();

            return View(product);            
        }
        public IActionResult Detail(int productID)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=EugeneFavsShop;user id=sa; password=Inari2007");
            db.Open();

            Products prodresults = db.QuerySingle<Products>($"select * from Product where ProductID = {productID}");

            db.Close();

            return View(prodresults);
        }
    }

}
