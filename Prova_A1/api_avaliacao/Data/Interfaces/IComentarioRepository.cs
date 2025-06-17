using api_avaliacao.Models;

namespace api_avaliacao.Data.Interfaces;

public interface IComentarioRepository
{
    void Criar(Comentario comentario);
    List<Comentario> Listar();
    void Deletar(int id); 
}