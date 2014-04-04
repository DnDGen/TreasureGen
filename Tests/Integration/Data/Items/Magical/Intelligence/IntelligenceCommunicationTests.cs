using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IntelligenceCommunicationTests : AttributesTests
    {
        protected override String GetTableName()
        {
            return "IntelligenceCommunication";
        }

        [Test]
        public void CommunicationForStrength12()
        {
            var attributes = new[]
            {
                "Empathy"
            };

            AssertContent("12", attributes);
        }

        [Test]
        public void CommunicationForStrength13()
        {
            var attributes = new[]
            {
                "Empathy"
            };

            AssertContent("13", attributes);
        }

        [Test]
        public void CommunicationForStrength14()
        {
            var attributes = new[]
            {
                "Speech"
            };

            AssertContent("14", attributes);
        }

        [Test]
        public void CommunicationForStrength15()
        {
            var attributes = new[]
            {
                "Speech"
            };

            AssertContent("15", attributes);
        }

        [Test]
        public void CommunicationForStrength16()
        {
            var attributes = new[]
            {
                "Speech",
                "Read"
            };

            AssertContent("16", attributes);
        }

        [Test]
        public void CommunicationForStrength17()
        {
            var attributes = new[]
            {
                "Speech",
                "Read",
                "Telepathy"
            };

            AssertContent("17", attributes);
        }

        [Test]
        public void CommunicationForStrength18()
        {
            var attributes = new[]
            {
                "Speech",
                "Read all languages",
                "Read magic",
                "Telepathy"
            };

            AssertContent("18", attributes);
        }

        [Test]
        public void CommunicationForStrength19()
        {
            var attributes = new[]
            {
                "Speech",
                "Read all languages",
                "Read magic",
                "Telepathy"
            };

            AssertContent("19", attributes);
        }
    }
}