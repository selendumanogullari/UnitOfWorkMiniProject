

namespace UnitOfWorkMiniProject.Core.Models
{
    public class DailyTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
