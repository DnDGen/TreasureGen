using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class SpecialAbilityConstantsTests
    {
        [TestCase(SpecialAbilityConstants.Glamered, "Glamered")]
        [TestCase(SpecialAbilityConstants.LightFortification, "Light fortification")]
        [TestCase(SpecialAbilityConstants.Slick, "Slick")]
        [TestCase(SpecialAbilityConstants.Shadow, "Shadow")]
        [TestCase(SpecialAbilityConstants.SilentMoves, "Silent moves")]
        [TestCase(SpecialAbilityConstants.SpellResistance13, "Spell resistance (13)")]
        [TestCase(SpecialAbilityConstants.ImprovedSlick, "Improved slick")]
        [TestCase(SpecialAbilityConstants.ImprovedShadow, "Improved shadow")]
        [TestCase(SpecialAbilityConstants.ImprovedSilentMoves, "Improved silent moves")]
        [TestCase(SpecialAbilityConstants.AcidResistance, "Acid resistance")]
        [TestCase(SpecialAbilityConstants.ColdResistance, "Cold resistance")]
        [TestCase(SpecialAbilityConstants.ElectricityResistance, "Electricity resistance")]
        [TestCase(SpecialAbilityConstants.FireResistance, "Fire resistance")]
        [TestCase(SpecialAbilityConstants.SonicResistance, "Sonic resistance")]
        [TestCase(SpecialAbilityConstants.GhostTouch, "Ghost touch")]
        [TestCase(SpecialAbilityConstants.Invulnerability, "Invulnerability")]
        [TestCase(SpecialAbilityConstants.ModerateFortification, "Moderate fortification")]
        [TestCase(SpecialAbilityConstants.Fortification, "Fortification")]
        [TestCase(SpecialAbilityConstants.SpellResistance, "Spell resistance")]
        [TestCase(SpecialAbilityConstants.SpellResistance15, "Spell resistance (15)")]
        [TestCase(SpecialAbilityConstants.Wild, "Wild")]
        [TestCase(SpecialAbilityConstants.GreaterSlick, "Greater slick")]
        [TestCase(SpecialAbilityConstants.GreaterShadow, "Greater shadow")]
        [TestCase(SpecialAbilityConstants.GreaterSilentMoves, "Greater silent moves")]
        [TestCase(SpecialAbilityConstants.ImprovedAcidResistance, "Improved acid resistance")]
        [TestCase(SpecialAbilityConstants.ImprovedColdResistance, "Improved cold resistance")]
        [TestCase(SpecialAbilityConstants.ImprovedElectricityResistance, "Improved electricity resistance")]
        [TestCase(SpecialAbilityConstants.ImprovedFireResistance, "Improved fire resistance")]
        [TestCase(SpecialAbilityConstants.ImprovedSonicResistance, "Improved sonic resistance")]
        [TestCase(SpecialAbilityConstants.SpellResistance17, "Spell resistance (17)")]
        [TestCase(SpecialAbilityConstants.Etherealness, "Etherealness")]
        [TestCase(SpecialAbilityConstants.UndeadControlling, "Undead controlling")]
        [TestCase(SpecialAbilityConstants.HeavyFortification, "Heavy fortification")]
        [TestCase(SpecialAbilityConstants.SpellResistance19, "Spell resistance (19)")]
        [TestCase(SpecialAbilityConstants.GreaterAcidResistance, "Greater acid resistance")]
        [TestCase(SpecialAbilityConstants.GreaterColdResistance, "Greater cold resistance")]
        [TestCase(SpecialAbilityConstants.GreaterElectricityResistance, "Greater electricity resistance")]
        [TestCase(SpecialAbilityConstants.GreaterFireResistance, "Greater fire resistance")]
        [TestCase(SpecialAbilityConstants.GreaterSonicResistance, "Greater sonic resistance")]
        [TestCase(SpecialAbilityConstants.ArrowCatching, "Arrow catching")]
        [TestCase(SpecialAbilityConstants.Bashing, "Bashing")]
        [TestCase(SpecialAbilityConstants.Blinding, "Blinding")]
        [TestCase(SpecialAbilityConstants.ArrowDeflection, "Arrow deflection")]
        [TestCase(SpecialAbilityConstants.Animated, "Animated")]
        [TestCase(SpecialAbilityConstants.Reflecting, "Reflecting")]
        [TestCase(SpecialAbilityConstants.Bane, "Bane")]
        [TestCase(SpecialAbilityConstants.DESIGNATEDFOEbane, "DESIGNATEDFOEbane")]
        [TestCase(SpecialAbilityConstants.Aberrationbane, "Aberrationbane")]
        [TestCase(SpecialAbilityConstants.Animalbane, "Animalbane")]
        [TestCase(SpecialAbilityConstants.Constructbane, "Constructbane")]
        [TestCase(SpecialAbilityConstants.Dragonbane, "Dragonbane")]
        [TestCase(SpecialAbilityConstants.Elementalbane, "Elementalbane")]
        [TestCase(SpecialAbilityConstants.Feybane, "Feybane")]
        [TestCase(SpecialAbilityConstants.Giantbane, "Giantbane")]
        [TestCase(SpecialAbilityConstants.AquaticHumanoidbane, "Aquatic-humanoidbane")]
        [TestCase(SpecialAbilityConstants.Dwarfbane, "Dwarfbane")]
        [TestCase(SpecialAbilityConstants.Elfbane, "Elfbane")]
        [TestCase(SpecialAbilityConstants.Gnollbane, "Gnollbane")]
        [TestCase(SpecialAbilityConstants.Gnomebane, "Gnomebane")]
        [TestCase(SpecialAbilityConstants.Goblinoidbane, "Goblinoidbane")]
        [TestCase(SpecialAbilityConstants.Halflingbane, "Halflingbane")]
        [TestCase(SpecialAbilityConstants.Humanbane, "Humanbane")]
        [TestCase(SpecialAbilityConstants.ReptilianHumanoidbane, "Reptilian-humanoidbane")]
        [TestCase(SpecialAbilityConstants.Orcbane, "Orcbane")]
        [TestCase(SpecialAbilityConstants.MagicalBeastbane, "Magical-beastbane")]
        [TestCase(SpecialAbilityConstants.MonstrousHumanoidbane, "Monstrous-humanoidbane")]
        [TestCase(SpecialAbilityConstants.Oozebane, "Oozebane")]
        [TestCase(SpecialAbilityConstants.AirOutsiderbane, "Air-outsiderbane")]
        [TestCase(SpecialAbilityConstants.ChaoticOutsiderbane, "Chaotic-outsiderbane")]
        [TestCase(SpecialAbilityConstants.EarthOutsiderbane, "Earth-outsiderbane")]
        [TestCase(SpecialAbilityConstants.FireOutsiderbane, "Fire-outsiderbane")]
        [TestCase(SpecialAbilityConstants.LawfulOutsiderbane, "Lawful-outsiderbane")]
        [TestCase(SpecialAbilityConstants.GoodOutsiderbane, "Good-outsiderbane")]
        [TestCase(SpecialAbilityConstants.EvilOutsiderbane, "Evil-outsiderbane")]
        [TestCase(SpecialAbilityConstants.WaterOutsiderbane, "Water-outsiderbane")]
        [TestCase(SpecialAbilityConstants.Plantbane, "Plantbane")]
        [TestCase(SpecialAbilityConstants.Undeadbane, "Undeadbane")]
        [TestCase(SpecialAbilityConstants.Verminbane, "Verminbane")]
        [TestCase(SpecialAbilityConstants.Distance, "Distance")]
        [TestCase(SpecialAbilityConstants.Flaming, "Flaming")]
        [TestCase(SpecialAbilityConstants.Frost, "Frost")]
        [TestCase(SpecialAbilityConstants.Merciful, "Merciful")]
        [TestCase(SpecialAbilityConstants.Returning, "Returning")]
        [TestCase(SpecialAbilityConstants.Shock, "Shock")]
        [TestCase(SpecialAbilityConstants.Seeking, "Seeking")]
        [TestCase(SpecialAbilityConstants.Thundering, "Thundering")]
        [TestCase(SpecialAbilityConstants.Anarchic, "Anarchic")]
        [TestCase(SpecialAbilityConstants.Axiomatic, "Axiomatic")]
        [TestCase(SpecialAbilityConstants.Disruption, "Disruption")]
        [TestCase(SpecialAbilityConstants.FlamingBurst, "Flaming burst")]
        [TestCase(SpecialAbilityConstants.IcyBurst, "Icy burst")]
        [TestCase(SpecialAbilityConstants.Holy, "Holy")]
        [TestCase(SpecialAbilityConstants.ShockingBurst, "Shocking burst")]
        [TestCase(SpecialAbilityConstants.Unholy, "Unholy")]
        [TestCase(SpecialAbilityConstants.Wounding, "Wounding")]
        [TestCase(SpecialAbilityConstants.Speed, "Speed")]
        [TestCase(SpecialAbilityConstants.Dancing, "Dancing")]
        [TestCase(SpecialAbilityConstants.Vorpal, "Vorpal")]
        [TestCase(SpecialAbilityConstants.BrilliantEnergy, "Brilliant energy")]
        [TestCase(SpecialAbilityConstants.Defending, "Defending")]
        [TestCase(SpecialAbilityConstants.Keen, "Keen")]
        [TestCase(SpecialAbilityConstants.KiFocus, "Ki focus")]
        [TestCase(SpecialAbilityConstants.Throwing, "Throwing")]
        [TestCase(SpecialAbilityConstants.MightyCleaving, "Mighty cleaving")]
        [TestCase(SpecialAbilityConstants.SpellStoring, "Spell storing")]
        [TestCase(SpecialAbilityConstants.Vicious, "Vicious")]
        [TestCase(SpecialAbilityConstants.GhostTouchWeapon, "Ghost touch (weapon)")]
        [TestCase(SpecialAbilityConstants.GhostTouchArmor, "Ghost touch (armor)")]
        [TestCase(SpecialAbilityConstants.Shapeshifterbane, "Shapeshifterbane")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void GetAllAbilities_WithAlternateNames()
        {
            var abilities = SpecialAbilityConstants.GetAllAbilities(true);

            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Aberrationbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.AcidResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.AirOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Anarchic));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Animalbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Animated));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.AquaticHumanoidbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ArrowCatching));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ArrowDeflection));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Axiomatic));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Bashing));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Blinding));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.BrilliantEnergy));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ChaoticOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ColdResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Constructbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Dancing));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Defending));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Disruption));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Distance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Dragonbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Dwarfbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.EarthOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ElectricityResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Elementalbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Elfbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Etherealness));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.EvilOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Feybane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.FireOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.FireResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Flaming));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.FlamingBurst));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Frost));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GhostTouchArmor));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GhostTouchWeapon));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Giantbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Glamered));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Gnollbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Gnomebane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Goblinoidbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GoodOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterAcidResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterColdResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterElectricityResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterFireResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterShadow));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterSilentMoves));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterSlick));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterSonicResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Halflingbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.HeavyFortification));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Holy));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Humanbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.IcyBurst));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedAcidResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedColdResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedElectricityResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedFireResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedShadow));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedSilentMoves));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedSlick));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedSonicResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Invulnerability));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Keen));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.KiFocus));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.LawfulOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.LightFortification));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.MagicalBeastbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Merciful));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.MightyCleaving));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ModerateFortification));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.MonstrousHumanoidbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Oozebane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Orcbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Plantbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Reflecting));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ReptilianHumanoidbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Returning));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Seeking));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Shadow));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Shapeshifterbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Shock));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ShockingBurst));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SilentMoves));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Slick));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SonicResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Speed));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SpellResistance13));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SpellResistance15));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SpellResistance17));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SpellResistance19));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SpellStoring));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Throwing));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Thundering));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Undeadbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.UndeadControlling));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Unholy));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Verminbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Vicious));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Vorpal));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.WaterOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Wild));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Wounding));

            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Bane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GhostTouch));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.DESIGNATEDFOEbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SpellResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Fortification));
            Assert.That(abilities.Count(), Is.EqualTo(109));
        }

        [Test]
        public void GetAllAbilities_WithoutAlternateNames()
        {
            var abilities = SpecialAbilityConstants.GetAllAbilities(false);

            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Aberrationbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.AcidResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.AirOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Anarchic));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Animalbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Animated));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.AquaticHumanoidbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ArrowCatching));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ArrowDeflection));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Axiomatic));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Bashing));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Blinding));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.BrilliantEnergy));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ChaoticOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ColdResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Constructbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Dancing));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Defending));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Disruption));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Distance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Dragonbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Dwarfbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.EarthOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ElectricityResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Elementalbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Elfbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Etherealness));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.EvilOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Feybane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.FireOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.FireResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Flaming));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.FlamingBurst));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Frost));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GhostTouchArmor));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GhostTouchWeapon));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Giantbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Glamered));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Gnollbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Gnomebane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Goblinoidbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GoodOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterAcidResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterColdResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterElectricityResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterFireResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterShadow));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterSilentMoves));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterSlick));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.GreaterSonicResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Halflingbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.HeavyFortification));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Holy));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Humanbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.IcyBurst));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedAcidResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedColdResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedElectricityResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedFireResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedShadow));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedSilentMoves));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedSlick));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ImprovedSonicResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Invulnerability));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Keen));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.KiFocus));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.LawfulOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.LightFortification));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.MagicalBeastbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Merciful));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.MightyCleaving));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ModerateFortification));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.MonstrousHumanoidbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Oozebane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Orcbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Plantbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Reflecting));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ReptilianHumanoidbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Returning));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Seeking));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Shadow));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Shapeshifterbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Shock));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.ShockingBurst));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SilentMoves));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Slick));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SonicResistance));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Speed));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SpellResistance13));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SpellResistance15));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SpellResistance17));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SpellResistance19));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.SpellStoring));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Throwing));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Thundering));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Undeadbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.UndeadControlling));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Unholy));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Verminbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Vicious));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Vorpal));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.WaterOutsiderbane));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Wild));
            Assert.That(abilities, Contains.Item(SpecialAbilityConstants.Wounding));

            Assert.That(abilities, Does.Not.Contain(SpecialAbilityConstants.Bane));
            Assert.That(abilities, Does.Not.Contain(SpecialAbilityConstants.GhostTouch));
            Assert.That(abilities, Does.Not.Contain(SpecialAbilityConstants.DESIGNATEDFOEbane));
            Assert.That(abilities, Does.Not.Contain(SpecialAbilityConstants.SpellResistance));
            Assert.That(abilities, Does.Not.Contain(SpecialAbilityConstants.Fortification));
            Assert.That(abilities.Count(), Is.EqualTo(104));
        }
    }
}