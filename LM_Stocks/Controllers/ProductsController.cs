using LM_Stocks.Models;
using LM_Stocks.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LM_Stocks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRespository;

        public ProductsController(IProductRepository productRespository)
        {
            this.productRespository = productRespository;
        }

        //GET: /products
        [HttpGet]
        [Route("/products")]
        public IActionResult Index()
        {
            return StatusCode(200, productRespository.GetAll());
        }

        //POST: /products
        [HttpPost]
        [Route("/products")]
        public IActionResult Create([Bind("Name, Price, Weight, Quantity, Lot, Validity, Description")] Product product)
        {
            if (ModelState.IsValid)
            {
              product = new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Weight = product.Weight,
                    Quantity = product.Quantity,
                    Lot = product.Lot,
                    Validity = product.Validity,
                    Description = product.Description
                };
            }

            return StatusCode(201, productRespository.Add(product));
        }
    }
}
