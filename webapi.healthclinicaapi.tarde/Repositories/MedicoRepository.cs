using webapi.healthclinica.tarde.Context;
using webapi.healthclinica.tarde.Domains;
using webapi.healthclinicaapi.tarde.Interfaces;

namespace webapi.healthclinicaapi.tarde.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {

        private readonly HealthContext _healthContext;

        public MedicoRepository()
        {
            _healthContext = new HealthContext();
        }
        public Medico BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Medico.FirstOrDefault(m => m.IdMedico == id);  
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Buscar Médico pelo Id", ex); 
            }
        }

        public void Cadastrar(Medico medico)
        {
            try
            {
                _healthContext.Medico.Add(medico); 
                _healthContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Cadastrar Médico!", ex); 
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                var medico = _healthContext.Medico.Find(id);
                if (medico != null)
                {
                    _healthContext.Medico.Remove(medico); 
                    _healthContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao deletar Médico!", ex); 
            }
        }

        public List<Medico> Listar()
        {
            try
            {
                return _healthContext.Medico.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Listar Médicos!", ex); 
            }
        }
    }
}
