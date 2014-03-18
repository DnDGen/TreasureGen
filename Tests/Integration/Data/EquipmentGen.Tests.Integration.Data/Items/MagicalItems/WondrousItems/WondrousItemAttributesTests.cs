using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MagicalItems.WondrousItems
{
    [TestFixture, AttributesTable("WondrousItemAttributes")]
    public class WondrousItemAttributesTests : AttributesTests
    {
        [Test]
        public void BeadOfForceAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Bead of force", attributes);
        }

        [Test]
        public void BraceletOfFriendsAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertContent("Bracelet of friends", attributes);
        }

        [Test]
        public void BroochOfShieldingAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertContent("Brooch of shielding", attributes);
        }

        [Test]
        public void CandleOfInvocationAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Candle of invocation", attributes);
        }

        [Test]
        public void CandleOfTruthAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Candle of truth", attributes);
        }

        [Test]
        public void ChimeOfOpeningAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertContent("Chime of opening", attributes);
        }

        [Test]
        public void DeckOfIllusionsAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertContent("Deck of illusions", attributes);
        }

        [Test]
        public void DustOfAppearanceAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Dust of appearance", attributes);
        }

        [Test]
        public void DustOfDisappearanceAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Dust of disappearance", attributes);
        }

        [Test]
        public void DustOfIllusionAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Dust of illusion", attributes);
        }

        [Test]
        public void DustOfTracelessnessAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Dust of tracelessness", attributes);
        }

        [Test]
        public void ElementalGemAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Elemental gem", attributes);
        }

        [Test]
        public void ElixerOfFireBreathAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Elixer of fire breath", attributes);
        }

        [Test]
        public void ElixerOfHidingAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Elixer of hiding", attributes);
        }

        [Test]
        public void ElixerOfLoveAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Elixer of love", attributes);
        }

        [Test]
        public void ElixerOfSneakingAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Elixer of sneaking", attributes);
        }

        [Test]
        public void ElixerOfSwimmingAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Elixer of swimming", attributes);
        }

        [Test]
        public void ElixerOfTruthAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Elixer of truth", attributes);
        }

        [Test]
        public void ElixerOfVisionAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Elixer of vision", attributes);
        }

        [Test]
        public void GemOfBrightnessAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertContent("Gem of brightness", attributes);
        }

        [Test]
        public void ClayGolemManualAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Clay golem manual", attributes);
        }

        [Test]
        public void FleshGolemManualAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Flesh golem manual", attributes);
        }

        [Test]
        public void IronGolemManualAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Iron golem manual", attributes);
        }

        [Test]
        public void StoneGolemManualAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Stone golem manual", attributes);
        }

        [Test]
        public void GreaterStoneGolemManualAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Greater stone golem manual", attributes);
        }

        [Test]
        public void IncenseOfMeditationAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Incense of meditation", attributes);
        }

        [Test]
        public void KeoghtomsOintmentAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertContent("Keoghtom's ointment", attributes);
        }

        [Test]
        public void ManualOfBodilyHealthAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Manual of bodily health", attributes);
        }

        [Test]
        public void ManualOfGainfulExerciseAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Manual of gainful exercise", attributes);
        }

        [Test]
        public void ManualOfQuicknessInActionAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Manual of quickness in action", attributes);
        }

        [Test]
        public void NolzursMarvelousPigmentsAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Nolzur's marvelous pigments", attributes);
        }

        [Test]
        public void QuaalsFeatherTokenAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Quaal's feather token", attributes);
        }

        [Test]
        public void RobeOfUsefulItemsAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Robe of useful items", attributes);
        }

        [Test]
        public void RobeOfBonesAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Robe of bones", attributes);
        }

        [Test]
        public void SalveOfSlipperinessAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Salve of slipperiness", attributes);
        }

        [Test]
        public void SovereignGlueAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Sovereign glue", attributes);
        }

        [Test]
        public void ScarabOfProtectionAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse,
                AttributeConstants.Charged
            };

            AssertContent("Scarab of protection", attributes);
        }

        [Test]
        public void ShroudsOfDisintegrationAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Shrouds of disintegration", attributes);
        }

        [Test]
        public void SilversheenAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Silversheen", attributes);
        }

        [Test]
        public void StoneSalveAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Stone salve", attributes);
        }

        [Test]
        public void TomeOfClearThoughtAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Tome of clear thought", attributes);
        }

        [Test]
        public void TomeOfLeadershipAndInfluenceAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Tome of leadership and influence", attributes);
        }

        [Test]
        public void TomeOfUnderstandingAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Tome of understanding", attributes);
        }

        [Test]
        public void UnguentOfTimelessnessAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Unguent of timelessness", attributes);
        }

        [Test]
        public void UniversalSolventAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.OneTimeUse
            };

            AssertContent("Universal solvent", attributes);
        }
    }
}