using webapi.healthclinica.tarde.Context;
using webapi.healthclinica.tarde.Domains;
using webapi.healthclinicaapi.tarde.Interfaces;

namespace webapi.healthclinicaapi.tarde.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthContext _healthContext;

        public PacienteRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid Id, Paciente paciente)
        {
            try
            {
                var PacienteExistente = _healthContext.Paciente.Find(Id);

                if (PacienteExistente != null)
                {
                    PacienteExistente.RG = paciente.RG; 
                    PacienteExistente.CPF = paciente.CPF;
                    PacienteExistente.CEP = paciente.CEP;
                    PacienteExistente.Endereco = paciente.Endereco;
                    PacienteExistente.Telefone = paciente.Telefone;
                  
                    _healthContext.Update(PacienteExistente);
                    _healthContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Atualizar Paciente", ex);
            }
        }

        public Paciente BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Paciente.FirstOrDefault(p => p.IdPaciente == id); 
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Buscar Paciente por Id"); 
            }
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
                _healthContext.Add(paciente); 
                _healthContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Cadastrar Paciente!", ex); 
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                var paciente = _healthContext.Paciente.Find(id);
                if (paciente != null)
                {
                    _healthContext.Paciente.Remove(paciente);
                    _healthContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Deletar Paciente", ex); 
            }
         
        }

        public List<Paciente> Listar()
        {
            try
            {
                return _healthContext.Paciente.ToList(); 
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Listar Pacientes", ex); 
            }
        }
    }
}
