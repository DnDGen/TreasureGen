using System.Linq;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Mundane;

namespace TreasureGen.Generators.Domain.Decorators
{
    public class MundaneItemGeneratorSpecialMaterialDecorator : MundaneItemGenerator
    {
        private MundaneItemGenerator innerGenerator;
        private ISpecialMaterialGenerator specialMaterialGenerator;

        public MundaneItemGeneratorSpecialMaterialDecorator(MundaneItemGenerator innerGenerator, ISpecialMaterialGenerator specialMaterialGenerator)
        {
            this.innerGenerator = innerGenerator;
            this.specialMaterialGenerator = specialMaterialGenerator;
        }

        public Item Generate()
        {
            var item = innerGenerator.Generate();

            while (specialMaterialGenerator.CanHaveSpecialMaterial(item.ItemType, item.Attributes, item.Traits))
            {
                var material = specialMaterialGenerator.GenerateFor(item.ItemType, item.Attributes, item.Traits);
                item.Traits.Add(material);

                if (material == TraitConstants.Dragonhide)
                {
                    var metalAndWood = new[] { AttributeConstants.Metal, AttributeConstants.Wood };
                    item.Attributes = item.Attributes.Except(metalAndWood);
                }
            }

            return item;
        }
    }
}