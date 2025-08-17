using Microsoft.AspNetCore.Mvc;
using ProjetoWeb.Dao;
using ProjetoWeb.Models;
using ProjetoWeb.Service;

namespace ProjetoWeb.Controllers
{
    public class ProdutoController : Controller
    {

        private ProdutoService produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

      

        [HttpPost]
        public IActionResult CadastrarProdutos(string nomeProduto, decimal valorProduto)
        {

            try
            {
                produtoService.CadastrarProduto(nomeProduto, valorProduto);
                TempData["Sucesso"] = "Produto cadastrado com sucesso";
                return RedirectToAction("CadastrarProdutos");
            }
            catch (Exception ex)
            {
                TempData["ERRO"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult ListarProdutos()
        {
         var listProduto = produtoService.listarProdutos();
            return View(listProduto);
        }
        
        public IActionResult CadastrarProdutos()
        {
           
            return View();
        }
    } 
}
