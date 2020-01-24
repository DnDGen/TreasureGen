using DnDGen.TreasureGen.Items;

namespace DnDGen.TreasureGen.Generators.Items
{
    internal interface ISpecificGearGenerator
    {
        Item GeneratePrototypeFrom(string power, string specificGearType, string name);
        string GenerateRandomNameFrom(string power, string specificGearType);
        string GenerateNameFrom(string power, string specificGearType, string baseType);
        Item GenerateFrom(Item template);
        bool IsSpecific(Item template);
        bool IsSpecific(string specificGearType, string itemName);
        bool CanBeSpecific(string power, string specificGearType, string itemName);
    }
}