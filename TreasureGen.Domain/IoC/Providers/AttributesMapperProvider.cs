using Ninject;
using Ninject.Activation;
using TreasureGen.Domain.Mappers.Attributes;

namespace TreasureGen.Domain.IoC.Providers
{
    class AttributesMapperProvider : Provider<IAttributesMapper>
    {
        protected override IAttributesMapper CreateInstance(IContext context)
        {
            IAttributesMapper mapper = context.Kernel.Get<AttributesXmlMapper>();
            mapper = new AttributesMapperCachingProxy(mapper);

            return mapper;
        }
    }
}