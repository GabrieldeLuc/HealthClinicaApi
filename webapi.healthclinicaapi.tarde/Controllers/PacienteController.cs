using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using webapi.healthclinica.tarde.Domains;
using webapi.healthclinicaapi.tarde.Interfaces;
using webapi.healthclinicaapi.tarde.Repositories;

namespace webapi.healthclinicaapi.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        [HttpGet]
        public IActionResult ListarPacientes()
        {
            try
            {
                List<Paciente> pacientes = _pacienteRepository.Listar();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Listar Pacientes {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public IActionResult BuscarPacientePorId(Guid id)
        {
            try
            {
                Paciente paciente = _pacienteRepository.BuscarPorId(id);
                if (paciente == null)
                {
                    return NotFound("Paciente não encontrado.");
                }
                return Ok(paciente);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Buscar Paciente {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CadastrarPaciente([FromBody] Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);
                return CreatedAtAction("ListarMedicos", new { id = paciente.IdPaciente }, paciente);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Cadastrar Paciente {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPaciente(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Deletar Paciente {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPaciente(Guid id, [FromBody] Paciente paciente)
        {
            try
            {
                _pacienteRepository.Atualizar(id, paciente);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Atualizar o Paciente {ex.Message}");
            }
        }
    }
}   
