using ProjetoWeb.Models;

namespace ProjetoWeb.Dao
{
    public interface IProdutoDAO
    {
        void cadastrarProduto(ProdutoModel produtoModel);
        void removerProduto(ProdutoModel produtoModel);

        void atualizarProduto(ProdutoModel produtoModel);

        List<ProdutoModel> listarProduto();
        
    }
}
