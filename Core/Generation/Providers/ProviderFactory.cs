using D20Dice;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers;

namespace EquipmentGen.Core.Generation.Providers
{
    public static class ProviderFactory
    {
        public static IPercentileResultProvider CreatePercentileResultProviderWith(IDice dice)
        {
            var streamLoader = new EmbeddedResourceStreamLoader();
            var xmlParser = new PercentileXmlParser(streamLoader);
            return new PercentileResultProvider(xmlParser, dice);
        }

        public static ICoinProvider CreateCoinProviderWith(IDice dice)
        {
            var percentileResultProvider = CreatePercentileResultProviderWith(dice);
            return new CoinProvider(percentileResultProvider, dice);
        }
    }
}