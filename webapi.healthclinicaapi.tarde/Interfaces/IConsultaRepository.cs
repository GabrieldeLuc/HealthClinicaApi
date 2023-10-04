using webapi.healthclinica.tarde.Domains;

namespace webapi.healthclinicaapi.tarde.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);

        void Deletar(Guid Id);

        List<Consulta> Listar(); 

        Consulta BuscarPorId(Guid Id);  

        void Atualizar (Guid Id, Consulta consulta);    

    }
}
