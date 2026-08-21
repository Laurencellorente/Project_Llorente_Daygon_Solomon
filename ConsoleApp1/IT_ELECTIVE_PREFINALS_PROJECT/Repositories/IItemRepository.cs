using IT_ELECTIVE_PREFINALS_PROJECT.Models;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        
        IEnumerable<Item> SearchByName(string name);
    }
}