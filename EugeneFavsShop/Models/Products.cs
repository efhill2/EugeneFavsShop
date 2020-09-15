using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EugeneFavsShop.Models
{
    [Table("Product")]
    public class Products /*: Categories*/
    {
        [Key]
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public string ProductDescription { get; set; }

        // Create : Add a record to the table
        public static Products Create(string pname, int pquantity, Decimal pprice, string pdescription)
        {
            Products product = new Products()
            {
                ProductName = pname,
                Quantity = pquantity,
                Price = pprice,
                ProductDescription = pdescription
            };
            
            IDbConnection db = new SqlConnection("Server=.;Database=EugeneFavsShop;user id=sa; password=Inari2007");
            long pID = db.Insert<Products>(product);

            product.ProductID = pID;

            return product;
        }

        //Read: Read a record(s) from the table
        public static Products Read(long pID)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=EugeneFavsShop;user id=sa; password=Inari2007");
            Products product = db.Get<Products>(pID);
            return product;

        }
         
        public static List<Products> ListAll()
        {
            IDbConnection db = new SqlConnection("Server=.;Database=EugeneFavsShop;user id=sa; password=Inari2007");
            List<Products> products = db.GetAll<Products>().ToList();
            return products;
        }

        //Update: Change an existing record in the table 
        public void Save()
        {
            IDbConnection db = new SqlConnection("Server=.;Database=EugeneFavsShop;user id=sa; password=Inari2007");
            db.Update(this);
        }

        //Delete: Remove an exisiting record from the table 
        public static void Delete(long pID)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=EugeneFavsShop;user id=sa; password=Inari2007");
            db.Delete(new Products() { ProductID = pID });
        }
    }
}
