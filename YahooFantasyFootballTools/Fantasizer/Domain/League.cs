namespace Fantasizer.Domain
{
    public class League
    {
        public League(int id, string name, string key, int startWeek, int endWeek)
        {
            this.Id = id;
            this.Name = name;
            this.Key = key;
            this.StartWeek = startWeek;
            this.EndWeek = endWeek;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Key { get; private set; }
        public int StartWeek { get; private set; }
        public int EndWeek { get; private set; }
    }
}