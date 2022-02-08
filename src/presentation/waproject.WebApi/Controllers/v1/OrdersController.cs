using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using waproject.Application.Dtos.Orders;
using waproject.Application.Order.Queries;

namespace waproject.WebApi.Controllers.v1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : ApiController
    {
        [HttpGet]
        public async Task<OrdersListDto> Get([FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "pageSize")] int pageSize = 20)
        {
            return await Mediator.Send(new GetOrdersQuery(page, pageSize));
        }
    }
}
