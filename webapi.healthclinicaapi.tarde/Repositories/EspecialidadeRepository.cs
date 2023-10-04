using webapi.healthclinica.tarde.Context;
using webapi.healthclinica.tarde.Domains;
using webapi.healthclinicaapi.tarde.Interfaces;

namespace webapi.healthclinicaapi.tarde.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {

        private readonly HealthContext _healthContext;

        public EspecialidadeRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
                _healthContext.Especialidade.Add(especialidade); 
                _healthContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Cadastrar Especialidade!", ex); 
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                var especialidade = _healthContext.Especialidade.Find(id);
                if (especialidade != null)
                {
                    _healthContext.Especialidade.Remove(especialidade);
                    _healthContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Deletar Especialidade!", ex); 
            }
        }

        public List<Especialidade> Listar()
        {
            try
            {
                return _healthContext.Especialidade.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Listar Especialidade!", ex); 
            }
        }
    }
}
