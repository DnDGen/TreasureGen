using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class WondrousItemConstantsTests
    {
        [TestCase(WondrousItemConstants.AmuletOfHealth, "Amulet of health")]
        [TestCase(WondrousItemConstants.AmuletOfMightyFists, "Amulet of mighty fists")]
        [TestCase(WondrousItemConstants.AmuletOfNaturalArmor, "Amulet of natural armor")]
        [TestCase(WondrousItemConstants.AmuletOfProofAgainstDetectionAndLocation, "Amulet of proof against detection and location")]
        [TestCase(WondrousItemConstants.AmuletOfThePlanes, "Amulet of the planes")]
        [TestCase(WondrousItemConstants.ApparatusOfKwalish, "Apparatus of Kwalish")]
        [TestCase(WondrousItemConstants.BagOfHolding_I, "Bag of holding type I")]
        [TestCase(WondrousItemConstants.BagOfHolding_II, "Bag of holding type II")]
        [TestCase(WondrousItemConstants.BagOfHolding_III, "Bag of holding type III")]
        [TestCase(WondrousItemConstants.BagOfHolding_IV, "Bag of holding type IV")]
        [TestCase(WondrousItemConstants.BagOfTricks_Gray, "Gray bag of tricks")]
        [TestCase(WondrousItemConstants.BagOfTricks_Rust, "Rust bag of tricks")]
        [TestCase(WondrousItemConstants.BagOfTricks_Tan, "Tan bag of tricks")]
        [TestCase(WondrousItemConstants.BeadOfForce, "Bead of force")]
        [TestCase(WondrousItemConstants.BeltOfDwarvenkind, "Belt of dwarvenkind")]
        [TestCase(WondrousItemConstants.BeltOfGiantStrength, "Belt of giant strength")]
        [TestCase(WondrousItemConstants.BoccobsBlessedBook, "Boccob's blessed book")]
        [TestCase(WondrousItemConstants.BootsOfElvenkind, "Boots of elvenkind")]
        [TestCase(WondrousItemConstants.BootsOfLevitation, "Boots of levitation")]
        [TestCase(WondrousItemConstants.BootsOfSpeed, "Boots of speed")]
        [TestCase(WondrousItemConstants.BootsOfStridingAndSpringing, "Boots of striding and springing")]
        [TestCase(WondrousItemConstants.BootsOfTeleportation, "Boots of teleportation")]
        [TestCase(WondrousItemConstants.BootsOfTheWinterlands, "Boots of the winterlands")]
        [TestCase(WondrousItemConstants.BottleOfAir, "Bottle of air")]
        [TestCase(WondrousItemConstants.BowlOfCommandingWaterElementals, "Bowl of commanding water elementals")]
        [TestCase(WondrousItemConstants.BraceletOfFriends, "Bracelet of friends")]
        [TestCase(WondrousItemConstants.BracersOfArchery_Greater, "Greater bracers of archery")]
        [TestCase(WondrousItemConstants.BracersOfArchery_Lesser, "Lesser bracers of archery")]
        [TestCase(WondrousItemConstants.BracersOfArmor, "Bracers of armor")]
        [TestCase(WondrousItemConstants.BrazierOfCommandingFireElementals, "Brazier of commanding fire elementals")]
        [TestCase(WondrousItemConstants.BroochOfShielding, "Brooch of shielding")]
        [TestCase(WondrousItemConstants.BroomOfFlying, "Broom of flying")]
        [TestCase(WondrousItemConstants.CandleOfInvocation, "Candle of invocation")]
        [TestCase(WondrousItemConstants.CandleOfTruth, "Candle of truth")]
        [TestCase(WondrousItemConstants.CapeOfTheMountebank, "Cape of the mountebank")]
        [TestCase(WondrousItemConstants.CarpetOfFlying_5x5, "5 ft. by 5 ft. carpet of flying")]
        [TestCase(WondrousItemConstants.CarpetOfFlying_5x10, "5 ft. by 10 ft. carpet of flying")]
        [TestCase(WondrousItemConstants.CarpetOfFlying_6x9, "6 ft. by 9 ft. carpet of flying")]
        [TestCase(WondrousItemConstants.CarpetOfFlying_10x10, "10 ft. by 10 ft. carpet of flying")]
        [TestCase(WondrousItemConstants.CenserOfControllingAirElementals, "Censer of controlling air elementals")]
        [TestCase(WondrousItemConstants.ChaosDiamond, "Chaos diamond")]
        [TestCase(WondrousItemConstants.ChimeOfInterruption, "Chime of interruption")]
        [TestCase(WondrousItemConstants.ChimeOfOpening, "Chime of opening")]
        [TestCase(WondrousItemConstants.CircletOfBlasting_Major, "Major circlet of blasting")]
        [TestCase(WondrousItemConstants.CircletOfBlasting_Minor, "Minor circlet of blasting")]
        [TestCase(WondrousItemConstants.CircletOfPersuasion, "Circlet of persuasion")]
        [TestCase(WondrousItemConstants.CloakOfArachnida, "Cloak of arachnida")]
        [TestCase(WondrousItemConstants.CloakOfCharisma, "Cloak of charisma")]
        [TestCase(WondrousItemConstants.CloakOfDisplacement_Major, "Major cloak of displacement")]
        [TestCase(WondrousItemConstants.CloakOfDisplacement_Minor, "Minor cloak of displacement")]
        [TestCase(WondrousItemConstants.CloakOfElvenkind, "Cloak of elvenkind")]
        [TestCase(WondrousItemConstants.CloakOfEtherealness, "Cloak of etherealness")]
        [TestCase(WondrousItemConstants.CloakOfResistance, "Cloak of resistance")]
        [TestCase(WondrousItemConstants.CloakOfTheBat, "Cloak of the bat")]
        [TestCase(WondrousItemConstants.CloakOfTheMantaRay, "Cloak of the manta ray")]
        [TestCase(WondrousItemConstants.CrystalBall, "Crystal ball")]
        [TestCase(WondrousItemConstants.CrystalBall_DetectThoughts, "Crystal ball with detect thoughts")]
        [TestCase(WondrousItemConstants.CrystalBall_SeeInvisibility, "Crystal ball with see invisibility")]
        [TestCase(WondrousItemConstants.CrystalBall_Telepathy, "Crystal ball with telepathy")]
        [TestCase(WondrousItemConstants.CrystalBall_TrueSeeing, "Crystal ball with true seeing")]
        [TestCase(WondrousItemConstants.CubeOfFrostResistance, "Cube of frost resistance")]
        [TestCase(WondrousItemConstants.CubeOfForce, "Cube of force")]
        [TestCase(WondrousItemConstants.CubicGate, "Cubic gate")]
        [TestCase(WondrousItemConstants.DaernsInstantFortress, "Daern's instant fortress")]
        [TestCase(WondrousItemConstants.Darkskull, "Darkskull")]
        [TestCase(WondrousItemConstants.DecanterOfEndlessWater, "Decanter of endless water")]
        [TestCase(WondrousItemConstants.DeckOfIllusions, "Deck of illusions")]
        [TestCase(WondrousItemConstants.DeckOfIllusions_Full, "Deck of illusions (max)")]
        [TestCase(WondrousItemConstants.DimensionalShackles, "Dimensional shackles")]
        [TestCase(WondrousItemConstants.DruidsVestments, "Druid's vestments")]
        [TestCase(WondrousItemConstants.DrumsOfPanic, "Drums of panic")]
        [TestCase(WondrousItemConstants.DustOfAppearance, "Dust of appearance")]
        [TestCase(WondrousItemConstants.DustOfDisappearance, "Dust of disappearance")]
        [TestCase(WondrousItemConstants.DustOfDryness, "Dust of dryness")]
        [TestCase(WondrousItemConstants.DustOfIllusion, "Dust of illusion")]
        [TestCase(WondrousItemConstants.DustOfTracelessness, "Dust of tracelessness")]
        [TestCase(WondrousItemConstants.EfreetiBottle, "Efreeti bottle")]
        [TestCase(WondrousItemConstants.ElementalGem, "Elemental gem")]
        [TestCase(WondrousItemConstants.ElixerOfFireBreath, "Elixer of fire breath")]
        [TestCase(WondrousItemConstants.ElixerOfHiding, "Elixer of hiding")]
        [TestCase(WondrousItemConstants.ElixerOfLove, "Elixer of love")]
        [TestCase(WondrousItemConstants.ElixerOfSneaking, "Elixer of sneaking")]
        [TestCase(WondrousItemConstants.ElixerOfSwimming, "Elixer of swimming")]
        [TestCase(WondrousItemConstants.ElixerOfTruth, "Elixer of truth")]
        [TestCase(WondrousItemConstants.ElixerOfVision, "Elixer of vision")]
        [TestCase(WondrousItemConstants.EversmokingBottle, "Eversmoking bottle")]
        [TestCase(WondrousItemConstants.EyesOfCharming, "Eyes of charming")]
        [TestCase(WondrousItemConstants.EyesOfDoom, "Eyes of doom")]
        [TestCase(WondrousItemConstants.EyesOfPetrification, "Eyes of petrification")]
        [TestCase(WondrousItemConstants.EyesOfTheEagle, "Eyes of the eagle")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_BronzeGriffon, "Bronze griffon figurine of wondrous power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_EbonyFly, "Ebony fly figurine of wondrous power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_GoldenLions, "Golden lions figurine of wondrous power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_IvoryGoats, "Ivory goats figurine of wondrous power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_MarbleElephant, "Marble elephant figurine of wondrous power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_ObsidianSteed, "Obsidian steed figurine of wondrous power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_OnyxDog, "Onyx dog figurine of wondrous power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_SerpentineOwl, "Serpentine owl figurine of wondrous power")]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_SilverRaven, "Silver raven figurine of wondrous power")]
        [TestCase(WondrousItemConstants.FoldingBoat, "Folding boat")]
        [TestCase(WondrousItemConstants.GauntletOfRust, "Gauntlet of rust")]
        [TestCase(WondrousItemConstants.GauntletsOfOgrePower, "Gauntlets of ogre power")]
        [TestCase(WondrousItemConstants.GemOfBrightness, "Gem of brightness")]
        [TestCase(WondrousItemConstants.GemOfSeeing, "Gem of seeing")]
        [TestCase(WondrousItemConstants.GloveOfStoring, "Glove of storing")]
        [TestCase(WondrousItemConstants.GlovesOfArrowSnaring, "Gloves of arrow snaring")]
        [TestCase(WondrousItemConstants.GlovesOfDexterity, "Gloves of dexterity")]
        [TestCase(WondrousItemConstants.GlovesOfSwimmingAndClimbing, "Gloves of swimming and climbing")]
        [TestCase(WondrousItemConstants.GogglesOfMinuteSeeing, "Goggles of minute seeing")]
        [TestCase(WondrousItemConstants.GogglesOfNight, "Goggles of night")]
        [TestCase(WondrousItemConstants.GolembaneScarab, "Golembane scarab")]
        [TestCase(WondrousItemConstants.GolemManual_Clay, "Clay golem manual")]
        [TestCase(WondrousItemConstants.GolemManual_Flesh, "Flesh golem manual")]
        [TestCase(WondrousItemConstants.GolemManual_Stone_Greater, "Greater stone golem manual")]
        [TestCase(WondrousItemConstants.GolemManual_Iron, "Iron golem manual")]
        [TestCase(WondrousItemConstants.GolemManual_Stone, "Stone golem manual")]
        [TestCase(WondrousItemConstants.HandOfGlory, "Hand of glory")]
        [TestCase(WondrousItemConstants.HandOfTheMage, "Hand of the mage")]
        [TestCase(WondrousItemConstants.HarpOfCharming, "Harp of charming")]
        [TestCase(WondrousItemConstants.HatOfDisguise, "Hat of disguise")]
        [TestCase(WondrousItemConstants.HeadbandOfIntellect, "Headband of intellect")]
        [TestCase(WondrousItemConstants.HelmOfBrilliance, "Helm of brilliance")]
        [TestCase(WondrousItemConstants.HelmOfComprehendLanguagesAndReadMagic, "Helm of comprehend languages and read magic")]
        [TestCase(WondrousItemConstants.HelmOfTelepathy, "Helm of telepathy")]
        [TestCase(WondrousItemConstants.HelmOfTeleportation, "Helm of teleportation")]
        [TestCase(WondrousItemConstants.HelmOfUnderwaterAction, "Helm of underwater action")]
        [TestCase(WondrousItemConstants.HewardsHandyHaversack, "Heward's handy haversack")]
        [TestCase(WondrousItemConstants.HornOfBlasting, "Horn of blasting")]
        [TestCase(WondrousItemConstants.HornOfBlasting_Greater, "Greater horn of blasting")]
        [TestCase(WondrousItemConstants.HornOfFog, "Horn of fog")]
        [TestCase(WondrousItemConstants.HornOfGoodnessEvil, "Horn of goodness/evil")]
        [TestCase(WondrousItemConstants.HornOfTheTritons, "Horn of the tritons")]
        [TestCase(WondrousItemConstants.HornOfValhalla, "Horn of Valhalla")]
        [TestCase(WondrousItemConstants.HorseshoesOfAZephyr, "Horseshoes of a zephyr")]
        [TestCase(WondrousItemConstants.HorseshoesOfSpeed, "Horseshoes of speed")]
        [TestCase(WondrousItemConstants.IncenseOfMeditation, "Incense of meditation")]
        [TestCase(WondrousItemConstants.IounStone_ClearSpindle, "Clear spindle ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_DarkBlueRhomboid, "Dark blue rhomboid ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_DeepRedSphere, "Deep red sphere ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_DustyRosePrism, "Dusty rose prism ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_IncandescentBlueSphere, "Incandescent blue sphere ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_IridescentSpindle, "Iridescent spindle ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_LavenderAndGreenEllipsoid, "Lavender and green ellipsoid ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_OrangePrism, "Orange prism ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_PaleBlueRhomboid, "Pale blue rhomboid ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_PaleGreenPrism, "Pale green prism ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_PaleLavenderEllipsoid, "Pale lavender ellipsoid ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_PearlyWhiteSpindle, "Pearly white spindle ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_PinkAndGreenSphere, "Pink and green sphere ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_PinkRhomboid, "Pink rhomboid ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_ScarletAndBlueSphere, "Scarlet and blue sphere ioun stone")]
        [TestCase(WondrousItemConstants.IounStone_VibrantPurplePrism, "Vibrant purple prism ioun stone")]
        [TestCase(WondrousItemConstants.IronBandsOfBilarro, "Iron bands of Bilarro")]
        [TestCase(WondrousItemConstants.IronFlask, "Iron flask")]
        [TestCase(WondrousItemConstants.KeoghtomsOintment, "Keoghtom's ointment")]
        [TestCase(WondrousItemConstants.LanternOfRevealing, "Lantern of revealing")]
        [TestCase(WondrousItemConstants.LensOfDetection, "Lens of detection")]
        [TestCase(WondrousItemConstants.LyreOfBuilding, "Lyre of building")]
        [TestCase(WondrousItemConstants.MantleOfFaith, "Mantle of faith")]
        [TestCase(WondrousItemConstants.MantleOfSpellResistance, "Mantle of spell resistance")]
        [TestCase(WondrousItemConstants.ManualOfBodilyHealth, "Manual of bodily health")]
        [TestCase(WondrousItemConstants.ManualOfGainfulExercise, "Manual of gainful exercise")]
        [TestCase(WondrousItemConstants.ManualOfQuicknessInAction, "Manual of quickness in action")]
        [TestCase(WondrousItemConstants.MaskOfTheSkull, "Mask of the skull")]
        [TestCase(WondrousItemConstants.MattockOfTheTitans, "Mattock of the titans")]
        [TestCase(WondrousItemConstants.MaulOfTheTitans, "Maul of the titans")]
        [TestCase(WondrousItemConstants.MedallionOfThoughts, "Medallion of thoughts")]
        [TestCase(WondrousItemConstants.MirrorOfLifeTrapping, "Mirror of life trapping")]
        [TestCase(WondrousItemConstants.MirrorOfMentalProwess, "Mirror of mental prowess")]
        [TestCase(WondrousItemConstants.MirrorOfOpposition, "Mirror of opposition")]
        [TestCase(WondrousItemConstants.MonksBelt, "Monk's belt")]
        [TestCase(WondrousItemConstants.MurlyndsSpoon, "Murlynd's spoon")]
        [TestCase(WondrousItemConstants.NecklaceOfAdaptation, "Necklace of adaptation")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs, "Necklace of fireballs")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_I, "Necklace of fireballs type I")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_II, "Necklace of fireballs type II")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_III, "Necklace of fireballs type III")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_IV, "Necklace of fireballs type IV")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_V, "Necklace of fireballs type V")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_VI, "Necklace of fireballs type VI")]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_VII, "Necklace of fireballs type VII")]
        [TestCase(WondrousItemConstants.NolzursMarvelousPigments, "Nolzur's marvelous pigments")]
        [TestCase(WondrousItemConstants.OrbOfStorms, "Orb of storms")]
        [TestCase(WondrousItemConstants.PearlOfPower_1stLevel, "1st-level spell pearl of power")]
        [TestCase(WondrousItemConstants.PearlOfPower_2ndLevel, "2nd-level spell pearl of power")]
        [TestCase(WondrousItemConstants.PearlOfPower_3rdLevel, "3rd-level spell pearl of power")]
        [TestCase(WondrousItemConstants.PearlOfPower_4thLevel, "4th-level spell pearl of power")]
        [TestCase(WondrousItemConstants.PearlOfPower_5thLevel, "5th-level spell pearl of power")]
        [TestCase(WondrousItemConstants.PearlOfPower_6thLevel, "6th-level spell pearl of power")]
        [TestCase(WondrousItemConstants.PearlOfPower_7thLevel, "7th-level spell pearl of power")]
        [TestCase(WondrousItemConstants.PearlOfPower_8thLevel, "8th-level spell pearl of power")]
        [TestCase(WondrousItemConstants.PearlOfPower_9thLevel, "9th-level spell pearl of power")]
        [TestCase(WondrousItemConstants.PearlOfPower_TwoSpells, "Two spells pearl of power")]
        [TestCase(WondrousItemConstants.PearlOfTheSirines, "Pearl of the sirines")]
        [TestCase(WondrousItemConstants.PeriaptOfHealth, "Periapt of health")]
        [TestCase(WondrousItemConstants.PeriaptOfProofAgainstPoison, "Periapt of proof against poison")]
        [TestCase(WondrousItemConstants.PeriaptOfWisdom, "Periapt of wisdom")]
        [TestCase(WondrousItemConstants.PeriaptOfWoundClosure, "Periapt of wound-closure")]
        [TestCase(WondrousItemConstants.PhylacteryOfFaithfulness, "Phylactery of faithfulness")]
        [TestCase(WondrousItemConstants.PhylacteryOfUndeadTurning, "Phylactery of undead turning")]
        [TestCase(WondrousItemConstants.PipesOfHaunting, "Pipes of haunting")]
        [TestCase(WondrousItemConstants.PipesOfPain, "Pipes of pain")]
        [TestCase(WondrousItemConstants.PipesOfSounding, "Pipes of sounding")]
        [TestCase(WondrousItemConstants.PipesOfTheSewers, "Pipes of the sewers")]
        [TestCase(WondrousItemConstants.PortableHole, "Portable hole")]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Anchor, "Quaal's anchor feather token")]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Bird, "Quaal's bird feather token")]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Fan, "Quaal's fan feather token")]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_SwanBoat, "Quaal's swan boat feather token")]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Tree, "Quaal's tree feather token")]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Whip, "Quaal's whip feather token")]
        [TestCase(WondrousItemConstants.QuiverOfEhlonna, "Quiver of Ehlonna")]
        [TestCase(WondrousItemConstants.RingGates, "Ring gates")]
        [TestCase(WondrousItemConstants.RobeOfBlending, "Robe of blending")]
        [TestCase(WondrousItemConstants.RobeOfBones, "Robe of bones")]
        [TestCase(WondrousItemConstants.RobeOfEyes, "Robe of eyes")]
        [TestCase(WondrousItemConstants.RobeOfScintillatingColors, "Robe of scintillating colors")]
        [TestCase(WondrousItemConstants.RobeOfStars, "Robe of stars")]
        [TestCase(WondrousItemConstants.RobeOfTheArchmagi, "Robe of the archmagi")]
        [TestCase(WondrousItemConstants.RobeOfUsefulItems, "Robe of useful items")]
        [TestCase(WondrousItemConstants.RopeOfClimbing, "Rope of climbing")]
        [TestCase(WondrousItemConstants.RopeOfEntanglement, "Rope of entanglement")]
        [TestCase(WondrousItemConstants.SalveOfSlipperiness, "Salve of slipperiness")]
        [TestCase(WondrousItemConstants.ScabbardOfKeenEdges, "Scabbard of keen edges")]
        [TestCase(WondrousItemConstants.ScarabOfProtection, "Scarab of protection")]
        [TestCase(WondrousItemConstants.Silversheen, "Silversheen")]
        [TestCase(WondrousItemConstants.SlippersOfSpiderClimbing, "Slippers of spider climbing")]
        [TestCase(WondrousItemConstants.SovereignGlue, "Sovereign glue")]
        [TestCase(WondrousItemConstants.StoneHorse_Courser, "Courser stone horse")]
        [TestCase(WondrousItemConstants.StoneHorse_Destrier, "Destrier stone horse")]
        [TestCase(WondrousItemConstants.StoneOfAlarm, "Stone of alarm")]
        [TestCase(WondrousItemConstants.StoneOfControllingEarthElementals, "Stone of controlling earth elementals")]
        [TestCase(WondrousItemConstants.StoneOfGoodLuck_Luckstone, "Stone of good luck (luckstone)")]
        [TestCase(WondrousItemConstants.StoneSalve, "Stone salve")]
        [TestCase(WondrousItemConstants.StrandOfPrayerBeads, "Strand of prayer beads")]
        [TestCase(WondrousItemConstants.StrandOfPrayerBeads_Lesser, "Lesser strand of prayer beads")]
        [TestCase(WondrousItemConstants.StrandOfPrayerBeads_Greater, "Greater strand of prayer beads")]
        [TestCase(WondrousItemConstants.TalismanOfTheSphere, "Talisman of the sphere")]
        [TestCase(WondrousItemConstants.TomeOfClearThought, "Tome of clear thought")]
        [TestCase(WondrousItemConstants.TomeOfLeadershipAndInfluence, "Tome of leadership and influence")]
        [TestCase(WondrousItemConstants.TomeOfUnderstanding, "Tome of understanding")]
        [TestCase(WondrousItemConstants.UnguentOfTimelessness, "Unguent of timelessness")]
        [TestCase(WondrousItemConstants.UniversalSolvent, "Universal solvent")]
        [TestCase(WondrousItemConstants.VestOfEscape, "Vest of escape")]
        [TestCase(WondrousItemConstants.WellOfManyWorlds, "Well of many worlds")]
        [TestCase(WondrousItemConstants.WindFan, "Wind fan")]
        [TestCase(WondrousItemConstants.WingedBoots, "Winged boots")]
        [TestCase(WondrousItemConstants.WingsOfFlying, "Wings of flying")]
        [TestCase(WondrousItemConstants.IncenseOfObsession, "Incense of obsession")]
        [TestCase(WondrousItemConstants.AmuletOfInescapableLocation, "Amulet of inescapable location")]
        [TestCase(WondrousItemConstants.StoneOfWeight_Loadstone, "Stone of weight (loadstone)")]
        [TestCase(WondrousItemConstants.BracersOfDefenselessness, "Bracers of defenselessness")]
        [TestCase(WondrousItemConstants.GauntletsOfFumbling, "Gauntlets of fumbling")]
        [TestCase(WondrousItemConstants.MedallionOfThoughtProjection, "Medallion of thought projection")]
        [TestCase(WondrousItemConstants.FlaskOfCurses, "Flask of curses")]
        [TestCase(WondrousItemConstants.DustOfSneezingAndChoking, "Dust of sneezing and choking")]
        [TestCase(WondrousItemConstants.RobeOfPowerlessness, "Robe of powerlessness")]
        [TestCase(WondrousItemConstants.BagOfDevouring, "Bag of devouring")]
        [TestCase(WondrousItemConstants.RobeOfVermin, "Robe of vermin")]
        [TestCase(WondrousItemConstants.PeriaptOfFoulRotting, "Periapt of foul rotting")]
        [TestCase(WondrousItemConstants.BootsOfDancing, "Boots of dancing")]
        [TestCase(WondrousItemConstants.HelmOfOppositeAlignment, "Helm of opposite alignment")]
        [TestCase(WondrousItemConstants.BroomOfAnimatedAttack, "Broom of animated attack")]
        [TestCase(WondrousItemConstants.VacousGrimoire, "Vacuous grimoire")]
        [TestCase(WondrousItemConstants.CrystalBall_Hypnosis, "Crystal hypnosis ball")]
        [TestCase(WondrousItemConstants.NecklaceOfStrangulation, "Necklace of strangulation")]
        [TestCase(WondrousItemConstants.CloakOfPoisonousness, "Cloak of poisonousness")]
        [TestCase(WondrousItemConstants.ScarabOfDeath, "Scarab of death")]
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