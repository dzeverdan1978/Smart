using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApplication.Model
{
    public interface IRepository
    {
        ProductDTO GetProduct(int id);

        void UpdateProduct(int id,ProductDTO input);

        IMapper Map { get; set; }
    }
}
