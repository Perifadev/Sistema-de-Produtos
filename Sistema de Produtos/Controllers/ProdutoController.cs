using Microsoft.AspNetCore.Mvc;
using Sistema_de_Produtos.Model;
using Sistema_de_Produtos.Repository.Interfaces;
using System.Globalization;

namespace Sistema_de_Produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Produtos>>> getTodosProdutos()
        {
            List<Produtos> produtos = await _produtoRepository.getTodosProdutos();

            if (produtos == null)
            {
                return NotFound("Nenhum produto cadastrado");
            }

            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> getProdutosId(int id)
        {
            Produtos produtos = await _produtoRepository.getProdutosId(id);
            if (produtos == null)
            {
                return NotFound($"O produto {id}, não foi encontrado");
            }
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult<Produtos>> createProdutos([FromBody] Produtos produtos)
        {
            Produtos produto = await _produtoRepository.addProdutos(produtos);
            return Ok(new { Mensagem = "Produto Criado", produto });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produtos>> updateProdutos([FromBody] Produtos produtos, int id)
        {
            produtos.Id = id;
            Produtos produto = await _produtoRepository.atualizarProdutos(produtos, id);
            return Ok(new { Mensagem = "Produto atualizado", produto });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produtos>> deleteProdutos(int id)
        {
            
            bool produto = await _produtoRepository.removerProdutos(id);
            return Ok(new { Mensagem = "Produto apagado",produto });

        }

    }
}
