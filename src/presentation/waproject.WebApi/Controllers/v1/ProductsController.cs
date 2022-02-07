using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using waproject.Application.Dtos.Products;
using waproject.Application.Product.Queries;

namespace waproject.WebApi.Controllers.v1
{
    public class ProductsController : ApiController
    {
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IList<ProductDto>> Get()
        {
            return await Mediator.Send(new GetProductQuery());
        }
    }
}
