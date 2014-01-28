using D20Dice;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class AmmunitionGenerator : IAmmunitionGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IDice dice;
        private IGearTypesProvider gearTypesProvider;

        public AmmunitionGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider, IDice dice,
            IGearTypesProvider gearTypesProvider)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.dice = dice;
            this.gearTypesProvider = gearTypesProvider;
        }

        public Ammunition Generate()
        {
            var result = typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult("Ammunition");

            var ammunition = new Ammunition();
            ammunition.Name = result.Type;
            ammunition.Quantity = result.Amount;
            ammunition.Types = gearTypesProvider.GetGearTypesFor(ammunition.Name);

            return ammunition;
        }
    }
}