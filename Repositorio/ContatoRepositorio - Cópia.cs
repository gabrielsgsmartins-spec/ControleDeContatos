using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.OrderBy(x => x.Id).ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //gravar no banco de dados
          
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;


        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);

        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.Id);

            if (contatoDb == null) throw new System.Exception("Gouve um erro na atualização do contato");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Email;

            _bancoContext.Contatos.Update(contatoDb);
            _bancoContext.SaveChanges();

            return contatoDb;
        }

        public ContatoModel Apagar(ContatoModel contato)
        {
            _bancoContext.Contatos.Remove(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
    }
}
