using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class WondrousItemAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "GemDescriptions"; }
        }

        protected override String GetTableName()
        {
            return "WondrousItemAttributes";
        }

        [Test]
        public void BeadOfForceAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Bead of force", attributes);
        }

        [Test]
        public void BraceletOfFriendsAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertAttributes("Bracelet of friends", attributes);
        }

        [Test]
        public void BroochOfShieldingAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertAttributes("Brooch of shielding", attributes);
        }

        [Test]
        public void CandleOfInvocationAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Candle of invocation", attributes);
        }

        [Test]
        public void CandleOfTruthAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Candle of truth", attributes);
        }

        [Test]
        public void ChimeOfOpeningAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertAttributes("Chime of opening", attributes);
        }

        [Test]
        public void DeckOfIllusionsAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertAttributes("Deck of illusions", attributes);
        }

        [Test]
        public void DustOfAppearanceAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Dust of appearance", attributes);
        }

        [Test]
        public void DustOfDisappearanceAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Dust of disappearance", attributes);
        }

        [Test]
        public void DustOfIllusionAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Dust of illusion", attributes);
        }

        [Test]
        public void DustOfTracelessnessAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Dust of tracelessness", attributes);
        }

        [Test]
        public void ElementalGemAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Elemental gem", attributes);
        }

        [Test]
        public void ElixerOfFireBreathAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Elixer of fire breath", attributes);
        }

        [Test]
        public void ElixerOfHidingAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Elixer of hiding", attributes);
        }

        [Test]
        public void ElixerOfLoveAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Elixer of love", attributes);
        }

        [Test]
        public void ElixerOfSneakingAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Elixer of sneaking", attributes);
        }

        [Test]
        public void ElixerOfSwimmingAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Elixer of swimming", attributes);
        }

        [Test]
        public void ElixerOfTruthAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Elixer of truth", attributes);
        }

        [Test]
        public void ElixerOfVisionAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Elixer of vision", attributes);
        }

        [Test]
        public void GemOfBrightnessAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertAttributes("Gem of brightness", attributes);
        }

        [Test]
        public void ClayGolemManualAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Clay golem manual", attributes);
        }

        [Test]
        public void FleshGolemManualAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Flesh golem manual", attributes);
        }

        [Test]
        public void IronGolemManualAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Iron golem manual", attributes);
        }

        [Test]
        public void StoneGolemManualAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Stone golem manual", attributes);
        }

        [Test]
        public void GreaterStoneGolemManualAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Greater stone golem manual", attributes);
        }

        [Test]
        public void IncenseOfMeditationAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Incense of meditation", attributes);
        }

        [Test]
        public void KeoghtomsOintmentAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertAttributes("Keoghtom's ointment", attributes);
        }

        [Test]
        public void ManualOfBodilyHealthAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Manual of bodily health", attributes);
        }

        [Test]
        public void ManualOfGainfulExerciseAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Manual of gainful exercise", attributes);
        }

        [Test]
        public void ManualOfQuicknessInActionAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Manual of quickness in action", attributes);
        }

        [Test]
        public void NolzursMarvelousPigmentsAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Nolzur's marvelous pigments", attributes);
        }

        [Test]
        public void QuaalsFeatherTokenAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Quaal's feather token", attributes);
        }

        [Test]
        public void RobeOfUsefulItemsAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Robe of useful items", attributes);
        }

        [Test]
        public void RobeOfBonesAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Robe of bones", attributes);
        }

        [Test]
        public void SalveOfSlipperinessAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Salve of slipperiness", attributes);
        }

        [Test]
        public void SovereignGlueAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Sovereign glue", attributes);
        }

        [Test]
        public void ScarabOfProtectionAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertAttributes("Scarab of protection", attributes);
        }

        [Test]
        public void ShroudsOfDisintegrationAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Shrouds of disintegration", attributes);
        }

        [Test]
        public void SilversheenAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Silversheen", attributes);
        }

        [Test]
        public void StoneSalveAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Stone salve", attributes);
        }

        [Test]
        public void TomeOfClearThoughtAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Tome of clear thought", attributes);
        }

        [Test]
        public void TomeOfLeadershipAndInfluenceAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Tome of leadership and influence", attributes);
        }

        [Test]
        public void TomeOfUnderstandingAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Tome of understanding", attributes);
        }

        [Test]
        public void UnguentOfTimelessnessAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Unguent of timelessness", attributes);
        }

        [Test]
        public void UniversalSolventAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Universal solvent", attributes);
        }
    }
}