using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WebAPIApplication.Model
{
    public class Repository : IRepository
    {
        public IMapper Map { get; set; }
        List<Product> products = new List<Product>();
        public Repository()
        {
            

            products.Add(new Product { Id = 1, Name = "First", Price = 100.00m });
            products.Add(new Product { Id = 2, Name = "Second", Price = 200.00m });
            products.Add(new Product { Id = 3, Name = "Third", Price = 300.00m });
        }
        public ProductDTO GetProduct(int id)
        {
            Product p = products.FirstOrDefault(pr => pr.Id == id);

            return Map.Map<ProductDTO>(p);
        }

        public void UpdateProduct(int id,ProductDTO input)
        {
            Product p = products.FirstOrDefault(pr => pr.Id == id);
            p = Map.Map<Product>(input);
              
        }
    }
}
