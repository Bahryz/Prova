using api_avaliacao.Data.Interfaces;
using api_avaliacao.Models;
using System.Collections.Generic;
using System.Linq;

namespace api_avaliacao.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDataContext _context;

        public ItemRepository(AppDataContext context)
        {
            _context = context;
        }

        public void Cadastrar(Item item)
        {
            _context.Itens.Add(item);
            _context.SaveChanges();
        }

        public List<Item> Listar()
        {
            return _context.Itens.ToList();
        }

        public Item? BuscarPorId(int id)
        {
            return _context.Itens.FirstOrDefault(i => i.ItemId == id);
        }
    }
}
