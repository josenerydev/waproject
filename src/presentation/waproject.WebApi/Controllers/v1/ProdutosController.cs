using Microsoft.AspNetCore.Mvc;
using waproject.Application.Produtos.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using waproject.Application.Dtos.Produtos;

namespace waproject.WebApi.Controllers.v1
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
