using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class WondrousItemConstantsTests
    {
        [TestCase(WondrousItemConstants.AmuletOfHealth, "Amulet of Health")]
        [TestCase(WondrousItemConstants.AmuletOfMightyFists, "Amulet of Mighty Fists")]
        [TestCase(WondrousItemConstants.AmuletOfNaturalArmor, "Amulet of Natural Armor")]
        [TestCase(WondrousItemConstants.AmuletOfProofAgainstDetectionAndLocation, "Amulet of Proof Against Detection and Location")]
        [TestCase(WondrousItemConstants.AmuletOfThePlanes, "Amulet of the Planes")]
        [TestCase(WondrousItemConstants.ApparatusOfKwalish, "Apparatus of Kwalish")]
        [TestCase(WondrousItemConstants.BagOfHolding_I, "Bag of Holding Type I")]
        [TestCase(WondrousItemConstants.BagOfHolding_II, "Bag of Holding Type II")]
        [TestCase(WondrousItemConstants.BagOfHolding_III, "Bag of Holding Type III")]
        [TestCase(WondrousItemConstants.BagOfHolding_IV, "Bag of Holding Type IV")]
        [TestCase(WondrousItemConstants.BagOfTricks_Gray, "Gray Bag of Tricks")]
        [TestCase(WondrousItemConstants.BagOfTricks_Rust, "Rust Bag of Tricks")]
        [TestCase(WondrousItemConstants.BagOfTricks_Tan, "Tan Bag of Tricks")]
        [TestCase(WondrousItemConstants.BeadOfForce, "Bead of Force")]
        [TestCase(WondrousItemConstants.BeltOfDwarvenkind, "Belt of Dwarvenkind")]
        [TestCase(WondrousItemConstants.BeltOfGiantStrength, "Belt of Giant Strength")]
        [TestCase(WondrousItemConstants.BoccobsBlessedBook, "Boccob's Blessed Book")]
        [TestCase(WondrousItemConstants.BootsOfElvenkind, "Boots of Elvenkind")]
        [TestCase(WondrousItemConstants.BootsOfLevitation, "Boots of Levitation")]
        [TestCase(WondrousItemConstants.BootsOfSpeed, "Boots of Speed")]
        [TestCase(WondrousItemConstants.BootsOfStridingAndSpringing, "Boots of Striding and Springing")]
        [TestCase(WondrousItemConstants.BootsOfTeleportation, "Boots of Teleportation")]
        [TestCase(WondrousItemConstants.BootsOfTheWinterlands, "Boots of the Winterlands")]
        [TestCase(WondrousItemConstants.BottleOfAir, "Bottle of Air")]
        [TestCase(WondrousItemConstants.BowlOfCommandingWaterElementals, "Bowl of Commanding Water Elementals")]
        [TestCase(WondrousItemConstants.BraceletOfFriends, "Bracelet of Friends")]
        [TestCase(WondrousItemConstants.BracersOfArchery_Greater, "Greater Bracers of Archery")]
        [TestCase(WondrousItemConstants.BracersOfArchery_Lesser, "Lesser Bracers of Archery")]
        [TestCase(WondrousItemConstants.BracersOfArmor, "Bracers of Armor")]
        [TestCase(WondrousItemConstants.BrazierOfCommandingFireElementals, "Brazier of Commanding Fire Elementals")]
        [TestCase(WondrousItemConstants.BroochOfShielding, "Brooch of Shielding")]
        [TestCase(WondrousItemConstants.BroomOfFlying, "Broom of Flying")]
        [TestCase(WondrousItemConstants.CandleOfInvocation, "Candle of Invocation")]
        [TestCase(WondrousItemConstants.CandleOfTruth, "Candle of Truth")]
        [TestCase(WondrousItemConstants.CapeOfTheMountebank, "Cape of the Mountebank")]
        [TestCase(WondrousItemConstants.CarpetOfFlying_5x5, "5 ft. by 5 ft. Carpet of Flying")]
        [TestCase(WondrousItemConstants.CarpetOfFlying_5x10, "5 ft. by 10 ft. Carpet of Flying")]
        [TestCase(WondrousItemConstants.CarpetOfFlying_6x9, "6 ft. by 9 ft. Carpet of Flying")]
        [TestCase(WondrousItemConstants.CarpetOfFlying_10x10, "10 ft. by 10 ft. Carpet of Flying")]
        [TestCase(WondrousItemConstants.CenserOfControllingAirElementals, "Censer of Controlling Air Elementals")]
        [TestCase(WondrousItemConstants.ChaosDiamond, "Chaos Diamond")]
        [TestCase(WondrousItemConstants.ChimeOfInterruption, "Chime of Interruption")]
        [TestCase(WondrousItemConstants.ChimeOfOpening, "Chime of Opening")]
        [TestCase(WondrousItemConstants.CircletOfBlasting_Major, "Major Circlet of Blasting")]
        [TestCase(WondrousItemConstants.CircletOfBlasting_Minor, "Minor Circlet of Blasting")]
        [TestCase(WondrousItemConstants.CircletOfPersuasion, "Circlet of Persuasion")]
        [TestCase(WondrousItemConstants.CloakOfArachnida, "Cloak of Arachnida")]
        [TestCase(WondrousItemConstants.CloakOfCharisma, "Cloak of Charisma")]
        [TestCase(WondrousItemConstants.CloakOfDisplacement_Major, "Major Cloak of Displacement")]
        [TestCase(WondrousItemConstants.CloakOfDisplacement_Minor, "Minor Cloak of Displacement")]
        [TestCase(WondrousItemConstants.CloakOfElvenkind, "Cloak of Elvenkind")]
        [TestCase(WondrousItemConstants.CloakOfEtherealness, "Cloak of Etherealness")]
        [TestCase(WondrousItemConstants.CloakOfResistance, "Cloak of Resistance")]
        [TestCase(WondrousItemConstants.CloakOfTheBat, "Cloak of the Bat")]
        [TestCase(WondrousItemConstants.CloakOfTheMantaRay, "Cloak of the Manta Ray")]
        [TestCase(WondrousItemConstants.CrystalBall, "Crystal Ball")]
        [TestCase(WondrousItemConstants.CrystalBall_DetectThoughts, "Crystal Ball with Detect Thoughts")]
        [TestCase(WondrousItemConstants.CrystalBall_SeeInvisibility, "Crystal Ball with See Invisibility")]
        [TestCase(WondrousItemConstants.CrystalBall_Telepathy, "Crystal Ball with Telepathy")]
        [TestCase(WondrousItemConstants.CrystalBall_TrueSeeing, "Crystal Ball with True Seeing")]
        [TestCase(WondrousItemConstants.CubeOfFrostResistance, "Cube of Frost Resistance")]
        [TestCase(WondrousItemConstants.CubeOfForce, "Cube of Force")]
        [TestCase(WondrousItemConstants.CubicGate, "Cubic Gate")]
        [TestCase(WondrousItemConstants.DaernsInstantFortress, "Daern's Instant Fortress")]
        [TestCase(WondrousItemConstants.Darkskull, "Darkskull")]
        [TestCase(WondrousItemConstants.DecanterOfEndlessWater, "Decanter of Endless Water")]
        [TestCase(WondrousItemConstants.DeckOfIllusions, "Deck of Illusions")]
        [TestCase(WondrousItemConstants.DeckOfIllusions_Full, "Deck of Illusions (max)")]
        [TestCase(WondrousItemConstants.DimensionalShackles, "Dimensional Shackles")]
        [TestCase(WondrousItemConstants.DruidsVestments, "Druid's Vestments")]
        [TestCase(WondrousItemConstants.DrumsOfPanic, "Drums of Panic")]
        [TestCase(WondrousItemConstants.DustOfAppearance, "Dust of Appearance")]
        [TestCase(WondrousItemConstants.DustOfDisappearance, "Dust of Disappearance")]
        [TestCase(WondrousItemConstants.DustOfDryness, "Dust of Dryness")]
        [TestCase(WondrousItemConstants.DustOfIllusion, "Dust of Illusion")]
        [TestCase(WondrousItemConstants.DustOfTracelessness, "Dust of Tracelessness")]
        [TestCase(WondrousItemConstants.EfreetiBottle, "Efreeti Bottle")]
        [TestCase(WondrousItemConstants.ElementalGem, "Elemental Gem")]
        [TestCase(WondrousItemConstants.ElixerOfFireBreath, "Elixer of Fire Breath")]
        [TestCase(WondrousItemConstants.ElixerOfHiding, "Elixer of Hiding")]
        [TestCase(WondrousItemConstants.ElixerOfLove, "Elixer of Love")]
        [TestCase(WondrousItemConstants.ElixerOfSneaking, "Elixer of Sneaking")]
        [TestCase(WondrousItemConstants.ElixerOfSwimming, "Elixer of Swimming")]
        [TestCase(WondrousItemConstants.ElixerOfTruth, "Elixer of Truth")]
        [TestCase(WondrousItemConstants.ElixerOfVision, "Elixer of Vision")]
        [TestCase(WondrousItemConstants.EversmokingBottle, "Eversmoking Bottle")]
        [TestCase(WondrousItemConstants.EyesOfCharming, "Eyes of Charming")]
        [TestCase(WondrousItemConstants.EyesOfDoom, "Eyes of Doom")]
        [TestCase(WondrousItemConstants.EyesOfPetrification, "Eyes of Petrification")]
        [TestCase(WondrousItemConstants.EyesOfTheEagle, "Eyes of the Eagle")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_BronzeGriffon, "Bronze Griffon Figurine of Wondrous Power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_EbonyFly, "Ebony Fly Figurine of Wondrous Power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_GoldenLions, "Golden Lions Figurine of Wondrous Power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_IvoryGoats, "Ivory Goats Figurine of Wondrous Power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_MarbleElephant, "Marble Elephant Figurine of Wondrous Power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_ObsidianSteed, "Obsidian Steed Figurine of Wondrous Power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_OnyxDog, "Onyx Dog Figurine of Wondrous Power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_SerpentineOwl, "Serpentine Owl Figurine of Wondrous Power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_SilverRaven, "Silver Raven Figurine of Wondrous Power")]
        [TestCase(WondrousItemConstants.FoldingBoat, "Folding Boat")]
        [TestCase(WondrousItemConstants.GauntletOfRust, "Gauntlet of Rust")]
        [TestCase(WondrousItemConstants.GauntletsOfOgrePower, "Gauntlets of Ogre Power")]
        [TestCase(WondrousItemConstants.GemOfBrightness, "Gem of Brightness")]
        [TestCase(WondrousItemConstants.GemOfSeeing, "Gem of Seeing")]
        [TestCase(WondrousItemConstants.GloveOfStoring, "Glove of Storing")]
        [TestCase(WondrousItemConstants.GlovesOfArrowSnaring, "Gloves of Arrow Snaring")]
        [TestCase(WondrousItemConstants.GlovesOfDexterity, "Gloves of Dexterity")]
        [TestCase(WondrousItemConstants.GlovesOfSwimmingAndClimbing, "Gloves of Swimming and Climbing")]
        [TestCase(WondrousItemConstants.GogglesOfMinuteSeeing, "Goggles of Minute Seeing")]
        [TestCase(WondrousItemConstants.GogglesOfNight, "Goggles of Night")]
        [TestCase(WondrousItemConstants.GolembaneScarab, "Golembane Scarab")]
        [TestCase(WondrousItemConstants.GolemManual_Clay, "Clay Golem Manual")]
        [TestCase(WondrousItemConstants.GolemManual_Flesh, "Flesh Golem Manual")]
        [TestCase(WondrousItemConstants.GolemManual_Stone_Greater, "Greater Stone Golem Manual")]
        [TestCase(WondrousItemConstants.GolemManual_Iron, "Iron Golem Manual")]
        [TestCase(WondrousItemConstants.GolemManual_Stone, "Stone Golem Manual")]
        [TestCase(WondrousItemConstants.HandOfGlory, "Hand of Glory")]
        [TestCase(WondrousItemConstants.HandOfTheMage, "Hand of the Mage")]
        [TestCase(WondrousItemConstants.HarpOfCharming, "Harp of Charming")]
        [TestCase(WondrousItemConstants.HatOfDisguise, "Hat of Disguise")]
        [TestCase(WondrousItemConstants.HeadbandOfIntellect, "Headband of Intellect")]
        [TestCase(WondrousItemConstants.HelmOfBrilliance, "Helm of Brilliance")]
        [TestCase(WondrousItemConstants.HelmOfComprehendLanguagesAndReadMagic, "Helm of Comprehend Languages and Read Magic")]
        [TestCase(WondrousItemConstants.HelmOfTelepathy, "Helm of Telepathy")]
        [TestCase(WondrousItemConstants.HelmOfTeleportation, "Helm of Teleportation")]
        [TestCase(WondrousItemConstants.HelmOfUnderwaterAction, "Helm of Underwater Action")]
        [TestCase(WondrousItemConstants.HewardsHandyHaversack, "Heward's Handy Haversack")]
        [TestCase(WondrousItemConstants.HornOfBlasting, "Horn of Blasting")]
        [TestCase(WondrousItemConstants.HornOfBlasting_Greater, "Greater Horn of Blasting")]
        [TestCase(WondrousItemConstants.HornOfFog, "Horn of Fog")]
        [TestCase(WondrousItemConstants.HornOfGoodnessEvil, "Horn of Goodness/Evil")]
        [TestCase(WondrousItemConstants.HornOfTheTritons, "Horn of the Tritons")]
        [TestCase(WondrousItemConstants.HornOfValhalla, "Horn of Valhalla")]
        [TestCase(WondrousItemConstants.HorseshoesOfAZephyr, "Horseshoes of a Zephyr")]
        [TestCase(WondrousItemConstants.HorseshoesOfSpeed, "Horseshoes of Speed")]
        [TestCase(WondrousItemConstants.IncenseOfMeditation, "Incense of Meditation")]
        [TestCase(WondrousItemConstants.IounStone_ClearSpindle, "Clear Spindle Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_DarkBlueRhomboid, "Dark Blue Rhomboid Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_DeepRedSphere, "Deep Red Sphere Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_DustyRosePrism, "Dusty Rose Prism Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_IncandescentBlueSphere, "Incandescent Blue Sphere Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_IridescentSpindle, "Iridescent Spindle Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_LavenderAndGreenEllipsoid, "Lavender and Green Ellipsoid Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_OrangePrism, "Orange Prism Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_PaleBlueRhomboid, "Pale Blue Rhomboid Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_PaleGreenPrism, "Pale Green Prism Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_PaleLavenderEllipsoid, "Pale Lavender Ellipsoid Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_PearlyWhiteSpindle, "Pearly White Spindle Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_PinkAndGreenSphere, "Pink and Green Sphere Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_PinkRhomboid, "Pink Rhomboid Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_ScarletAndBlueSphere, "Scarlet and Blue Sphere Ioun Stone")]
        [TestCase(WondrousItemConstants.IounStone_VibrantPurplePrism, "Vibrant Purple Prism Ioun Stone")]
        [TestCase(WondrousItemConstants.IronBandsOfBilarro, "Iron Bands of Bilarro")]
        [TestCase(WondrousItemConstants.IronFlask, "Iron Flask")]
        [TestCase(WondrousItemConstants.KeoghtomsOintment, "Keoghtom's Ointment")]
        [TestCase(WondrousItemConstants.LanternOfRevealing, "Lantern of Revealing")]
        [TestCase(WondrousItemConstants.LensOfDetection, "Lens of Detection")]
        [TestCase(WondrousItemConstants.LyreOfBuilding, "Lyre of Building")]
        [TestCase(WondrousItemConstants.MantleOfFaith, "Mantle of Faith")]
        [TestCase(WondrousItemConstants.MantleOfSpellResistance, "Mantle of Spell Resistance")]
        [TestCase(WondrousItemConstants.ManualOfBodilyHealth, "Manual of Bodily Health")]
        [TestCase(WondrousItemConstants.ManualOfGainfulExercise, "Manual of Gainful Exercise")]
        [TestCase(WondrousItemConstants.ManualOfQuicknessInAction, "Manual of Quickness in Action")]
        [TestCase(WondrousItemConstants.MaskOfTheSkull, "Mask of the Skull")]
        [TestCase(WondrousItemConstants.MattockOfTheTitans, "Mattock of the Titans")]
        [TestCase(WondrousItemConstants.MaulOfTheTitans, "Maul of the Titans")]
        [TestCase(WondrousItemConstants.MedallionOfThoughts, "Medallion of Thoughts")]
        [TestCase(WondrousItemConstants.MirrorOfLifeTrapping, "Mirror of Life Trapping")]
        [TestCase(WondrousItemConstants.MirrorOfMentalProwess, "Mirror of Mental Prowess")]
        [TestCase(WondrousItemConstants.MirrorOfOpposition, "Mirror of Opposition")]
        [TestCase(WondrousItemConstants.MonksBelt, "Monk's Belt")]
        [TestCase(WondrousItemConstants.MurlyndsSpoon, "Murlynd's Spoon")]
        [TestCase(WondrousItemConstants.NecklaceOfAdaptation, "Necklace of Adaptation")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs, "Necklace of Fireballs")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_I, "Necklace of Fireballs Type I")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_II, "Necklace of Fireballs Type II")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_III, "Necklace of Fireballs Type III")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_IV, "Necklace of Fireballs Type IV")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_V, "Necklace of Fireballs Type V")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_VI, "Necklace of Fireballs Type VI")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_VII, "Necklace of Fireballs Type VII")]
        [TestCase(WondrousItemConstants.NolzursMarvelousPigments, "Nolzur's Marvelous Pigments")]
        [TestCase(WondrousItemConstants.OrbOfStorms, "Orb of Storms")]
        [TestCase(WondrousItemConstants.PearlOfPower_1stLevel, "1st-level Spell Pearl of Power")]
        [TestCase(WondrousItemConstants.PearlOfPower_2ndLevel, "2nd-level Spell Pearl of Power")]
        [TestCase(WondrousItemConstants.PearlOfPower_3rdLevel, "3rd-level Spell Pearl of Power")]
        [TestCase(WondrousItemConstants.PearlOfPower_4thLevel, "4th-level Spell Pearl of Power")]
        [TestCase(WondrousItemConstants.PearlOfPower_5thLevel, "5th-level Spell Pearl of Power")]
        [TestCase(WondrousItemConstants.PearlOfPower_6thLevel, "6th-level Spell Pearl of Power")]
        [TestCase(WondrousItemConstants.PearlOfPower_7thLevel, "7th-level Spell Pearl of Power")]
        [TestCase(WondrousItemConstants.PearlOfPower_8thLevel, "8th-level Spell Pearl of Power")]
        [TestCase(WondrousItemConstants.PearlOfPower_9thLevel, "9th-level Spell Pearl of Power")]
        [TestCase(WondrousItemConstants.PearlOfPower_TwoSpells, "Two Spells Pearl of Power")]
        [TestCase(WondrousItemConstants.PearlOfTheSirines, "Pearl of the Sirines")]
        [TestCase(WondrousItemConstants.PeriaptOfHealth, "Periapt of Health")]
        [TestCase(WondrousItemConstants.PeriaptOfProofAgainstPoison, "Periapt of Proof Against Poison")]
        [TestCase(WondrousItemConstants.PeriaptOfWisdom, "Periapt of Wisdom")]
        [TestCase(WondrousItemConstants.PeriaptOfWoundClosure, "Periapt of Wound-Closure")]
        [TestCase(WondrousItemConstants.PhylacteryOfFaithfulness, "Phylactery of Faithfulness")]
        [TestCase(WondrousItemConstants.PhylacteryOfUndeadTurning, "Phylactery of Undead Turning")]
        [TestCase(WondrousItemConstants.PipesOfHaunting, "Pipes of Haunting")]
        [TestCase(WondrousItemConstants.PipesOfPain, "Pipes of Pain")]
        [TestCase(WondrousItemConstants.PipesOfSounding, "Pipes of Sounding")]
        [TestCase(WondrousItemConstants.PipesOfTheSewers, "Pipes of the Sewers")]
        [TestCase(WondrousItemConstants.PortableHole, "Portable Hole")]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Anchor, "Quaal's Anchor Feather Token")]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Bird, "Quaal's Bird Feather Token")]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Fan, "Quaal's Fan Feather Token")]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_SwanBoat, "Quaal's Swan Boat Feather Token")]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Tree, "Quaal's Tree Feather Token")]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Whip, "Quaal's Whip Feather Token")]
        [TestCase(WondrousItemConstants.QuiverOfEhlonna, "Quiver of Ehlonna")]
        [TestCase(WondrousItemConstants.RingGates, "Ring Gates")]
        [TestCase(WondrousItemConstants.RobeOfBlending, "Robe of Blending")]
        [TestCase(WondrousItemConstants.RobeOfBones, "Robe of Bones")]
        [TestCase(WondrousItemConstants.RobeOfEyes, "Robe of Eyes")]
        [TestCase(WondrousItemConstants.RobeOfScintillatingColors, "Robe of Scintillating Colors")]
        [TestCase(WondrousItemConstants.RobeOfStars, "Robe of Stars")]
        [TestCase(WondrousItemConstants.RobeOfTheArchmagi, "Robe of the Archmagi")]
        [TestCase(WondrousItemConstants.RobeOfUsefulItems, "Robe of Useful Items")]
        [TestCase(WondrousItemConstants.RopeOfClimbing, "Rope of Climbing")]
        [TestCase(WondrousItemConstants.RopeOfEntanglement, "Rope of Entanglement")]
        [TestCase(WondrousItemConstants.SalveOfSlipperiness, "Salve of Slipperiness")]
        [TestCase(WondrousItemConstants.ScabbardOfKeenEdges, "Scabbard of Keen Edges")]
        [TestCase(WondrousItemConstants.ScarabOfProtection, "Scarab of Protection")]
        [TestCase(WondrousItemConstants.Silversheen, "Silversheen")]
        [TestCase(WondrousItemConstants.SlippersOfSpiderClimbing, "Slippers of Spider Climbing")]
        [TestCase(WondrousItemConstants.SovereignGlue, "Sovereign Glue")]
        [TestCase(WondrousItemConstants.StoneHorse_Courser, "Courser Stone Horse")]
        [TestCase(WondrousItemConstants.StoneHorse_Destrier, "Destrier Stone Horse")]
        [TestCase(WondrousItemConstants.StoneOfAlarm, "Stone of Alarm")]
        [TestCase(WondrousItemConstants.StoneOfControllingEarthElementals, "Stone of Controlling Earth Elementals")]
        [TestCase(WondrousItemConstants.StoneOfGoodLuck_Luckstone, "Stone of Good Luck (Luckstone)")]
        [TestCase(WondrousItemConstants.StoneSalve, "Stone Salve")]
        [TestCase(WondrousItemConstants.StrandOfPrayerBeads, "Strand of Prayer Beads")]
        [TestCase(WondrousItemConstants.StrandOfPrayerBeads_Lesser, "Lesser Strand of Prayer Beads")]
        [TestCase(WondrousItemConstants.StrandOfPrayerBeads_Greater, "Greater Strand of Prayer Beads")]
        [TestCase(WondrousItemConstants.TalismanOfTheSphere, "Talisman of the Sphere")]
        [TestCase(WondrousItemConstants.TomeOfClearThought, "Tome of Clear Thought")]
        [TestCase(WondrousItemConstants.TomeOfLeadershipAndInfluence, "Tome of Leadership and Influence")]
        [TestCase(WondrousItemConstants.TomeOfUnderstanding, "Tome of Understanding")]
        [TestCase(WondrousItemConstants.UnguentOfTimelessness, "Unguent of Timelessness")]
        [TestCase(WondrousItemConstants.UniversalSolvent, "Universal Solvent")]
        [TestCase(WondrousItemConstants.VestOfEscape, "Vest of Escape")]
        [TestCase(WondrousItemConstants.WellOfManyWorlds, "Well of Many Worlds")]
        [TestCase(WondrousItemConstants.WindFan, "Wind Fan")]
        [TestCase(WondrousItemConstants.WingedBoots, "Winged Boots")]
        [TestCase(WondrousItemConstants.WingsOfFlying, "Wings of Flying")]
        [TestCase(WondrousItemConstants.IncenseOfObsession, "Incense of Obsession")]
        [TestCase(WondrousItemConstants.AmuletOfInescapableLocation, "Amulet of Inescapable Location")]
        [TestCase(WondrousItemConstants.StoneOfWeight_Loadstone, "Stone of Weight (Loadstone)")]
        [TestCase(WondrousItemConstants.BracersOfDefenselessness, "Bracers of Defenselessness")]
        [TestCase(WondrousItemConstants.GauntletsOfFumbling, "Gauntlets of Fumbling")]
        [TestCase(WondrousItemConstants.MedallionOfThoughtProjection, "Medallion of Thought Projection")]
        [TestCase(WondrousItemConstants.FlaskOfCurses, "Flask of Curses")]
        [TestCase(WondrousItemConstants.DustOfSneezingAndChoking, "Dust of Sneezing and Choking")]
        [TestCase(WondrousItemConstants.RobeOfPowerlessness, "Robe of Powerlessness")]
        [TestCase(WondrousItemConstants.BagOfDevouring, "Bag of Devouring")]
        [TestCase(WondrousItemConstants.RobeOfVermin, "Robe of Vermin")]
        [TestCase(WondrousItemConstants.PeriaptOfFoulRotting, "Periapt of Foul Rotting")]
        [TestCase(WondrousItemConstants.BootsOfDancing, "Boots of Dancing")]
        [TestCase(WondrousItemConstants.HelmOfOppositeAlignment, "Helm of Opposite Alignment")]
        [TestCase(WondrousItemConstants.BroomOfAnimatedAttack, "Broom of Animated Attack")]
        [TestCase(WondrousItemConstants.VacousGrimoire, "Vacuous Grimoire")]
        [TestCase(WondrousItemConstants.CrystalBall_Hypnosis, "Crystal Hypnosis Ball")]
        [TestCase(WondrousItemConstants.NecklaceOfStrangulation, "Necklace of Strangulation")]
        [TestCase(WondrousItemConstants.CloakOfPoisonousness, "Cloak of Poisonousness")]
        [TestCase(WondrousItemConstants.ScarabOfDeath, "Scarab of Death")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllWondrousItems()
        {
            var wondrousItems = WondrousItemConstants.GetAllWondrousItems();

            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.AmuletOfHealth));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.AmuletOfMightyFists));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.AmuletOfNaturalArmor));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.AmuletOfProofAgainstDetectionAndLocation));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.AmuletOfThePlanes));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ApparatusOfKwalish));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BagOfHolding_I));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BagOfHolding_II));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BagOfHolding_III));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BagOfHolding_IV));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BagOfTricks_Gray));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BagOfTricks_Rust));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BagOfTricks_Tan));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BeadOfForce));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BeltOfDwarvenkind));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BeltOfGiantStrength));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BoccobsBlessedBook));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BootsOfElvenkind));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BootsOfLevitation));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BootsOfSpeed));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BootsOfStridingAndSpringing));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BootsOfTeleportation));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BootsOfTheWinterlands));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BottleOfAir));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BowlOfCommandingWaterElementals));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BraceletOfFriends));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BracersOfArchery_Greater));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BracersOfArchery_Lesser));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BracersOfArmor));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BrazierOfCommandingFireElementals));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BroochOfShielding));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.BroomOfFlying));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CandleOfInvocation));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CandleOfTruth));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CapeOfTheMountebank));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CarpetOfFlying_10x10));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CarpetOfFlying_5x10));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CarpetOfFlying_5x5));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CarpetOfFlying_6x9));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CenserOfControllingAirElementals));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ChaosDiamond));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ChimeOfInterruption));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ChimeOfOpening));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CircletOfBlasting_Major));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CircletOfBlasting_Minor));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CircletOfPersuasion));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CloakOfArachnida));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CloakOfCharisma));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CloakOfDisplacement_Major));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CloakOfDisplacement_Minor));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CloakOfElvenkind));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CloakOfEtherealness));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CloakOfResistance));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CloakOfTheBat));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CloakOfTheMantaRay));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CrystalBall));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CrystalBall_DetectThoughts));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CrystalBall_Telepathy));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CrystalBall_SeeInvisibility));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CrystalBall_TrueSeeing));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CubeOfForce));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CubeOfFrostResistance));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.CubicGate));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.DaernsInstantFortress));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.Darkskull));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.DeckOfIllusions));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.DecanterOfEndlessWater));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.DimensionalShackles));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.DruidsVestments));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.DrumsOfPanic));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.DustOfAppearance));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.DustOfDisappearance));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.DustOfDryness));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.DustOfIllusion));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.DustOfTracelessness));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.EfreetiBottle));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ElementalGem));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ElixerOfFireBreath));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ElixerOfHiding));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ElixerOfLove));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ElixerOfSwimming));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ElixerOfSneaking));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ElixerOfTruth));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ElixerOfVision));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.EversmokingBottle));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.EyesOfCharming));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.EyesOfDoom));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.EyesOfPetrification));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.EyesOfTheEagle));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.FigurineOfWondrousPower_BronzeGriffon));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.FigurineOfWondrousPower_EbonyFly));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.FigurineOfWondrousPower_GoldenLions));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.FigurineOfWondrousPower_IvoryGoats));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.FigurineOfWondrousPower_MarbleElephant));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.FigurineOfWondrousPower_ObsidianSteed));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.FigurineOfWondrousPower_OnyxDog));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.FigurineOfWondrousPower_SerpentineOwl));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.FigurineOfWondrousPower_SilverRaven));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.FoldingBoat));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GauntletOfRust));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GauntletsOfOgrePower));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GemOfBrightness));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GemOfSeeing));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GloveOfStoring));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GlovesOfArrowSnaring));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GlovesOfDexterity));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GlovesOfSwimmingAndClimbing));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GogglesOfMinuteSeeing));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GogglesOfNight));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GolembaneScarab));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GolemManual_Clay));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GolemManual_Flesh));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GolemManual_Iron));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GolemManual_Stone));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.GolemManual_Stone_Greater));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HandOfGlory));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HandOfTheMage));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HarpOfCharming));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HatOfDisguise));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HelmOfBrilliance));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HeadbandOfIntellect));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HelmOfComprehendLanguagesAndReadMagic));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HelmOfTelepathy));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HelmOfTeleportation));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HelmOfUnderwaterAction));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HewardsHandyHaversack));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HornOfBlasting));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HornOfBlasting_Greater));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HornOfFog));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HornOfGoodnessEvil));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HornOfTheTritons));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HornOfValhalla));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HorseshoesOfAZephyr));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.HorseshoesOfSpeed));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IncenseOfMeditation));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_ClearSpindle));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_DarkBlueRhomboid));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_DeepRedSphere));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_DustyRosePrism));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_IncandescentBlueSphere));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_IridescentSpindle));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_LavenderAndGreenEllipsoid));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_OrangePrism));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_PaleBlueRhomboid));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_PaleGreenPrism));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_PaleLavenderEllipsoid));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_PearlyWhiteSpindle));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_PinkAndGreenSphere));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_PinkRhomboid));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_ScarletAndBlueSphere));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IounStone_VibrantPurplePrism));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IronBandsOfBilarro));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.IronFlask));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.KeoghtomsOintment));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.LanternOfRevealing));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.LensOfDetection));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.LyreOfBuilding));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.MantleOfFaith));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.MantleOfSpellResistance));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ManualOfBodilyHealth));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ManualOfGainfulExercise));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ManualOfQuicknessInAction));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.MaskOfTheSkull));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.MattockOfTheTitans));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.MaulOfTheTitans));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.MedallionOfThoughts));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.MirrorOfLifeTrapping));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.MirrorOfMentalProwess));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.MirrorOfOpposition));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.MonksBelt));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.MurlyndsSpoon));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.NecklaceOfAdaptation));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.NecklaceOfFireballs_I));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.NecklaceOfFireballs_II));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.NecklaceOfFireballs_III));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.NecklaceOfFireballs_IV));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.NecklaceOfFireballs_V));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.NecklaceOfFireballs_VI));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.NecklaceOfFireballs_VII));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.NolzursMarvelousPigments));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.OrbOfStorms));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PearlOfPower_1stLevel));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PearlOfPower_2ndLevel));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PearlOfPower_3rdLevel));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PearlOfPower_4thLevel));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PearlOfPower_5thLevel));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PearlOfPower_6thLevel));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PearlOfPower_7thLevel));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PearlOfPower_8thLevel));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PearlOfPower_9thLevel));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PearlOfPower_TwoSpells));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PearlOfTheSirines));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PeriaptOfHealth));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PeriaptOfProofAgainstPoison));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PeriaptOfWisdom));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PeriaptOfWoundClosure));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PhylacteryOfFaithfulness));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PhylacteryOfUndeadTurning));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PipesOfHaunting));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PipesOfPain));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PipesOfSounding));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PipesOfTheSewers));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.PortableHole));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.QuaalsFeatherToken_Anchor));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.QuaalsFeatherToken_Bird));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.QuaalsFeatherToken_Fan));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.QuaalsFeatherToken_SwanBoat));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.QuaalsFeatherToken_Tree));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.QuaalsFeatherToken_Whip));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.QuiverOfEhlonna));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.RingGates));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.RobeOfBlending));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.RobeOfBones));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.RobeOfEyes));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.RobeOfScintillatingColors));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.RobeOfStars));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.RobeOfTheArchmagi));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.RobeOfUsefulItems));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.RopeOfClimbing));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.RopeOfEntanglement));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.SalveOfSlipperiness));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ScabbardOfKeenEdges));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.ScarabOfProtection));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.Silversheen));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.SlippersOfSpiderClimbing));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.SovereignGlue));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.StoneHorse_Courser));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.StoneHorse_Destrier));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.StoneOfAlarm));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.StoneOfControllingEarthElementals));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.StoneOfGoodLuck_Luckstone));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.StoneSalve));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.StrandOfPrayerBeads));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.StrandOfPrayerBeads_Greater));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.StrandOfPrayerBeads_Lesser));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.TalismanOfTheSphere));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.TomeOfClearThought));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.TomeOfLeadershipAndInfluence));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.TomeOfUnderstanding));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.UnguentOfTimelessness));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.UniversalSolvent));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.VestOfEscape));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.WellOfManyWorlds));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.WindFan));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.WingedBoots));
            Assert.That(wondrousItems, Contains.Item(WondrousItemConstants.WingsOfFlying));

            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.AmuletOfInescapableLocation));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.BagOfDevouring));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.BracersOfDefenselessness));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.BroomOfAnimatedAttack));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.CloakOfPoisonousness));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.DustOfSneezingAndChoking));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.RobeOfVermin));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.CrystalBall_Hypnosis));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.ScarabOfDeath));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.NecklaceOfStrangulation));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.BootsOfDancing));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.StoneOfWeight_Loadstone));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.PeriaptOfFoulRotting));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.GauntletsOfFumbling));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.VacousGrimoire));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.MedallionOfThoughtProjection));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.HelmOfOppositeAlignment));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.IncenseOfObsession));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.RobeOfPowerlessness));
            Assert.That(wondrousItems, Is.All.Not.EqualTo(WondrousItemConstants.FlaskOfCurses));

            Assert.That(wondrousItems.Count(), Is.EqualTo(246));
        }
    }
}