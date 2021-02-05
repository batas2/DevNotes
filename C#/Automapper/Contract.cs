namespace MappingInterfaceToViewModel.Contract
{
    public class Container
    {
        public ICategory Category { get; set; }
    }

    public class Category : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface ICategory
    {
    }

    public class NoCategory : ICategory
    {
    }
}
