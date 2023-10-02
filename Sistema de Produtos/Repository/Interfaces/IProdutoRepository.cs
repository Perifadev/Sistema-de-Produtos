using Sistema_de_Produtos.Model;

namespace Sistema_de_Produtos.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produtos>> getTodosProdutos();
        Task<Produtos> getProdutosId(int id);
        Task<Produtos> addProdutos(Produtos produto);
        Task<Produtos> atualizarProdutos(Produtos produto, int id);
        Task<bool> removerProdutos(int id);

    }
}
