using Microsoft.AspNetCore.Mvc;

using waproject.Application.Dtos;
using waproject.Application.Produtos.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace waproject.WebApi.Controllers
{
    public class ProdutosController : ApiController
    {
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IList<ProdutoDto>> Get()
        {
            return await Mediator.Send(new GetProdutosQuery());
        }
    }
}
