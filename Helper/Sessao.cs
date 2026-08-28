using ControleDeContatos.Controllers;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);

            _httpContext.HttpContext.Session.SetString("IdUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario(UsuarioModel usuario)
        {
            _httpContext.HttpContext.Session.Remove("IdUsuarioLogado");
        }
    }
}
