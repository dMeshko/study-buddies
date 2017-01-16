namespace StudyBuddies.Domain.Institutions
{
    public class Academy : Institution
    {
        protected Academy() : base(string.Empty) { }

        public Academy(string name) : base(name) { }
    }
}
