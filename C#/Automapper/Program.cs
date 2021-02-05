using AutoMapper;
using Xunit;

namespace MappingInterfaceToViewModel
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string name = "Foobar";

            var container = new Contract.Container()
            {
                Category = new Contract.Category()
                {
                    Id = 8,
                    Name = name
                }
            };

            Mapper.Initialize(x => x.AddProfile<Mappings>());
            var mapped = Mapper.Map<ViewModel.Container>(container);

            Assert.Equal(mapped.Category.Name, name);
            Assert.True(mapped.Category.IsVisible);
        }
    }
}