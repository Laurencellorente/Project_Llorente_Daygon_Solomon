using IT_ELECTIVE_PREFINALS_PROJECT.Data;
using IT_ELECTIVE_PREFINALS_PROJECT.Models;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Item> SearchByName(string name)
        {
            return _context.Items
                .Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}