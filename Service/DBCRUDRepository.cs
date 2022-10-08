using Assignment_12_1.Models;

namespace Assignment_12_1.Service
{
    public class DBCRUDRepository : IproductRepository
    {
        private ProductContext _productContext;
        public DBCRUDRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public void AddProduct(Product product)
        {
            if(product.Manufacture.ToString() == "Benz")
            {
                product.MakeId = 1;
            }
            if (product.Manufacture.ToString() == "Bugatti")
            {
                product.MakeId = 2;
            }
            if (product.Manufacture.ToString() == "Lamborghini")
            {
                product.MakeId = 3;
            }
            if (product.Manufacture.ToString() == "McLaren")
            {
                product.MakeId = 4;
            }
            _productContext.Products.Add(product);
            _productContext.SaveChanges();
        }

        public void DeleteProduct(int? id)
        {
            var prod = _productContext.Products.Find(id);
            if(prod != null)
            {
                _productContext.Products.Remove(prod);
                _productContext.SaveChanges();
            }
        }

        public int GetMaxId()
        {
            return _productContext.Products.Max(x => x.Id) + 1;
        }

        public Product GetProduct(int? id)
        {
            return _productContext.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return _productContext.Products.ToList<Product>();
        }

        public void UpdateProduct(Product product)
        {
            var prod = _productContext.Products.Find(product.Id);
            if(product != null)
            {
                prod.Id = product.Id;
                prod.PName = product.PName;
                prod.Price = product.Price;
                prod.PDescription = product.PDescription;
                prod.ImageName = product.ImageName;
                prod.Manufacture = product.Manufacture;
                if (product.Manufacture.ToString() == "Benz")
                {
                    product.MakeId = 1;
                }
                if (product.Manufacture.ToString() == "Bugatti")
                {
                    product.MakeId = 2;
                }
                if (product.Manufacture.ToString() == "Lamborghini")
                {
                    product.MakeId = 3;
                }
                if (product.Manufacture.ToString() == "McLaren")
                {
                    product.MakeId = 4;
                }
                _productContext.SaveChanges();
            }
        }
    }
}
