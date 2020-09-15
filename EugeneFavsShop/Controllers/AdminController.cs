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
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            List<Products> products = Products.ListAll();

            return View(products);
            //IDbConnection db = new SqlConnection("Server=.;Database=EugeneFavsShop;user id=sa; password=Inari2007");
            //db.Open();

            //List<Products> product = db.Query<Products>("select * from Product").AsList<Products>();

            //db.Close();

            //return View(product);
            
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Add(/*string pname, int pquantity, int pprice, string pdescription*/)
        {
            Products newproduct = Products.Create(ProductName, pquantity, pprice, pdescription);
            return View(newproduct);
        }
    }
}
