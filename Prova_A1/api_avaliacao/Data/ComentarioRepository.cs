using api_avaliacao.Data.Interfaces;
using api_avaliacao.Models;

namespace api_avaliacao.Data;

public class ComentarioRepository : IComentarioRepository
{
    private readonly AppDataContext _context;
    public ComentarioRepository(AppDataContext context)
    {
        _context = context;
    }

    public void Criar(Comentario comentario)
    {
        _context.Comentarios.Add(comentario);
        _context.SaveChanges();
    }

    public List<Comentario> Listar()
    {
        return _context.Comentarios.ToList();
    }
    public void Deletar(int ComentarioId)
    {
        var comentario = _context.Comentarios.Find(ComentarioId);
        if (comentario != null)
        {
            _context.Comentarios.Remove(comentario);
            _context.SaveChanges();
        }
    }
}