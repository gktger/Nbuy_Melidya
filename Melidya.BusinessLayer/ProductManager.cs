using Melidya.DataAccessLayer;
using Melidya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melidya.BusinessLayer
{
    public class ProductManager
    {
        Repository<Products> repo = new Repository<Products>();

        public List<Products> GetProducts()
        {
            return repo.List();
        }

        public Products GetProduct(int id)
        {
            return repo.Find(x => x.ProductID == id);
        }
    }
}
