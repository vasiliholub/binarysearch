using System.Linq;
using AutoFixture;

namespace BinarySearch
{
    public static class ArrayContainerFactory 
    {
        private static readonly AutoFixture.Fixture Fixture;

        static ArrayContainerFactory()
        {
            Fixture = new AutoFixture.Fixture();

            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => Fixture.Behaviors.Remove(b));
        }

        public static int[] CreateArray()
        {
            var fixture = Fixture
                .Build<ArrayContainer>()
                .Without(x => x.Container)
                .Create();

            fixture.Container = Fixture.Create<int[]>();

            return fixture.Container;
        }
    }
}