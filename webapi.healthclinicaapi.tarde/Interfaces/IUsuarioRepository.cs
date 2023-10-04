using webapi.healthclinica.tarde.Domains;

namespace webapi.healthclinicaapi.tarde.Interfaces
{
    public interface IUsuarioRepository
    {

        void Cadastrar(Usuario usuario);

        List<Usuario> Listar();

        Usuario BuscarPorId(Guid id); 

        Usuario BuscarPorEmailESenha (string Email, string Senha);

        void AtualizarPorId(Guid id, Usuario usuario);

        void Deletar(Guid id);


    }
}
