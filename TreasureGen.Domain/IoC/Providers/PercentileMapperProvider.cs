using Ninject;
using Ninject.Activation;
using TreasureGen.Domain.Mappers.Percentile;

namespace TreasureGen.Domain.IoC.Providers
{
    class PercentileMapperProvider : Provider<IPercentileMapper>
    {
        protected override IPercentileMapper CreateInstance(IContext context)
        {
            IPercentileMapper mapper = context.Kernel.Get<PercentileXmlMapper>();
            mapper = new PercentileMapperCachingProxy(mapper);

            return mapper;
        }
    }
}