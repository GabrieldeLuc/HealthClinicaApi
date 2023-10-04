using webapi.healthclinica.tarde.Domains;

namespace webapi.healthclinicaapi.tarde.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);

        void Deletar(Guid id); 
        
        List<Paciente> Listar();

        Paciente BuscarPorId(Guid id);

        void Atualizar(Guid Id, Paciente paciente);
    }
}
