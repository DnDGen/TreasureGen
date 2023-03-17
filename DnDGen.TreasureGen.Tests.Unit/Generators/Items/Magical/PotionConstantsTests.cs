using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class PotionConstantsTests
    {
        [TestCase(PotionConstants.Aid, "Potion of Aid")]
        [TestCase(PotionConstants.Barkskin, "Potion of Barkskin")]
        [TestCase(PotionConstants.BearsEndurance, "Potion of Bear's Endurance")]
        [TestCase(PotionConstants.BlessWeapon, "Oil of Bless Weapon")]
        [TestCase(PotionConstants.Blur, "Potion of Blur")]
        [TestCase(PotionConstants.BullsStrength, "Potion of Bull's Strength")]
        [TestCase(PotionConstants.CatsGrace, "Potion of Cat's Grace")]
        [TestCase(PotionConstants.CureLightWounds, "Potion of Cure Light Wounds")]
        [TestCase(PotionConstants.CureModerateWounds, "Potion of Cure Moderate Wounds")]
        [TestCase(PotionConstants.CureSeriousWounds, "Potion of Cure Serious Wounds")]
        [TestCase(PotionConstants.Darkness, "Oil of Darkness")]
        [TestCase(PotionConstants.Darkvision, "Potion of Darkvision")]
        [TestCase(PotionConstants.Daylight, "Oil of Daylight")]
        [TestCase(PotionConstants.DelayPoison, "Potion of Delay Poison")]
        [TestCase(PotionConstants.Displacement, "Potion of Displacement")]
        [TestCase(PotionConstants.EaglesSplendor, "Potion of Eagle's Splendor")]
        [TestCase(PotionConstants.EndureElements, "Potion of Endure Elements")]
        [TestCase(PotionConstants.EnlargePerson, "Potion of Enlarge Person")]
        [TestCase(PotionConstants.FlameArrow, "Oil of Flame Arrow")]
        [TestCase(PotionConstants.Fly, "Potion of Fly")]
        [TestCase(PotionConstants.FoxsCunning, "Potion of Fox's Cunning")]
        [TestCase(PotionConstants.GaseousForm, "Potion of Gaseous Form")]
        [TestCase(PotionConstants.GoodHope, "Potion of Good Hope")]
        [TestCase(PotionConstants.Haste, "Potion of Haste")]
        [TestCase(PotionConstants.Heroism, "Potion of Heroism")]
        [TestCase(PotionConstants.HideFromAnimals, "Potion of Hide from Animals")]
        [TestCase(PotionConstants.HideFromUndead, "Potion of Hide from Undead")]
        [TestCase(PotionConstants.Invisibility_Oil, "Oil of Invisibility")]
        [TestCase(PotionConstants.Invisibility_Potion, "Potion of Invisibility")]
        [TestCase(PotionConstants.Jump, "Potion of Jump")]
        [TestCase(PotionConstants.KeenEdge, "Oil of Keen Edge")]
        [TestCase(PotionConstants.Levitate_Oil, "Oil of Levitate")]
        [TestCase(PotionConstants.Levitate_Potion, "Potion of Levitate")]
        [TestCase(PotionConstants.MageArmor, "Potion of Mage Armor")]
        [TestCase(PotionConstants.MagicCircleAgainstPARTIALALIGNMENT, "Potion of Magic Circle Against PARTIALALIGNMENT")]
        [TestCase(PotionConstants.MagicCircleAgainstChaos, "Potion of Magic Circle Against Chaos")]
        [TestCase(PotionConstants.MagicCircleAgainstEvil, "Potion of Magic Circle Against Evil")]
        [TestCase(PotionConstants.MagicCircleAgainstGood, "Potion of Magic Circle Against Good")]
        [TestCase(PotionConstants.MagicCircleAgainstLaw, "Potion of Magic Circle Against Law")]
        [TestCase(PotionConstants.MagicFang, "Potion of Magic Fang")]
        [TestCase(PotionConstants.MagicFang_Greater, "Potion of Greater Magic Fang")]
        [TestCase(PotionConstants.MagicStone, "Oil of Magic Stone")]
        [TestCase(PotionConstants.MagicVestment, "Oil of Magic Vestment")]
        [TestCase(PotionConstants.MagicWeapon, "Oil of Magic Weapon")]
        [TestCase(PotionConstants.MagicWeapon_Greater, "Oil of Greater Magic Weapon")]
        [TestCase(PotionConstants.Misdirection, "Potion of Misdirection")]
        [TestCase(PotionConstants.NeutralizePoison, "Potion of Neutralize Poison")]
        [TestCase(PotionConstants.Nondetection, "Potion of Nondetection")]
        [TestCase(PotionConstants.OwlsWisdom, "Potion of Owl's Wisdom")]
        [TestCase(PotionConstants.PassWithoutTrace, "Potion of Pass Without Trace")]
        [TestCase(PotionConstants.Poison, "Potion of Poison")]
        [TestCase(PotionConstants.ProtectionFromPARTIALALIGNMENT, "Potion of Protection from PARTIALALIGNMENT")]
        [TestCase(PotionConstants.ProtectionFromChaos, "Potion of Protection from Chaos")]
        [TestCase(PotionConstants.ProtectionFromEvil, "Potion of Protection from Evil")]
        [TestCase(PotionConstants.ProtectionFromGood, "Potion of Protection from Good")]
        [TestCase(PotionConstants.ProtectionFromLaw, "Potion of Protection from Law")]
        [TestCase(PotionConstants.ProtectionFromArrows_10, "Potion of Protection from Arrows 10/magic")]
        [TestCase(PotionConstants.ProtectionFromArrows_15, "Potion of Protection from Arrows 15/magic")]
        [TestCase(PotionConstants.ProtectionFromENERGY, "Potion of Protection from ENERGY")]
        [TestCase(PotionConstants.ProtectionFromCold, "Potion of Protection from Cold")]
        [TestCase(PotionConstants.ProtectionFromElectricity, "Potion of Protection from Electricity")]
        [TestCase(PotionConstants.ProtectionFromFire, "Potion of Protection from Fire")]
        [TestCase(PotionConstants.ProtectionFromSonic, "Potion of Protection from Sonic")]
        [TestCase(PotionConstants.ProtectionFromAcid, "Potion of Protection from Acid")]
        [TestCase(PotionConstants.Rage, "Potion of Rage")]
        [TestCase(PotionConstants.RemoveBlindnessDeafness, "Potion of Remove Blindness/Deafness")]
        [TestCase(PotionConstants.RemoveCurse, "Potion of Remove Curse")]
        [TestCase(PotionConstants.RemoveDisease, "Potion of Remove Disease")]
        [TestCase(PotionConstants.ReducePerson, "Potion of Reduce Person")]
        [TestCase(PotionConstants.RemoveFear, "Potion of Remove Fear")]
        [TestCase(PotionConstants.RemoveParalysis, "Potion of Remove Paralysis")]
        [TestCase(PotionConstants.ResistENERGY_10, "Potion of Resist ENERGY 10")]
        [TestCase(PotionConstants.ResistAcid_10, "Potion of Resist Acid 10")]
        [TestCase(PotionConstants.ResistCold_10, "Potion of Resist Cold 10")]
        [TestCase(PotionConstants.ResistElectricity_10, "Potion of Resist Electricity 10")]
        [TestCase(PotionConstants.ResistFire_10, "Potion of Resist Fire 10")]
        [TestCase(PotionConstants.ResistSonic_10, "Potion of Resist Sonic 10")]
        [TestCase(PotionConstants.ResistENERGY_20, "Potion of Resist ENERGY 20")]
        [TestCase(PotionConstants.ResistAcid_20, "Potion of Resist Acid 20")]
        [TestCase(PotionConstants.ResistCold_20, "Potion of Resist Cold 20")]
        [TestCase(PotionConstants.ResistElectricity_20, "Potion of Resist Electricity 20")]
        [TestCase(PotionConstants.ResistFire_20, "Potion of Resist Fire 20")]
        [TestCase(PotionConstants.ResistSonic_20, "Potion of Resist Sonic 20")]
        [TestCase(PotionConstants.ResistENERGY_30, "Potion of Resist ENERGY 30")]
        [TestCase(PotionConstants.ResistAcid_30, "Potion of Resist Acid 30")]
        [TestCase(PotionConstants.ResistCold_30, "Potion of Resist Cold 30")]
        [TestCase(PotionConstants.ResistElectricity_30, "Potion of Resist Electricity 30")]
        [TestCase(PotionConstants.ResistFire_30, "Potion of Resist Fire 30")]
        [TestCase(PotionConstants.ResistSonic_30, "Potion of Resist Sonic 30")]
        [TestCase(PotionConstants.Restoration_Lesser, "Potion of Lesser Restoration")]
        [TestCase(PotionConstants.Sanctuary, "Potion of Sanctuary")]
        [TestCase(PotionConstants.ShieldOfFaith, "Potion of Shield of Faith")]
        [TestCase(PotionConstants.Shillelagh, "Oil of Shillelagh")]
        [TestCase(PotionConstants.SpiderClimb, "Potion of Spider Climb")]
        [TestCase(PotionConstants.Tongues, "Potion of Tongues")]
        [TestCase(PotionConstants.UndetectableAlignment, "Potion of Undetectable Alignment")]
        [TestCase(PotionConstants.WaterBreathing, "Potion of Water Breathing")]
        [TestCase(PotionConstants.WaterWalk, "Potion of Water Walk")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllPotions()
        {
            var potions = PotionConstants.GetAllPotions(false);

            Assert.That(potions, Contains.Item(PotionConstants.Aid));
            Assert.That(potions, Contains.Item(PotionConstants.Barkskin));
            Assert.That(potions, Contains.Item(PotionConstants.BearsEndurance));
            Assert.That(potions, Contains.Item(PotionConstants.BlessWeapon));
            Assert.That(potions, Contains.Item(PotionConstants.Blur));
            Assert.That(potions, Contains.Item(PotionConstants.BullsStrength));
            Assert.That(potions, Contains.Item(PotionConstants.CatsGrace));
            Assert.That(potions, Contains.Item(PotionConstants.CureLightWounds));
            Assert.That(potions, Contains.Item(PotionConstants.CureModerateWounds));
            Assert.That(potions, Contains.Item(PotionConstants.CureSeriousWounds));
            Assert.That(potions, Contains.Item(PotionConstants.Darkness));
            Assert.That(potions, Contains.Item(PotionConstants.Darkvision));
            Assert.That(potions, Contains.Item(PotionConstants.Daylight));
            Assert.That(potions, Contains.Item(PotionConstants.DelayPoison));
            Assert.That(potions, Contains.Item(PotionConstants.Displacement));
            Assert.That(potions, Contains.Item(PotionConstants.EaglesSplendor));
            Assert.That(potions, Contains.Item(PotionConstants.EndureElements));
            Assert.That(potions, Contains.Item(PotionConstants.EnlargePerson));
            Assert.That(potions, Contains.Item(PotionConstants.FlameArrow));
            Assert.That(potions, Contains.Item(PotionConstants.Fly));
            Assert.That(potions, Contains.Item(PotionConstants.FoxsCunning));
            Assert.That(potions, Contains.Item(PotionConstants.GaseousForm));
            Assert.That(potions, Contains.Item(PotionConstants.GoodHope));
            Assert.That(potions, Contains.Item(PotionConstants.Haste));
            Assert.That(potions, Contains.Item(PotionConstants.Heroism));
            Assert.That(potions, Contains.Item(PotionConstants.HideFromAnimals));
            Assert.That(potions, Contains.Item(PotionConstants.HideFromUndead));
            Assert.That(potions, Contains.Item(PotionConstants.Invisibility_Oil));
            Assert.That(potions, Contains.Item(PotionConstants.Invisibility_Potion));
            Assert.That(potions, Contains.Item(PotionConstants.Jump));
            Assert.That(potions, Contains.Item(PotionConstants.KeenEdge));
            Assert.That(potions, Contains.Item(PotionConstants.Levitate_Oil));
            Assert.That(potions, Contains.Item(PotionConstants.Levitate_Potion));
            Assert.That(potions, Contains.Item(PotionConstants.MageArmor));
            Assert.That(potions, Contains.Item(PotionConstants.MagicCircleAgainstChaos));
            Assert.That(potions, Contains.Item(PotionConstants.MagicCircleAgainstLaw));
            Assert.That(potions, Contains.Item(PotionConstants.MagicCircleAgainstGood));
            Assert.That(potions, Contains.Item(PotionConstants.MagicCircleAgainstEvil));
            Assert.That(potions, Contains.Item(PotionConstants.MagicFang));
            Assert.That(potions, Contains.Item(PotionConstants.MagicFang_Greater));
            Assert.That(potions, Contains.Item(PotionConstants.MagicStone));
            Assert.That(potions, Contains.Item(PotionConstants.MagicVestment));
            Assert.That(potions, Contains.Item(PotionConstants.MagicWeapon));
            Assert.That(potions, Contains.Item(PotionConstants.MagicWeapon_Greater));
            Assert.That(potions, Contains.Item(PotionConstants.Misdirection));
            Assert.That(potions, Contains.Item(PotionConstants.NeutralizePoison));
            Assert.That(potions, Contains.Item(PotionConstants.Nondetection));
            Assert.That(potions, Contains.Item(PotionConstants.OwlsWisdom));
            Assert.That(potions, Contains.Item(PotionConstants.PassWithoutTrace));
            Assert.That(potions, Contains.Item(PotionConstants.Poison));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromArrows_10));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromArrows_15));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromFire));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromSonic));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromAcid));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromElectricity));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromCold));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromGood));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromEvil));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromLaw));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromChaos));
            Assert.That(potions, Contains.Item(PotionConstants.Rage));
            Assert.That(potions, Contains.Item(PotionConstants.ReducePerson));
            Assert.That(potions, Contains.Item(PotionConstants.RemoveBlindnessDeafness));
            Assert.That(potions, Contains.Item(PotionConstants.RemoveCurse));
            Assert.That(potions, Contains.Item(PotionConstants.RemoveDisease));
            Assert.That(potions, Contains.Item(PotionConstants.RemoveFear));
            Assert.That(potions, Contains.Item(PotionConstants.RemoveParalysis));
            Assert.That(potions, Contains.Item(PotionConstants.ResistCold_10));
            Assert.That(potions, Contains.Item(PotionConstants.ResistElectricity_10));
            Assert.That(potions, Contains.Item(PotionConstants.ResistFire_10));
            Assert.That(potions, Contains.Item(PotionConstants.ResistSonic_10));
            Assert.That(potions, Contains.Item(PotionConstants.ResistAcid_10));
            Assert.That(potions, Contains.Item(PotionConstants.ResistCold_20));
            Assert.That(potions, Contains.Item(PotionConstants.ResistElectricity_20));
            Assert.That(potions, Contains.Item(PotionConstants.ResistFire_20));
            Assert.That(potions, Contains.Item(PotionConstants.ResistSonic_20));
            Assert.That(potions, Contains.Item(PotionConstants.ResistAcid_20));
            Assert.That(potions, Contains.Item(PotionConstants.ResistCold_30));
            Assert.That(potions, Contains.Item(PotionConstants.ResistElectricity_30));
            Assert.That(potions, Contains.Item(PotionConstants.ResistFire_30));
            Assert.That(potions, Contains.Item(PotionConstants.ResistSonic_30));
            Assert.That(potions, Contains.Item(PotionConstants.ResistAcid_30));
            Assert.That(potions, Contains.Item(PotionConstants.Restoration_Lesser));
            Assert.That(potions, Contains.Item(PotionConstants.Sanctuary));
            Assert.That(potions, Contains.Item(PotionConstants.ShieldOfFaith));
            Assert.That(potions, Contains.Item(PotionConstants.Shillelagh));
            Assert.That(potions, Contains.Item(PotionConstants.SpiderClimb));
            Assert.That(potions, Contains.Item(PotionConstants.Tongues));
            Assert.That(potions, Contains.Item(PotionConstants.UndetectableAlignment));
            Assert.That(potions, Contains.Item(PotionConstants.WaterBreathing));
            Assert.That(potions, Contains.Item(PotionConstants.WaterWalk));
            Assert.That(potions.Count(), Is.EqualTo(92));

            Assert.That(potions, Does.Not.Contain(PotionConstants.MagicCircleAgainstPARTIALALIGNMENT));
            Assert.That(potions, Does.Not.Contain(PotionConstants.ProtectionFromENERGY));
            Assert.That(potions, Does.Not.Contain(PotionConstants.ProtectionFromPARTIALALIGNMENT));
            Assert.That(potions, Does.Not.Contain(PotionConstants.ResistENERGY_10));
            Assert.That(potions, Does.Not.Contain(PotionConstants.ResistENERGY_20));
            Assert.That(potions, Does.Not.Contain(PotionConstants.ResistENERGY_30));
        }

        [Test]
        public void AllPotions_WithTemplates()
        {
            var potions = PotionConstants.GetAllPotions(true);

            Assert.That(potions, Contains.Item(PotionConstants.Aid));
            Assert.That(potions, Contains.Item(PotionConstants.Barkskin));
            Assert.That(potions, Contains.Item(PotionConstants.BearsEndurance));
            Assert.That(potions, Contains.Item(PotionConstants.BlessWeapon));
            Assert.That(potions, Contains.Item(PotionConstants.Blur));
            Assert.That(potions, Contains.Item(PotionConstants.BullsStrength));
            Assert.That(potions, Contains.Item(PotionConstants.CatsGrace));
            Assert.That(potions, Contains.Item(PotionConstants.CureLightWounds));
            Assert.That(potions, Contains.Item(PotionConstants.CureModerateWounds));
            Assert.That(potions, Contains.Item(PotionConstants.CureSeriousWounds));
            Assert.That(potions, Contains.Item(PotionConstants.Darkness));
            Assert.That(potions, Contains.Item(PotionConstants.Darkvision));
            Assert.That(potions, Contains.Item(PotionConstants.Daylight));
            Assert.That(potions, Contains.Item(PotionConstants.DelayPoison));
            Assert.That(potions, Contains.Item(PotionConstants.Displacement));
            Assert.That(potions, Contains.Item(PotionConstants.EaglesSplendor));
            Assert.That(potions, Contains.Item(PotionConstants.EndureElements));
            Assert.That(potions, Contains.Item(PotionConstants.EnlargePerson));
            Assert.That(potions, Contains.Item(PotionConstants.FlameArrow));
            Assert.That(potions, Contains.Item(PotionConstants.Fly));
            Assert.That(potions, Contains.Item(PotionConstants.FoxsCunning));
            Assert.That(potions, Contains.Item(PotionConstants.GaseousForm));
            Assert.That(potions, Contains.Item(PotionConstants.GoodHope));
            Assert.That(potions, Contains.Item(PotionConstants.Haste));
            Assert.That(potions, Contains.Item(PotionConstants.Heroism));
            Assert.That(potions, Contains.Item(PotionConstants.HideFromAnimals));
            Assert.That(potions, Contains.Item(PotionConstants.HideFromUndead));
            Assert.That(potions, Contains.Item(PotionConstants.Invisibility_Oil));
            Assert.That(potions, Contains.Item(PotionConstants.Invisibility_Potion));
            Assert.That(potions, Contains.Item(PotionConstants.Jump));
            Assert.That(potions, Contains.Item(PotionConstants.KeenEdge));
            Assert.That(potions, Contains.Item(PotionConstants.Levitate_Oil));
            Assert.That(potions, Contains.Item(PotionConstants.Levitate_Potion));
            Assert.That(potions, Contains.Item(PotionConstants.MageArmor));
            Assert.That(potions, Contains.Item(PotionConstants.MagicCircleAgainstChaos));
            Assert.That(potions, Contains.Item(PotionConstants.MagicCircleAgainstLaw));
            Assert.That(potions, Contains.Item(PotionConstants.MagicCircleAgainstGood));
            Assert.That(potions, Contains.Item(PotionConstants.MagicCircleAgainstEvil));
            Assert.That(potions, Contains.Item(PotionConstants.MagicFang));
            Assert.That(potions, Contains.Item(PotionConstants.MagicFang_Greater));
            Assert.That(potions, Contains.Item(PotionConstants.MagicStone));
            Assert.That(potions, Contains.Item(PotionConstants.MagicVestment));
            Assert.That(potions, Contains.Item(PotionConstants.MagicWeapon));
            Assert.That(potions, Contains.Item(PotionConstants.MagicWeapon_Greater));
            Assert.That(potions, Contains.Item(PotionConstants.Misdirection));
            Assert.That(potions, Contains.Item(PotionConstants.NeutralizePoison));
            Assert.That(potions, Contains.Item(PotionConstants.Nondetection));
            Assert.That(potions, Contains.Item(PotionConstants.OwlsWisdom));
            Assert.That(potions, Contains.Item(PotionConstants.PassWithoutTrace));
            Assert.That(potions, Contains.Item(PotionConstants.Poison));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromArrows_10));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromArrows_15));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromFire));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromSonic));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromAcid));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromElectricity));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromCold));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromGood));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromEvil));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromLaw));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromChaos));
            Assert.That(potions, Contains.Item(PotionConstants.Rage));
            Assert.That(potions, Contains.Item(PotionConstants.ReducePerson));
            Assert.That(potions, Contains.Item(PotionConstants.RemoveBlindnessDeafness));
            Assert.That(potions, Contains.Item(PotionConstants.RemoveCurse));
            Assert.That(potions, Contains.Item(PotionConstants.RemoveDisease));
            Assert.That(potions, Contains.Item(PotionConstants.RemoveFear));
            Assert.That(potions, Contains.Item(PotionConstants.RemoveParalysis));
            Assert.That(potions, Contains.Item(PotionConstants.ResistCold_10));
            Assert.That(potions, Contains.Item(PotionConstants.ResistElectricity_10));
            Assert.That(potions, Contains.Item(PotionConstants.ResistFire_10));
            Assert.That(potions, Contains.Item(PotionConstants.ResistSonic_10));
            Assert.That(potions, Contains.Item(PotionConstants.ResistAcid_10));
            Assert.That(potions, Contains.Item(PotionConstants.ResistCold_20));
            Assert.That(potions, Contains.Item(PotionConstants.ResistElectricity_20));
            Assert.That(potions, Contains.Item(PotionConstants.ResistFire_20));
            Assert.That(potions, Contains.Item(PotionConstants.ResistSonic_20));
            Assert.That(potions, Contains.Item(PotionConstants.ResistAcid_20));
            Assert.That(potions, Contains.Item(PotionConstants.ResistCold_30));
            Assert.That(potions, Contains.Item(PotionConstants.ResistElectricity_30));
            Assert.That(potions, Contains.Item(PotionConstants.ResistFire_30));
            Assert.That(potions, Contains.Item(PotionConstants.ResistSonic_30));
            Assert.That(potions, Contains.Item(PotionConstants.ResistAcid_30));
            Assert.That(potions, Contains.Item(PotionConstants.Restoration_Lesser));
            Assert.That(potions, Contains.Item(PotionConstants.Sanctuary));
            Assert.That(potions, Contains.Item(PotionConstants.ShieldOfFaith));
            Assert.That(potions, Contains.Item(PotionConstants.Shillelagh));
            Assert.That(potions, Contains.Item(PotionConstants.SpiderClimb));
            Assert.That(potions, Contains.Item(PotionConstants.Tongues));
            Assert.That(potions, Contains.Item(PotionConstants.UndetectableAlignment));
            Assert.That(potions, Contains.Item(PotionConstants.WaterBreathing));
            Assert.That(potions, Contains.Item(PotionConstants.WaterWalk));
            Assert.That(potions.Count(), Is.EqualTo(98));

            Assert.That(potions, Contains.Item(PotionConstants.MagicCircleAgainstPARTIALALIGNMENT));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromENERGY));
            Assert.That(potions, Contains.Item(PotionConstants.ProtectionFromPARTIALALIGNMENT));
            Assert.That(potions, Contains.Item(PotionConstants.ResistENERGY_10));
            Assert.That(potions, Contains.Item(PotionConstants.ResistENERGY_20));
            Assert.That(potions, Contains.Item(PotionConstants.ResistENERGY_30));
        }
    }
}