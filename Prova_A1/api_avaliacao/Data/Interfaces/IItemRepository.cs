using api_avaliacao.Models;
using System.Collections.Generic;

namespace api_avaliacao.Data.Interfaces
{
    public interface IItemRepository
    {
        void Cadastrar(Item item);
        List<Item> Listar();
        Item? BuscarPorId(int id);
    }
}
