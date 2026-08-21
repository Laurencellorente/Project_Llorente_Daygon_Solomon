using IT_ELECTIVE_PREFINALS_PROJECT.Models;

namespace IT_ELECTIVE_PREFINALS_PROJECT.ViewModels
{
    public class CategoryManagementViewModel
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public Category NewCategory { get; set; } = new Category { Name = string.Empty };
    }
}