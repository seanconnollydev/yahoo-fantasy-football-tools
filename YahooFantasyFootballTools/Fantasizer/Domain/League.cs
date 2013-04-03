namespace Fantasizer.Domain
{
    public class League
    {
        public League(int id, string name, string key)
        {
            this.Id = id;
            this.Name = name;
            this.Key = key;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Key { get; private set; }
    }
}