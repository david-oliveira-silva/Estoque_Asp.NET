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

        [HttpGet]
        public IActionResult CadastrarProdutos()
        {

            return View();
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
        public IActionResult DeletarProduto(int?produtoID) { 
        
            var produto = produtoService.listarProdutos().FirstOrDefault(p => p.produtoID == produtoID);

            if (produto == null)
            {
                TempData["Erro"] = "Produto não encontrado!";
                return RedirectToAction("ListarProdutos"); // Redireciona para a lista de produtos
            }
            return View(produto);
        }

        [HttpPost]
        public IActionResult DeletarProduto(ProdutoModel produtoModel) {

            try
            {
                TempData["Sucesso"] = "Produto removido com sucesso";
                produtoService.RemoverProduto(produtoModel);
                return RedirectToAction("ListarProdutos");
            }
            catch (Exception ex) {

                TempData["Erro"] = ex.Message;
                return View(produtoModel);
            }
        }

        [HttpGet]

        public ActionResult EditarProduto(int? produtoID)
        {
            var produto = produtoService.listarProdutos().FirstOrDefault(p => p.produtoID == produtoID);
            return View(produto);
        }
        [HttpPost]
        public ActionResult EditarProduto(ProdutoModel produtoModel) {

            try
            {
                TempData["Sucesso"] = "Produto editado com sucesso";
                produtoService.editarProduto(produtoModel);
                return RedirectToAction("ListarProdutos");
            }
            catch (Exception ex) {
                TempData["Erro"] = ex.Message;
                return View(produtoModel) ;
            }
        }

        [HttpGet]
        public IActionResult ListarProdutos()
        {
         var listProduto = produtoService.listarProdutos();
            return View(listProduto);
        }
        
      
    } 
}
