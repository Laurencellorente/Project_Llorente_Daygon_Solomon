using IT_ELECTIVE_PREFINALS_PROJECT.Models;

namespace IT_ELECTIVE_PREFINALS_PROJECT.ViewModels
{
    public class TeamManagementViewModel
    {
        public IEnumerable<Team> Teams { get; set; } = new List<Team>();
        public Team NewTeam { get; set; } = new Team { Name = string.Empty };
    }
}