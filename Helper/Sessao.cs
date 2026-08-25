using ControleDeContatos.Models;
using System.Text.Json;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using ControleDeContatos.Controllers;

namespace ControleDeContatos.Helper
{
    public class Sessao : Isessao
    {
            private readonly IHttpContextAccessor? _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public UsuarioModel BuscarSessaoUsuario()
        {
string sessaoUsuario = _httpContext.HttpContext.Session.GetString("IdUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }
            return JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            string json = JsonSerializer.Serialize(usuario);
            _httpContext.HttpContext.Session.SetString("IdUsuarioLogado", usuario.Id.ToString());
        }

        public void RemoverSessaoUsuario(UsuarioModel usuario)
        {
            _httpContext.HttpContext.Session.Remove("IdUsuarioLogado");
        }
    }
}
