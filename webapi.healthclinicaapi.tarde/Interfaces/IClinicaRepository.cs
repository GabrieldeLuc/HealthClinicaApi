using webapi.healthclinica.tarde.Domains;

namespace webapi.healthclinicaapi.tarde.Interfaces
{
    public interface IClinicaRepository
    {
    void Cadastrar(ClinicaDomain clinica);
        void Deletar(Guid Id);
        List<ClinicaDomain> Listar();
        ClinicaDomain BuscarPorId(Guid Id);
        void Atualizar(Guid Id, ClinicaDomain clinica);
    }
}
