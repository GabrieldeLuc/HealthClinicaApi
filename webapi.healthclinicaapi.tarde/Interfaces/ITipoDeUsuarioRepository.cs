using webapi.healthclinica.tarde.Domains;

namespace webapi.healthclinicaapi.tarde.Interfaces
{
    public interface ITipoDeUsuarioRepository
    {
        void Cadastrar(TipoDeUsuario tipoDeUsuario);

        void Deletar(Guid id);

        List<TipoDeUsuario> Listar();

        TipoDeUsuario BuscarPorId();

        void Atualizar(Guid id, TipoDeUsuario tipoDeUsuario); 

    }
}
