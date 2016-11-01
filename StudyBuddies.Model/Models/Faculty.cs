namespace StudyBuddies.Domain.Models
{
    public class Faculty : Institution
    {
        public virtual Location Location { get; set; }
        public virtual University University { get; set; }
    }
}
