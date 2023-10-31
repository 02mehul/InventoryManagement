using InventoryManagement.Common;
using InventoryManagement.Common.DTOs.Master;
using InventoryManagement.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using InventoryManagement.Service.Interface;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiBaseResponse<ProductDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetAll()
        {
            return Ok(ApiBaseResponse<IQueryable<ProductDTO>>.Success(_productService.GetAll()));
        }
    }
}


