using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore.Storage;


namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();

        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        ContatoModel Apagar(ContatoModel contato);

    }
}
