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
    public class TipoDeUsuarioController : ControllerBase
    {
        private ITipoDeUsuarioRepository _tipoDeUsuarioRepository { get; set; }

        public TipoDeUsuarioController()
        {
            _tipoDeUsuarioRepository = new TipoDeUsuarioRepository();
        }

        [HttpPost]

        public IActionResult Post(TipoDeUsuario tipoUsuario)
        {
            try
            {
                _tipoDeUsuarioRepository.Cadastrar(tipoUsuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                TipoDeUsuario tipoDeUsuario = _tipoDeUsuarioRepository.BuscarPorId(); 
                if (tipoDeUsuario != null)
                {
                    return Ok(tipoDeUsuario);
                }

                return NotFound("Tipo do Usuario não encontrado.");
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao buscar tipo do Usuario por Id {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TipoDeUsuario tipoDeUsuario)
        {
            try
            {
                _tipoDeUsuarioRepository.Atualizar(id, tipoDeUsuario);
                return Ok("Tipo do Usuario Atualizado com sucesso.");
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao atualizar tipo do Usuario.{e.Message}");
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoDeUsuarioRepository.Deletar(id);
                return Ok("Tipo do Usuario deletado.");
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao deletar tipo do Usuario.{e.Message}");
            }

        }

    }
}
