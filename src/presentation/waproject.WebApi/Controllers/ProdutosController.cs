using Microsoft.AspNetCore.Mvc;

using waproject.Application.Dtos;
using waproject.Application.Produtos.Queries;

namespace waproject.WebApi.Controllers
{
    public class ProdutosController : ApiController
    {
        [HttpGet]
        public async Task<IList<ProdutoDto>> Get()
        {
            return await Mediator.Send(new GetProdutosQuery());
        }
    }
}
