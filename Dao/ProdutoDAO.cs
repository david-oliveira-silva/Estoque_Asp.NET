using FirebirdSql.Data.FirebirdClient;
using ProjetoWeb.Data;
using ProjetoWeb.Models;
using System.Security.Cryptography;

namespace ProjetoWeb.Dao
{
    public class ProdutoDAO:IProdutoDAO
    {
        FbConnection fbConnection;

        public ProdutoDAO()
        {
            fbConnection = FirebirdConnection.GetFbConnection();
        }

        void IProdutoDAO.cadastrarProduto(ProdutoModel produtoModel)
        {
            FirebirdConnection.OpenConnection(fbConnection);

            string queryInsert = "INSERT INTO produtos(nomeProduto,valorProduto) VALUES(@nomeProduto,@valorProduto)";
           
            using (var cmdInsert = new FbCommand(queryInsert, fbConnection))
            {
                cmdInsert.Parameters.AddWithValue("@nomeProduto",produtoModel.nomeProduto);
                cmdInsert.Parameters.AddWithValue("@valorProduto", produtoModel.valorProduto);
                cmdInsert.ExecuteNonQuery();
            }
            FirebirdConnection.CloseConnection(fbConnection);
        }

        void IProdutoDAO.removerProduto(ProdutoModel produtoModel)
        {
            FirebirdConnection.OpenConnection(fbConnection);
            string queryDelete = "DELETE FROM produtos WHERE produtoID = @produtoID";

            using(var cmdDelete = new FbCommand(queryDelete, fbConnection))
            {
                cmdDelete.Parameters.AddWithValue("@produtoID", produtoModel.produtoID);
                cmdDelete.ExecuteNonQuery ();
            }
            FirebirdConnection.CloseConnection(fbConnection);

        }

        void IProdutoDAO.atualizarProduto(ProdutoModel produtoModel)
        {
            FirebirdConnection.OpenConnection(fbConnection);

            string queryUpdate = "UPDATE produtos SET nomeProduto = @nomeProduto ,valorProduto = @valorProduto WHERE produtoId = @produtoID";

            using (var cmdUpdate = new FbCommand(queryUpdate, fbConnection))
            {
                cmdUpdate.Parameters.AddWithValue("@produtoID", produtoModel.produtoID);
                cmdUpdate.Parameters.AddWithValue("@nomeProduto", produtoModel.nomeProduto);
                cmdUpdate.Parameters.AddWithValue("@valorProduto", produtoModel.valorProduto);
                cmdUpdate.ExecuteNonQuery() ;
            }
            FirebirdConnection.CloseConnection(fbConnection);

        }
        List<ProdutoModel> IProdutoDAO.listarProduto()
        {

            FirebirdConnection.OpenConnection(fbConnection);

            List<ProdutoModel> listProduto = new List<ProdutoModel>();

            string querySelect = "SELECT * FROM produtos";

            using (var cmdSelect = new FbCommand(querySelect,fbConnection))
            {

               using(var reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        ProdutoModel produtoModel = new ProdutoModel() { 
                        produtoID = reader.GetInt32(reader.GetOrdinal("produtoID")),
                        nomeProduto = reader.GetString(reader.GetOrdinal("nomeProduto")),
                        valorProduto = reader.GetDecimal(reader.GetOrdinal("valorProduto"))
                        };
                        listProduto.Add(produtoModel);

                    }
                }
            }
            FirebirdConnection.CloseConnection(fbConnection);
            return listProduto;
        }


       
        

        
    }
}
