using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Produtos.Data;
using Sistema_de_Produtos.Model;
using Sistema_de_Produtos.Repository.Interfaces;
using System;

namespace Sistema_de_Produtos.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private ProdutoDBContext _dbContext;
        public ProdutoRepository(ProdutoDBContext produtoDBContext) {
            _dbContext = produtoDBContext;
        
        }


        public async Task<List<Produtos>> getTodosProdutos()
        {
           
            return await _dbContext.Produtos.ToListAsync();
        }
        public async Task<Produtos> getProdutosId(int id)
        {        
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Produtos> addProdutos(Produtos produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            _dbContext.SaveChanges();

            return produto;
        }

        public async Task<Produtos> atualizarProdutos(Produtos produto, int id)
        {
            Produtos produtoId = await getProdutosId(id);
            if (produtoId == null)
            {
                throw new Exception("O produto{Id} não foi encontrado");
            }
            produtoId.Nome = produto.Nome;
            produtoId.Preco = produto.Preco;

            _dbContext.Update(produtoId);
            _dbContext.SaveChanges();
            return produtoId;

        }

        public async Task<bool> removerProdutos(int id)
        {
            Produtos produtoId = await getProdutosId(id);
            if (produtoId == null)
            {
                throw new Exception("O produto {Id} não foi encontrado");
            }

            _dbContext.Produtos.Remove(produtoId);
            _dbContext.SaveChanges();

            return true;

        }
    }
}
