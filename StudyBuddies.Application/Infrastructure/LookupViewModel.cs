namespace StudyBuddies.Application.Infrastructure
{
    public class LookupViewModel<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
