using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class PotionConstantsTests
    {
        [TestCase(PotionConstants.Aid, "Potion of aid")]
        [TestCase(PotionConstants.Barkskin, "Potion of barkskin")]
        [TestCase(PotionConstants.BearsEndurance, "Potion of bear's endurance")]
        [TestCase(PotionConstants.BlessWeapon, "Oil of bless weapon")]
        [TestCase(PotionConstants.Blur, "Potion of blur")]
        [TestCase(PotionConstants.BullsStrength, "Potion of bull's strength")]
        [TestCase(PotionConstants.CatsGrace, "Potion of cat's grace")]
        [TestCase(PotionConstants.CureLightWounds, "Potion of cure light wounds")]
        [TestCase(PotionConstants.CureModerateWounds, "Potion of cure moderate wounds")]
        [TestCase(PotionConstants.CureSeriousWounds, "Potion of cure serious wounds")]
        [TestCase(PotionConstants.Darkness, "Oil of darkness")]
        [TestCase(PotionConstants.Darkvision, "Potion of darkvision")]
        [TestCase(PotionConstants.Daylight, "Oil of daylight")]
        [TestCase(PotionConstants.DelayPoison, "Potion of delay poison")]
        [TestCase(PotionConstants.Displacement, "Potion of displacement")]
        [TestCase(PotionConstants.EaglesSplendor, "Potion of eagle's splendor")]
        [TestCase(PotionConstants.EndureElements, "Potion of endure elements")]
        [TestCase(PotionConstants.EnlargePerson, "Potion of enlarge person")]
        [TestCase(PotionConstants.FlameArrow, "Oil of flame arrow")]
        [TestCase(PotionConstants.Fly, "Potion of fly")]
        [TestCase(PotionConstants.FoxsCunning, "Potion of fox's cunning")]
        [TestCase(PotionConstants.GaseousForm, "Potion of gaseous form")]
        [TestCase(PotionConstants.GoodHope, "Potion of good hope")]
        [TestCase(PotionConstants.Haste, "Potion of haste")]
        [TestCase(PotionConstants.Heroism, "Potion of heroism")]
        [TestCase(PotionConstants.HideFromAnimals, "Potion of hide from animals")]
        [TestCase(PotionConstants.HideFromUndead, "Potion of hide from undead")]
        [TestCase(PotionConstants.Invisibility_Oil, "Oil of invisibility")]
        [TestCase(PotionConstants.Invisibility_Potion, "Potion of invisibility")]
        [TestCase(PotionConstants.Jump, "Potion of jump")]
        [TestCase(PotionConstants.KeenEdge, "Oil of keen edge")]
        [TestCase(PotionConstants.Levitate_Oil, "Oil of levitate")]
        [TestCase(PotionConstants.Levitate_Potion, "Potion of levitate")]
        [TestCase(PotionConstants.MageArmor, "Potion of mage armor")]
        [TestCase(PotionConstants.MagicCircleAgainstPARTIALALIGNMENT, "Potion of magic circle against PARTIALALIGNMENT")]
        [TestCase(PotionConstants.MagicCircleAgainstChaos, "Potion of magic circle against Chaos")]
        [TestCase(PotionConstants.MagicCircleAgainstEvil, "Potion of magic circle against Evil")]
        [TestCase(PotionConstants.MagicCircleAgainstGood, "Potion of magic circle against Good")]
        [TestCase(PotionConstants.MagicCircleAgainstLaw, "Potion of magic circle against Law")]
        [TestCase(PotionConstants.MagicFang, "Potion of magic fang")]
        [TestCase(PotionConstants.MagicFang_Greater, "Potion of greater magic fang")]
        [TestCase(PotionConstants.MagicStone, "Oil of magic stone")]
        [TestCase(PotionConstants.MagicVestment, "Oil of magic vestment")]
        [TestCase(PotionConstants.MagicWeapon, "Oil of magic weapon")]
        [TestCase(PotionConstants.MagicWeapon_Greater, "Oil of greater magic weapon")]
        [TestCase(PotionConstants.Misdirection, "Potion of misdirection")]
        [TestCase(PotionConstants.NeutralizePoison, "Potion of neutralize poison")]
        [TestCase(PotionConstants.Nondetection, "Potion of nondetection")]
        [TestCase(PotionConstants.OwlsWisdom, "Potion of owl's wisdom")]
        [TestCase(PotionConstants.PassWithoutTrace, "Potion of pass without trace")]
        [TestCase(PotionConstants.Poison, "Potion of poison")]
        [TestCase(PotionConstants.ProtectionFromPARTIALALIGNMENT, "Potion of protection from PARTIALALIGNMENT")]
        [TestCase(PotionConstants.ProtectionFromChaos, "Potion of protection from Chaos")]
        [TestCase(PotionConstants.ProtectionFromEvil, "Potion of protection from Evil")]
        [TestCase(PotionConstants.ProtectionFromGood, "Potion of protection from Good")]
        [TestCase(PotionConstants.ProtectionFromLaw, "Potion of protection from Law")]
        [TestCase(PotionConstants.ProtectionFromArrows_10, "Potion of protection from arrows 10/magic")]
        [TestCase(PotionConstants.ProtectionFromArrows_15, "Potion of protection from arrows 15/magic")]
        [TestCase(PotionConstants.ProtectionFromENERGY, "Potion of protection from ENERGY")]
        [TestCase(PotionConstants.ProtectionFromCold, "Potion of protection from Cold")]
        [TestCase(PotionConstants.ProtectionFromElectricity, "Potion of protection from Electricity")]
        [TestCase(PotionConstants.ProtectionFromFire, "Potion of protection from Fire")]
        [TestCase(PotionConstants.ProtectionFromSonic, "Potion of protection from Sonic")]
        [TestCase(PotionConstants.ProtectionFromAcid, "Potion of protection from Acid")]
        [TestCase(PotionConstants.Rage, "Potion of rage")]
        [TestCase(PotionConstants.RemoveBlindnessDeafness, "Potion of remove blindness/deafness")]
        [TestCase(PotionConstants.RemoveCurse, "Potion of remove curse")]
        [TestCase(PotionConstants.RemoveDisease, "Potion of remove disease")]
        [TestCase(PotionConstants.ReducePerson, "Potion of reduce person")]
        [TestCase(PotionConstants.RemoveFear, "Potion of remove fear")]
        [TestCase(PotionConstants.RemoveParalysis, "Potion of remove paralysis")]
        [TestCase(PotionConstants.ResistENERGY_10, "Potion of resist ENERGY 10")]
        [TestCase(PotionConstants.ResistAcid_10, "Potion of resist Acid 10")]
        [TestCase(PotionConstants.ResistCold_10, "Potion of resist Cold 10")]
        [TestCase(PotionConstants.ResistElectricity_10, "Potion of resist Electricity 10")]
        [TestCase(PotionConstants.ResistFire_10, "Potion of resist Fire 10")]
        [TestCase(PotionConstants.ResistSonic_10, "Potion of resist Sonic 10")]
        [TestCase(PotionConstants.ResistENERGY_20, "Potion of resist ENERGY 20")]
        [TestCase(PotionConstants.ResistAcid_20, "Potion of resist Acid 20")]
        [TestCase(PotionConstants.ResistCold_20, "Potion of resist Cold 20")]
        [TestCase(PotionConstants.ResistElectricity_20, "Potion of resist Electricity 20")]
        [TestCase(PotionConstants.ResistFire_20, "Potion of resist Fire 20")]
        [TestCase(PotionConstants.ResistSonic_20, "Potion of resist Sonic 20")]
        [TestCase(PotionConstants.ResistENERGY_30, "Potion of resist ENERGY 30")]
        [TestCase(PotionConstants.ResistAcid_30, "Potion of resist Acid 30")]
        [TestCase(PotionConstants.ResistCold_30, "Potion of resist Cold 30")]
        [TestCase(PotionConstants.ResistElectricity_30, "Potion of resist Electricity 30")]
        [TestCase(PotionConstants.ResistFire_30, "Potion of resist Fire 30")]
        [TestCase(PotionConstants.ResistSonic_30, "Potion of resist Sonic 30")]
        [TestCase(PotionConstants.Restoration_Lesser, "Potion of lesser restoration")]
        [TestCase(PotionConstants.Sanctuary, "Potion of sanctuary")]
        [TestCase(PotionConstants.ShieldOfFaith, "Potion of shield of faith")]
        [TestCase(PotionConstants.Shillelagh, "Oil of shillelagh")]
        [TestCase(PotionConstants.SpiderClimb, "Potion of spider climb")]
        [TestCase(PotionConstants.Tongues, "Potion of tongues")]
        [TestCase(PotionConstants.UndetectableAlignment, "Potion of undetectable alignment")]
        [TestCase(PotionConstants.WaterBreathing, "Potion of water breathing")]
        [TestCase(PotionConstants.WaterWalk, "Potion of water walk")]
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