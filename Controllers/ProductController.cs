using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIApplication.Model;

namespace WebAPIApplication.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMapper mapper;
        IRepository repository;
        public ProductController(IMapper map, IRepository rep)
        {
            mapper = map;
            repository = rep;
            rep.Map = mapper;
        }

        [HttpGet]
        [Route("Product/All")]
        public IActionResult GetAllProducts()
        {
            return Ok(repository.GetAll());
        }

        [HttpGet]
        [Authorize]
        [Route("Product/GetProdust/{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(repository.GetProduct(id));
        }

        [HttpPost]
        [Authorize("read:messages")]
        [Route("Product/Update")]
        public IActionResult UpdateProduct([FromBody]ProductDTO input)
        {
            repository.UpdateProduct(input);

            return Ok(new
            {
                Message = "Product updated sucessfuly."
            });
        }

        // This is a helper action. It allows you to easily view all the claims of the token.
        [HttpGet("claims")]
        public IActionResult Claims()
        {
            return Ok(User.Claims.Select(c =>
                new
                {
                    c.Type,
                    c.Value
                }));
        }
    }
}
