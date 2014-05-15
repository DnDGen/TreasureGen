using System;
using System.Linq;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class WondrousItemContentsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "WondrousItemContents"; }
        }

        [TestCase("Robe of useful items", WeaponConstants.Dagger,
                                          WeaponConstants.Dagger,
                                          "Bullseye lantern (filled and lit)",
                                          "Bullseye lantern (filled and lit)",
                                          "Highly polished 2-foot-by-4-foot steel mirror",
                                          "Highly polished 2-foot-by-4-foot steel mirror",
                                          "10-foot pole",
                                          "10-foot pole",
                                          "50-foot hempen rope",
                                          "50-foot hempen rope",
                                          "Sack",
                                          "Sack")]
        [TestCase("Robe of bones", "Small goblin skeleton",
                                   "Small goblin skeleton",
                                   "Medium human commoner skeleton",
                                   "Medium human commoner skeleton",
                                   "Medium wolf skeleton",
                                   "Medium wolf skeleton",
                                   "Small goblin combie",
                                   "Small goblin combie",
                                   "Medium human commoner zombie",
                                   "Medium human commoner zombie",
                                   "Medium wolf zombie",
                                   "Medium wolf zombie")]
        [TestCase("Necklace of fireballs type I", "3d6",
                                                  "3d6",
                                                  "5d6")]
        [TestCase("Necklace of fireballs type II", "2d6",
                                                   "2d6",
                                                   "4d6",
                                                   "4d6",
                                                   "6d6")]
        [TestCase("Necklace of fireballs type III", "3d6",
                                                    "3d6",
                                                    "3d6",
                                                    "3d6",
                                                    "5d6",
                                                    "5d6",
                                                    "7d6")]
        [TestCase("Necklace of fireballs type IV", "2d6",
                                                   "2d6",
                                                   "2d6",
                                                   "2d6",
                                                   "4d6",
                                                   "4d6",
                                                   "6d6",
                                                   "6d6",
                                                   "8d6")]
        [TestCase("Necklace of fireballs type V", "3d6",
                                                  "3d6",
                                                  "5d6",
                                                  "5d6",
                                                  "7d6",
                                                  "7d6",
                                                  "9d6")]
        [TestCase("Necklace of fireballs type VI", "4d6",
                                                   "4d6",
                                                   "4d6",
                                                   "4d6",
                                                   "6d6",
                                                   "6d6",
                                                   "8d6",
                                                   "8d6",
                                                   "10d6")]
        [TestCase("Necklace of fireballs type VII", "3d6",
                                                    "3d6",
                                                    "5d6",
                                                    "5d6",
                                                    "7d6",
                                                    "7d6",
                                                    "9d6",
                                                    "9d6",
                                                    "10d6")]
        //HACK: Have to make this separate - too many attributes for NUnit to handle as test name
        //Also, can't let the submethod just be a test - the test asserting that all names are tested
        //won't register the Deck of illusions unless it is a test case for this method
        [TestCase("Deck of illusions")]
        public void Attributes(String name, params String[] attributes)
        {
            if (attributes.Any())
                AssertAttributes(name, attributes);
            else
                DeckOfIllusionsContents();
        }

        //HACK: have to make this separate - too many attributes for NUnit to handle as test name
        //[Test]
        public void DeckOfIllusionsContents()
        {
            var attributes = new[]
                {
                    "Ace of hearts",
                    "King of hearts",
                    "Queen of hearts",
                    "Jack of hearts",
                    "10 of hearts",
                    "9 of hearts",
                    "8 of hearts",
                    "2 of hearts",
                    "Ace of diamonds",
                    "King of diamonds",
                    "Queen of diamonds",
                    "Jack of diamonds",
                    "10 of diamonds",
                    "9 of diamonds",
                    "8 of diamonds",
                    "2 of diamonds",
                    "Ace of spades",
                    "King of spades",
                    "Queen of spades",
                    "Jack of spades",
                    "10 of spades",
                    "9 of spades",
                    "8 of spades",
                    "2 of spades",
                    "Ace of clubs",
                    "King of clubs",
                    "Queen of clubs",
                    "Jack of clubs",
                    "10 of clubs",
                    "9 of clubs",
                    "8 of clubs",
                    "2 of clubs",
                    "Joker",
                    "Joker"
                };

            AssertAttributes("Deck of illusions", attributes);
        }
    }
}