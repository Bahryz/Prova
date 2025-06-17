using api_avaliacao.Data.Interfaces;
using api_avaliacao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_avaliacao.Controllers;

[ApiController]
[Authorize]
[Route("api/comentario")]
public class ComentarioController : ControllerBase
{
    private readonly IComentarioRepository _comentarioRepository;
    public ComentarioController(IComentarioRepository comentarioRepository)
    {
        _comentarioRepository = comentarioRepository;
    }

    [HttpGet("listar")]
    public IActionResult Listar()
    {
        return Ok(_comentarioRepository.Listar());
    }

    [HttpPost("criar")]
    public IActionResult Criar([FromBody] Comentario comentario)
    {
        _comentarioRepository.Criar(comentario);
        return Created("", comentario);
    }

    [HttpDelete("{ComentarioId}")]
        public IActionResult Deletar([FromRoute] int ComentarioId)
    {
        _comentarioRepository.Deletar(ComentarioId);
        return Ok(new { message = "Produto deletado com sucesso!" });
    }

}

