using webapi.healthclinica.tarde.Context;
using webapi.healthclinica.tarde.Domains;
using webapi.healthclinicaapi.tarde.Interfaces;

namespace webapi.healthclinicaapi.tarde.Repositories
{
    public class TipoDeUsuarioRepository : ITipoDeUsuarioRepository
    {

        private readonly HealthContext _healthContext;

        public TipoDeUsuarioRepository() 
        {
        _healthContext = new HealthContext(); 
        }


        public void Atualizar(Guid id, TipoDeUsuario tipoDeUsuario)
        {
            try
            {
                var TipoUsuarioExistente = _healthContext.TipoDeUsuario.Find(id);
                if (TipoUsuarioExistente != null)
                {
                    TipoUsuarioExistente.TituloTipoUsuario = tipoDeUsuario.TituloTipoUsuario;
                    _healthContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar o tipo do Usuario!", ex);
            }
        }

      

        public TipoDeUsuario BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.TipoDeUsuario.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar o tipo do Usuario por Id", ex);
            }
        }

        public TipoDeUsuario BuscarPorId()
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoDeUsuario tipoDeUsuario)
        {
            try
            {
                _healthContext.TipoDeUsuario.Add(tipoDeUsuario);

                _healthContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Cadastrar o Tipo de Usuario!", ex);
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                var tipoDeUsuario = _healthContext.TipoDeUsuario.Find(id);
                if (tipoDeUsuario != null)
                {
                    _healthContext.TipoDeUsuario.Remove(tipoDeUsuario);
                    _healthContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Deletar o Tipo de Usuario!", ex);
            }
        }

        public List<TipoDeUsuario> Listar()
        {
            try
            {
                return _healthContext.TipoDeUsuario.ToList();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar os tipos de Usuario!", ex);
            }
        }
    }
}
