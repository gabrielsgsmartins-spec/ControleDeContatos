using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace ControleDeContatos.ViewComponents
{
    public class Menu : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {

            // Em ViewComponents/Menu.cs
            string SessaoDoUsuario = HttpContext.Session.GetString("IdUsuarioLogado");
            if (string.IsNullOrEmpty(SessaoDoUsuario))
            {
                // Em vez de null, retorne um conteúdo vazio!
                return Content(string.Empty);
            }
         else
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(SessaoDoUsuario);
                return View(usuario);
            }
            

        }

    }
}
