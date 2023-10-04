using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinica.tarde.Domains;
using webapi.healthclinicaapi.tarde.Interfaces;

namespace webapi.healthclinicaapi.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {
        private readonly IClinicaRepository _clinicaRepository; 

        public ClinicaController(IClinicaRepository clinicaRepository)
        {
            _clinicaRepository = clinicaRepository;
        }

        [HttpGet]
        public IActionResult ListarClinicas()
        {
            try
            {
                List<ClinicaDomain> clinicas = _clinicaRepository.Listar();
                return Ok(clinicas); 
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Listar Clinicas {ex.Message}"); 
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarClinicaPorId(Guid id)
        {
            try
            {
                ClinicaDomain clinica = _clinicaRepository.BuscarPorId(id);
                if (clinica == null)
                {
                    return NotFound("Clinica não encontrada."); 
                }
                return Ok(clinica); 
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Buscar Clínica {ex.Message}"); 
            }
        }

        [HttpPost]
        public IActionResult CadastrarClinica([FromBody] ClinicaDomain clinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);
                return CreatedAtAction("BuscarClinicaPorId", new { id = clinica.IdClinica }, clinica); 
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Cadastrar a Clinica {ex.Message}"); 
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarClinica(Guid id, [FromBody] ClinicaDomain clinica)
        {
            try
            {
                _clinicaRepository.Atualizar(id, clinica);
                return NoContent(); 
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Atualizar a CLinica {ex.Message}"); 
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarClinica(Guid id)
        {
            try
            {
                _clinicaRepository.Deletar(id);
                return NoContent(); 
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Deletar Clinica {ex.Message}"); 
            }
        }
    }
}
