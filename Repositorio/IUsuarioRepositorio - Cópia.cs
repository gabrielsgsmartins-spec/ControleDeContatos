using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore.Storage;


namespace ControleDeContatos.Repositorio
{
    public interface IUsuariooRepositorio
    {
       UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();

        UsuarioModel Adicionar(UsuarioModel contato);
        UsuarioModel Atualizar(UsuarioModel contato);
        UsuarioModel Apagar(UsuarioModel contato);

    }
}
