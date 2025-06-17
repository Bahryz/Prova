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
    private readonly IItemRepository _itemRepository;


    public ComentarioController(IComentarioRepository comentarioRepository, IItemRepository itemRepository)
    {
        _comentarioRepository = comentarioRepository;
        _itemRepository = itemRepository;
    }

    [HttpGet("listar")]
    public IActionResult Listar()
    {
        return Ok(_comentarioRepository.Listar());
    }

    [HttpPost("criar")]
    public IActionResult Criar([FromBody] Comentario comentario)
    {
        if (string.IsNullOrWhiteSpace(comentario.Texto) || comentario.ItemId <= 0)
            return BadRequest(new { message = "Dados inválidos para o comentário." });

    
        var itemExiste = _itemRepository.BuscarPorId(comentario.ItemId);
        if (itemExiste == null)
            return NotFound(new { message = "ItemId não encontrado na base de dados." });

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
