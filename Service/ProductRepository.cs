using Assignment_12_1.Models;

namespace Assignment_12_1.Service
{
    public class ProductRepository : IproductRepository
    {
        private List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>();
            products.Add(new Product() { Id = 51, PName = "Benz", PDescription = "Benz New Car", ImageName = "Benz.jfif", Price = 153825 });
            products.Add(new Product() { Id = 52, PName = "Bugatti", PDescription = "Bugatti New Model", ImageName = "bugatti.jfif", Price = 372658 });
            products.Add(new Product() { Id = 53, PName = "Lamborghini", PDescription = "Lamborghini, do you want it?", ImageName = "lamborghini.jfif", Price = 435699 });
            products.Add(new Product() { Id = 54, PName = "Mclaren", PDescription = "What about McLaren?", ImageName = "mclaren.jfif", Price = 368999 });

        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DeleteProduct(int? id)
        {
            var product = products.Find(x => x.Id == id);
            if(product != null)
            products.Remove(product);
        }

        public int GetMaxId()
        {
            int id = products.Max(x => x.Id);
            return id;
        }

        public Product GetProduct(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return products.Find(x => x.Id == id);
            }
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void UpdateProduct(Product product)
        {
            var prod = products.Find(x => x.Id == product.Id);
            if(prod != null)
            {
                prod.Id = product.Id;
                prod.PName = product.PName;
                prod.PDescription = product.PDescription;
                prod.Price = product.Price;
                prod.ImageName = product.ImageName;
            }
        }
    }
}
