namespace MappingInterfaceToViewModel.ViewModel
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }
        public bool IsVisible { get; set; }
    }

    public class Container
    {
        public Category Category { get; set; }
    }
}
