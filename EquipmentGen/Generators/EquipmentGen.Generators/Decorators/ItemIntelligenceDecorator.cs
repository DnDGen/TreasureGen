using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Generators.Decorators
{
    public class ItemIntelligenceDecorator : IMagicalItemGenerator
    {
        private IMagicalItemGenerator innerGenerator;
        private IIntelligenceGenerator intelligenceGenerator;

        public Item GenerateAtPower(String power)
        {
            throw new NotImplementedException();
        }
    }
}