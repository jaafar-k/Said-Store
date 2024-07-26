namespace Said_Store.Domain
{
    public class Product
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }

        public Product(string? name)
        {
            Name = name;
        }
        public void Update(string? name)
        {
            Name = name;
        }
    }
}
