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
    }
}
