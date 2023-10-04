using webapi.healthclinica.tarde.Context;
using webapi.healthclinica.tarde.Domains;
using webapi.healthclinicaapi.tarde.Interfaces;

namespace webapi.healthclinicaapi.tarde.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext _healthContext;

        public ClinicaRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid Id, ClinicaDomain clinica)
        {
            try
            {
                var clinicaExistente = _healthContext.Clinica.Find(Id);
                if (clinicaExistente != null)
                {
                    clinicaExistente.NomeClinica = clinicaExistente.NomeClinica;
                    clinicaExistente.NomeFantasia = clinicaExistente.NomeFantasia;
                    clinicaExistente.EnderecoClinica = clinicaExistente.EnderecoClinica; 
                    clinicaExistente.CNPJ = clinicaExistente.CNPJ;
                    clinicaExistente.RazaoSocial = clinicaExistente.RazaoSocial;
                    clinicaExistente.HorarioAbertura = clinicaExistente.HorarioAbertura;
                    clinicaExistente.HorarioFechamento = clinicaExistente.HorarioFechamento;

                    _healthContext.Update(clinicaExistente);
                    _healthContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Atualizar Clinica", ex); 
            }
        }

        public ClinicaDomain BuscarPorId(Guid Id)
        {
            try
            {
                return _healthContext.Clinica.FirstOrDefault(i => i.IdClinica == Id);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Buscar Clinica por Id", ex); 
            }
        }

        public void Cadastrar(ClinicaDomain clinica)
        {
            try
            {
                _healthContext.Add(clinica);
                _healthContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Cadastrar Clinica", ex); 
            }
        }

        public void Deletar(Guid Id)
        {
            try
            {
                var clinica = _healthContext.Consulta.Find(Id);
                if (clinica != null)
                {
                    _healthContext.Consulta.Remove(clinica);
                    _healthContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Deletar Consulta!", ex); 
            }
        }

        public List<ClinicaDomain> Listar()
        {
            try
            {
                return _healthContext.Clinica.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Listar Clinica", ex); 
            }
        }
    }
}
