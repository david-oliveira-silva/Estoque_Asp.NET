using ProjetoWeb.Dao;
using ProjetoWeb.Models;

namespace ProjetoWeb.Service
{
    public class ProdutoService
    {
        private IProdutoDAO produtoDAO;

        public ProdutoService(IProdutoDAO produtoDAO)
        {
            this.produtoDAO = produtoDAO;
        }

        public void CadastrarProduto(string nomeProduto, decimal valorProduto)
        {

            if (string.IsNullOrEmpty(nomeProduto))
            {
                throw new Exception("Produto não pode ser vazio");
            }
            if (valorProduto < 0)
            {
                throw new Exception("produto não pode ser negativo");
            }

            var novoProduto = new ProdutoModel(nomeProduto, valorProduto);
            produtoDAO.cadastrarProduto(novoProduto);
        }

        public void RemoverProduto(ProdutoModel produtoModel)
        {
            if (produtoModel == null)
            {

                throw new Exception("Produto não encontrado");
            }

            produtoDAO.removerProduto(produtoModel);
        }

        public void editarProduto(ProdutoModel produtoModel)
        {
            if(produtoModel == null)
            {
                throw new Exception("Produto não encontrado");
            }
            produtoDAO.atualizarProduto(produtoModel);
        }

        public List<ProdutoModel> listarProdutos()
        {

             var produto = produtoDAO.listarProduto();
            return produto.OrderBy(p => p.produtoID).ToList();
        }
    }
}
