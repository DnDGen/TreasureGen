using DnDGen.EventGen;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;
using System;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalArmorGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.Armor)]
        public MagicalItemGenerator ArmorGenerator { get; set; }
        [Inject]
        public ClientIDManager ClientIDManager { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
            ClientIDManager.SetClientID(Guid.NewGuid());
        }

        [TestCase(ArmorConstants.AbsorbingShield, PowerConstants.Major)]
        [TestCase(ArmorConstants.ArmorOfArrowAttraction, PowerConstants.Minor)]
        [TestCase(ArmorConstants.ArmorOfArrowAttraction, PowerConstants.Medium)]
        [TestCase(ArmorConstants.ArmorOfArrowAttraction, PowerConstants.Major)]
        [TestCase(ArmorConstants.ArmorOfRage, PowerConstants.Minor)]
        [TestCase(ArmorConstants.ArmorOfRage, PowerConstants.Medium)]
        [TestCase(ArmorConstants.ArmorOfRage, PowerConstants.Major)]
        [TestCase(ArmorConstants.BandedMail, PowerConstants.Minor)]
        [TestCase(ArmorConstants.BandedMail, PowerConstants.Medium)]
        [TestCase(ArmorConstants.BandedMail, PowerConstants.Major)]
        [TestCase(ArmorConstants.BandedMailOfLuck, PowerConstants.Medium)]
        [TestCase(ArmorConstants.BandedMailOfLuck, PowerConstants.Major)]
        [TestCase(ArmorConstants.Breastplate, PowerConstants.Minor)]
        [TestCase(ArmorConstants.Breastplate, PowerConstants.Medium)]
        [TestCase(ArmorConstants.Breastplate, PowerConstants.Major)]
        [TestCase(ArmorConstants.BreastplateOfCommand, PowerConstants.Major)]
        [TestCase(ArmorConstants.Buckler, PowerConstants.Minor)]
        [TestCase(ArmorConstants.Buckler, PowerConstants.Medium)]
        [TestCase(ArmorConstants.Buckler, PowerConstants.Major)]
        [TestCase(ArmorConstants.CastersShield, PowerConstants.Minor)]
        [TestCase(ArmorConstants.CastersShield, PowerConstants.Medium)]
        [TestCase(ArmorConstants.CastersShield, PowerConstants.Major)]
        [TestCase(ArmorConstants.CelestialArmor, PowerConstants.Major)]
        [TestCase(ArmorConstants.Chainmail, PowerConstants.Minor)]
        [TestCase(ArmorConstants.Chainmail, PowerConstants.Medium)]
        [TestCase(ArmorConstants.Chainmail, PowerConstants.Major)]
        [TestCase(ArmorConstants.ChainShirt, PowerConstants.Minor)]
        [TestCase(ArmorConstants.ChainShirt, PowerConstants.Medium)]
        [TestCase(ArmorConstants.ChainShirt, PowerConstants.Major)]
        [TestCase(ArmorConstants.DemonArmor, PowerConstants.Major)]
        [TestCase(ArmorConstants.DwarvenPlate, PowerConstants.Medium)]
        [TestCase(ArmorConstants.DwarvenPlate, PowerConstants.Major)]
        [TestCase(ArmorConstants.ElvenChain, PowerConstants.Minor)]
        [TestCase(ArmorConstants.ElvenChain, PowerConstants.Medium)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Minor)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Medium)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Major)]
        [TestCase(ArmorConstants.FullPlateOfSpeed, PowerConstants.Major)]
        [TestCase(ArmorConstants.HalfPlate, PowerConstants.Minor)]
        [TestCase(ArmorConstants.HalfPlate, PowerConstants.Medium)]
        [TestCase(ArmorConstants.HalfPlate, PowerConstants.Major)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Minor)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Medium)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Major)]
        [TestCase(ArmorConstants.HeavyWoodenShield, PowerConstants.Minor)]
        [TestCase(ArmorConstants.HeavyWoodenShield, PowerConstants.Medium)]
        [TestCase(ArmorConstants.HeavyWoodenShield, PowerConstants.Major)]
        [TestCase(ArmorConstants.HideArmor, PowerConstants.Minor)]
        [TestCase(ArmorConstants.HideArmor, PowerConstants.Medium)]
        [TestCase(ArmorConstants.HideArmor, PowerConstants.Major)]
        [TestCase(ArmorConstants.LeatherArmor, PowerConstants.Minor)]
        [TestCase(ArmorConstants.LeatherArmor, PowerConstants.Medium)]
        [TestCase(ArmorConstants.LeatherArmor, PowerConstants.Major)]
        [TestCase(ArmorConstants.LightSteelShield, PowerConstants.Minor)]
        [TestCase(ArmorConstants.LightSteelShield, PowerConstants.Medium)]
        [TestCase(ArmorConstants.LightSteelShield, PowerConstants.Major)]
        [TestCase(ArmorConstants.LightWoodenShield, PowerConstants.Minor)]
        [TestCase(ArmorConstants.LightWoodenShield, PowerConstants.Medium)]
        [TestCase(ArmorConstants.LightWoodenShield, PowerConstants.Major)]
        [TestCase(ArmorConstants.LionsShield, PowerConstants.Medium)]
        [TestCase(ArmorConstants.LionsShield, PowerConstants.Major)]
        [TestCase(ArmorConstants.PaddedArmor, PowerConstants.Minor)]
        [TestCase(ArmorConstants.PaddedArmor, PowerConstants.Medium)]
        [TestCase(ArmorConstants.PaddedArmor, PowerConstants.Major)]
        [TestCase(ArmorConstants.PlateArmorOfTheDeep, PowerConstants.Major)]
        [TestCase(ArmorConstants.RhinoHide, PowerConstants.Medium)]
        [TestCase(ArmorConstants.ScaleMail, PowerConstants.Minor)]
        [TestCase(ArmorConstants.ScaleMail, PowerConstants.Medium)]
        [TestCase(ArmorConstants.ScaleMail, PowerConstants.Major)]
        [TestCase(ArmorConstants.SpinedShield, PowerConstants.Medium)]
        [TestCase(ArmorConstants.SpinedShield, PowerConstants.Major)]
        [TestCase(ArmorConstants.SplintMail, PowerConstants.Minor)]
        [TestCase(ArmorConstants.SplintMail, PowerConstants.Medium)]
        [TestCase(ArmorConstants.SplintMail, PowerConstants.Major)]
        [TestCase(ArmorConstants.StuddedLeatherArmor, PowerConstants.Minor)]
        [TestCase(ArmorConstants.StuddedLeatherArmor, PowerConstants.Medium)]
        [TestCase(ArmorConstants.StuddedLeatherArmor, PowerConstants.Major)]
        [TestCase(ArmorConstants.TowerShield, PowerConstants.Minor)]
        [TestCase(ArmorConstants.TowerShield, PowerConstants.Medium)]
        [TestCase(ArmorConstants.TowerShield, PowerConstants.Major)]
        [TestCase(ArmorConstants.WingedShield, PowerConstants.Medium)]
        [TestCase(ArmorConstants.WingedShield, PowerConstants.Major)]
        public void GenerateArmor(string itemName, string power)
        {
            var isOfPower = ArmorGenerator.IsItemOfPower(itemName, power);
            Assert.That(isOfPower, Is.True);

            var item = ArmorGenerator.GenerateFrom(power, itemName);
            itemVerifier.AssertItem(item);
        }
    }
}
