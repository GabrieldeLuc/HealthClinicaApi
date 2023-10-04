using webapi.healthclinica.tarde.Context;
using webapi.healthclinica.tarde.Domains;
using webapi.healthclinicaapi.tarde.Interfaces;

namespace webapi.healthclinicaapi.tarde.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthContext _healthContext;

        public ConsultaRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid Id, Consulta consulta)
        {
            try
            {
                var consultaExistente = _healthContext.Consulta.Find(Id);

                if (consultaExistente != null)
                {
                    consultaExistente.DataConsulta = consulta.DataConsulta;
                    consultaExistente.HoraConsulta = consulta.HoraConsulta; 
                    consultaExistente.IdPaciente = consulta.IdPaciente;
                    consultaExistente.IdMedico= consulta.IdMedico;
                    consultaExistente.Descricao= consulta.Descricao;
                    consultaExistente.Feedback = consulta.Feedback;

                    _healthContext.Update(consultaExistente);
                    _healthContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Atualizar Paciente!", ex); 
            }
        }

        public Consulta BuscarPorId(Guid Id)
        {
            try
            {
                return _healthContext.Consulta.FirstOrDefault(c => c.IdConsulta == Id);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Buscar Consulta por Id!", ex); 
            }
        }

        public void Cadastrar(Consulta consulta)
        {
            try
            {
                _healthContext.Add(consulta);
                _healthContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Cadastrar Consulta!", ex); 
            }
        }

        public void Deletar(Guid Id)
        {
            try
            {
                var consulta = _healthContext.Consulta.Find(Id);
                if (consulta != null)
                {
                    _healthContext.Consulta.Remove(consulta);
                    _healthContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Deletar Consulta", ex); 
            }
        }

        public List<Consulta> Listar()
        {
            try
            {
                return _healthContext.Consulta.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Listar as Consultas.", ex); 
            }
        }
    }
}
