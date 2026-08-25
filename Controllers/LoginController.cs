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
        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
           try
            {
                if(ModelState.IsValid)
                {
                   UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);

                            return RedirectToAction("Index", "Home");
                        }
                       TempData["MessageError"] = $"A senha do usuario é inválida. Por favor tente novamente";
                    }
                    TempData["MessageError"] = $"O login ou senha são inválidos(as). Por favor tente novamente";





                }

                return View("Index");
               



            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuario, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }


    }

}
