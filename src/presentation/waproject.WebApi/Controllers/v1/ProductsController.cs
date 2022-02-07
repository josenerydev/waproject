using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using waproject.Application.Dtos.Products;
using waproject.Application.Product.Commands.CreateProduct;
using waproject.Application.Product.Queries;

namespace waproject.WebApi.Controllers.v1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : ApiController
    {
        [HttpGet]
        public async Task<IList<ProductDto>> Get()
        {
            return await Mediator.Send(new GetProductsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
