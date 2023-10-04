using webapi.event_.tarde.Utils;
using webapi.healthclinica.tarde.Context;
using webapi.healthclinica.tarde.Domains;
using webapi.healthclinicaapi.tarde.Interfaces;

namespace webapi.healthclinicaapi.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly HealthContext _healthContext;

        public UsuarioRepository()
        {
            _healthContext = new HealthContext();
        }
        public void AtualizarPorId(Guid id, Usuario usuario)
        {
            try
            {
                Usuario usuarioExistente = _healthContext.Usuario.Find(id);

                if (usuarioExistente != null)
                {
                    usuarioExistente.Nome = usuario.Nome;
                    usuarioExistente.Email = usuario.Email;
                    usuarioExistente.Senha = Criptografia.GerarHash(usuario.Senha);

                    _healthContext.SaveChanges();

                }



            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Usuario.", ex);
            }

        }

        public Usuario BuscarPorEmailESenha(string Email, string Senha)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext.Usuario

                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    TipodeUsuario = new TipoDeUsuario
                    {
                        IdTipodeUsuario = u.IdTipodeUsuario,
                        TituloTipoUsuario = u.TipodeUsuario!.TituloTipoUsuario
                    }
                }).FirstOrDefault(u => u.Email == Email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }

            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,

                        TipodeUsuario = new TipoDeUsuario
                        {
                            IdTipodeUsuario = u.IdTipodeUsuario,
                            TituloTipoUsuario = u.TipodeUsuario!.TituloTipoUsuario
                        }
                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _healthContext.Usuario.Add(usuario);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {

            try
            {
                Usuario usuario = _healthContext.Usuario.Find(id);

                if (usuario != null)
                {
                    _healthContext.Usuario.Remove(usuario);
                    _healthContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao deletar Usuario", ex);
            }
        }

        public List<Usuario> Listar()
        {
            try
            {
                return _healthContext.Usuario.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar Usuario", ex);
            }
        }
    }

}

      

