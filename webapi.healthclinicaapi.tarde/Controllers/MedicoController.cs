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
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpGet]
        public IActionResult ListarMedicos()
        {
            try
            {
                List<Medico> medicos = _medicoRepository.Listar();
                return Ok(medicos);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Listar Médicos {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarMedicoPorId(Guid id)
        {
            try
            {
                Medico medico = _medicoRepository.BuscarPorId(id);
                if (medico == null)
                {
                    return NotFound("Médico não encontrado.");
                }
                return Ok(medico);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Buscar Médico {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CadastrarMedico([FromBody] Medico medico) 
        {
            try
            {
                _medicoRepository.Cadastrar(medico); 
                return CreatedAtAction("ListarMedicos", new {id = medico.IdMedico}, medico);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Cadastrar Médico {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarMedico(Guid id)
        {
            try
            {
                _medicoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Deletar Médico {ex.Message}");
            }
        }
    }
}
