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
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }

        [HttpGet]
        public IActionResult ListarEspecialidades()
        {
            try
            {
                List<Especialidade> especialidades = _especialidadeRepository.Listar();
                return Ok(especialidades);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Listar especialidades {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEspecialidade(Guid id)
        {
            try
            {
                _especialidadeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Deletar Especialidade {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CadastrarEspecialidade([FromBody] Especialidade especialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(especialidade);
                return CreatedAtAction("ListarEspecialidades", new { id = especialidade.IdEspecialidade } ,especialidade);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao Cadastrar a Especialidade {ex.Message}");
            }
        }
    }
}
