using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{

    public class LoginController : Controller
    {
        public readonly IUsuarioRepositorio _usuarioRepositorio;
        public readonly Isessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                                Isessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {

            //Se o usuario estiver logado redireciona para a home
            if (_sessao.BuscarSessaoUsuario() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario(_sessao.BuscarSessaoUsuario());
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        // Corrigido aqui: MensagemErro em português
                        TempData["MensagemErro"] = "A senha do usuário é inválida. Por favor tente novamente.";
                        return View("Index");
                    }

                    // Corrigido aqui: MensagemErro em português
                    TempData["MensagemErro"] = "O login ou senha são inválidos. Por favor tente novamente.";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}