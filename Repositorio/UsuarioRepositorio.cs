using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.OrderBy(x => x.Id).ToList();
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //gravar no banco de dados
          usuario.DataCadastro = DateTime.Now;

            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;


        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);

        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarPorId(usuario.Id);

            if (usuario == null) throw new System.Exception("Gouve um erro na atualização do contato");

            usuario.Id = usuario.Id;
            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.Login = usuario.Login;
            usuarioDb.DataAtualização = usuario.DataCadastro;


            _bancoContext.Usuarios.Update(usuarioDb);
            _bancoContext.SaveChanges();

            return usuarioDb;
        }

        public UsuarioModel Apagar(UsuarioModel usuario)
        {
            _bancoContext.Usuarios.Remove(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }
    }

    public interface IUsuarioRepositorio
    {
        UsuarioModel Adicionar(UsuarioModel usuario);
        List<UsuarioModel> BuscarTodos();
    }
}
