using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApplication.Model
{


    public interface IRepository
    {

        ICollection<ProductDTO> GetAll();
        ProductDTO GetProduct(int id);

        void UpdateProduct(ProductDTO input);

        IMapper Map { get; set; }
    }
}
