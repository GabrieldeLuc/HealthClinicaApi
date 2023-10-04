using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinica.tarde.Domains;
using webapi.healthclinicaapi.tarde.Interfaces;
using webapi.healthclinicaapi.tarde.Repositories;

namespace webapi.healthclinicaapi.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaController(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        [HttpGet]
        public IActionResult ListarConsultas()
        {
            try
            {
                List<Consulta> consultas = _consultaRepository.Listar();
                return Ok(consultas);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Listar Consultas {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarConsultaPorId(Guid id)
        {
            try
            {
                Consulta consulta = _consultaRepository.BuscarPorId(id);
                if (consulta == null)
                {
                    return NotFound("Consulta não encontrada.");
                }
                return Ok(consulta);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Buscar Consulta {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CadastrarConsulta([FromBody] Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);
                return CreatedAtAction("BuscarClinicaPorId", new { id = consulta.IdConsulta }, consulta);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Cadastrar a Consulta {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarConsulta(Guid id, [FromBody] Consulta consulta)
        {
            try
            {
                _consultaRepository.Atualizar(id, consulta);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Atualizar a Consulta {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarClinica(Guid id)
        {
            try
            {
                _consultaRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Deletar Consulta {ex.Message}");
            }
        }

    }
}
