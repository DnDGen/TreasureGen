using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TreasureGen.Tables;
using TreasureGen.Tests.Integration.Common;

namespace TreasureGen.Tests.Integration.Tables
{
    [TestFixture]
    public class EmbeddedResourceStreamLoaderTests : IntegrationTests
    {
        [Inject]
        public IStreamLoader StreamLoader { get; set; }

        [Test]
        public void GetsFileIfItIsAnEmbeddedResource()
        {
            var table = LoadStreamOf("Level1Coins.xml");

            for (var i = 1; i <= 14; i++)
                Assert.That(table[i], Is.Empty);

            for (var i = 15; i <= 29; i++)
                Assert.That(table[i], Is.EqualTo("Copper,1000d6"));

            for (var i = 30; i <= 52; i++)
                Assert.That(table[i], Is.EqualTo("Silver,100d8"));

            for (var i = 53; i <= 95; i++)
                Assert.That(table[i], Is.EqualTo("Gold,20d8"));

            for (var i = 96; i <= 100; i++)
                Assert.That(table[i], Is.EqualTo("Platinum,10d4"));
        }

        private Dictionary<Int32, String> LoadStreamOf(String filename)
        {
            var table = new Dictionary<Int32, String>();
            var xmlDocument = new XmlDocument();

            using (var stream = StreamLoader.LoadFor(filename))
                xmlDocument.Load(stream);

            var objects = xmlDocument.DocumentElement.ChildNodes;
            foreach (XmlNode node in objects)
            {
                var lower = Convert.ToInt32(node.SelectSingleNode("lower").InnerText);
                var upper = Convert.ToInt32(node.SelectSingleNode("upper").InnerText);
                var content = node.SelectSingleNode("content").InnerText;

                for (var i = lower; i <= upper; i++)
                    table.Add(i, content);
            }

            return table;
        }

        [Test]
        public void ThrowErrorIfFileIsNotFormattedCorrectly()
        {
            Assert.That(() => StreamLoader.LoadFor("Coins"), Throws.ArgumentException.With.Message.EqualTo("\"Coins\" is not a valid file"));
        }

        [Test]
        public void ThrowErrorIfFileIsNotAnEmbeddedResource()
        {
            Assert.That(() => StreamLoader.LoadFor("invalid filename.xml"), Throws.InstanceOf<FileNotFoundException>().With.Message.EqualTo("invalid filename.xml"));
        }

        [Test]
        public void MatchWholeFileName()
        {
            Assert.That(() => StreamLoader.LoadFor("Coins.xml"), Throws.InstanceOf<FileNotFoundException>().With.Message.EqualTo("Coins.xml"));
        }

        [Test]
        public void DifferentiateAgainstDifferentFilesWithSimilarFilenameEndings()
        {
            var table = LoadStreamOf("SpellTypes.xml");

            for (var i = 1; i <= 70; i++)
                Assert.That(table[i], Is.EqualTo("Arcane"));

            for (var i = 71; i <= 100; i++)
                Assert.That(table[i], Is.EqualTo("Divine"));

            table = LoadStreamOf("CastersShieldSpellTypes.xml");

            for (var i = 1; i <= 80; i++)
                Assert.That(table[i], Is.EqualTo("Divine"));

            for (var i = 81; i <= 100; i++)
                Assert.That(table[i], Is.EqualTo("Arcane"));
        }
    }
}