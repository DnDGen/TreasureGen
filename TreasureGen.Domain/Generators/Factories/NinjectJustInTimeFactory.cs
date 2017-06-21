using Ninject;

namespace TreasureGen.Domain.Generators.Factories
{
    internal class NinjectJustInTimeFactory : JustInTimeFactory
    {
        private readonly IKernel kernel;

        public NinjectJustInTimeFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public T Build<T>()
        {
            return kernel.Get<T>();
        }

        public T Build<T>(string name)
        {
            return kernel.Get<T>(name);
        }
    }
}
