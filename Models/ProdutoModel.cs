namespace ProjetoWeb.Models
{
    public class ProdutoModel
    {
        public int produtoID { get; set; }
        public string nomeProduto { get; set; }
        public decimal valorProduto { get; set; }
   

        public ProdutoModel()
        {

        }
    public ProdutoModel(string nomeProduto, decimal valorProduto)
        {
            this.nomeProduto = nomeProduto;
            this.valorProduto = valorProduto;

        }
    }
}
