﻿using NUnit.Framework;
using System;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class WondrousItemAttributesTests : AttributesTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem); }
        }

        [TestCase(WondrousItemConstants.BeadOfForce,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.BraceletOfFriends,
            AttributeConstants.OneTimeUse,
            AttributeConstants.Charged)]
        [TestCase(WondrousItemConstants.BroochOfShielding,
            AttributeConstants.OneTimeUse,
            AttributeConstants.Charged)]
        [TestCase(WondrousItemConstants.CandleOfInvocation,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.CandleOfTruth,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.ChimeOfOpening,
            AttributeConstants.OneTimeUse,
            AttributeConstants.Charged)]
        [TestCase(WondrousItemConstants.DeckOfIllusions,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.DustOfAppearance,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.DustOfDisappearance,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.DustOfIllusion,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.DustOfTracelessness,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.DustOfDryness,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.ElementalGem,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.ElixerOfFireBreath,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.ElixerOfHiding,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.ElixerOfLove,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.ElixerOfSneaking,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.ElixerOfSwimming,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.ElixerOfTruth,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.ElixerOfVision,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.GemOfBrightness,
            AttributeConstants.OneTimeUse,
            AttributeConstants.Charged)]
        [TestCase(WondrousItemConstants.GolemManual_Clay,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.GolemManual_Flesh,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.GolemManual_Iron,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.GolemManual_Stone,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.GolemManual_Stone_Greater,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.IncenseOfMeditation,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.KeoghtomsOintment,
            AttributeConstants.OneTimeUse,
            AttributeConstants.Charged)]
        [TestCase(WondrousItemConstants.ManualOfBodilyHealth,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.ManualOfGainfulExercise,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.ManualOfQuicknessInAction,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.NolzursMarvelousPigments,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_I,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_II,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_III,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_IV,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_V,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_VI,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.NecklaceOfFireballs_VII,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Bird,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Anchor,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Whip,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Fan,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_SwanBoat,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.QuaalsFeatherToken_Tree,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.RobeOfUsefulItems,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.RobeOfBones,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.SalveOfSlipperiness,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.SovereignGlue,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.ScarabOfProtection,
            AttributeConstants.OneTimeUse,
            AttributeConstants.Charged)]
        [TestCase(WondrousItemConstants.Silversheen,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.StoneSalve,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.TomeOfClearThought,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.TomeOfLeadershipAndInfluence,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.TomeOfUnderstanding,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.UnguentOfTimelessness,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.UniversalSolvent,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.DimensionalShackles)]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_ObsidianSteed)]
        [TestCase(WondrousItemConstants.DrumsOfPanic)]
        [TestCase(WondrousItemConstants.IounStone_OrangePrism)]
        [TestCase(WondrousItemConstants.IounStone_PaleGreenPrism)]
        [TestCase(WondrousItemConstants.LanternOfRevealing)]
        [TestCase(WondrousItemConstants.RobeOfBlending)]
        [TestCase(WondrousItemConstants.AmuletOfProofAgainstDetectionAndLocation)]
        [TestCase(WondrousItemConstants.CarpetOfFlying_5x10)]
        [TestCase(WondrousItemConstants.BeltOfGiantStrength)]
        [TestCase(WondrousItemConstants.IounStone_VibrantPurplePrism)]
        [TestCase(WondrousItemConstants.PearlOfPower_6thLevel)]
        [TestCase(WondrousItemConstants.IounStone_LavenderAndGreenEllipsoid)]
        [TestCase(WondrousItemConstants.RingGates)]
        [TestCase(WondrousItemConstants.CrystalBall)]
        [TestCase(WondrousItemConstants.OrbOfStorms)]
        [TestCase(WondrousItemConstants.BootsOfTeleportation)]
        [TestCase(WondrousItemConstants.PearlOfPower_7thLevel)]
        [TestCase(WondrousItemConstants.CloakOfDisplacement_Major)]
        [TestCase(WondrousItemConstants.CrystalBall_SeeInvisibility)]
        [TestCase(WondrousItemConstants.HornOfValhalla)]
        [TestCase(WondrousItemConstants.CrystalBall_DetectThoughts)]
        [TestCase(WondrousItemConstants.CarpetOfFlying_6x9)]
        [TestCase(WondrousItemConstants.WingsOfFlying)]
        [TestCase(WondrousItemConstants.CloakOfEtherealness)]
        [TestCase(WondrousItemConstants.DaernsInstantFortress)]
        [TestCase(WondrousItemConstants.EyesOfCharming)]
        [TestCase(WondrousItemConstants.RobeOfStars)]
        [TestCase(WondrousItemConstants.CarpetOfFlying_10x10)]
        [TestCase(WondrousItemConstants.Darkskull)]
        [TestCase(WondrousItemConstants.CubeOfForce)]
        [TestCase(WondrousItemConstants.PearlOfPower_8thLevel)]
        [TestCase(WondrousItemConstants.CrystalBall_Telepathy)]
        [TestCase(WondrousItemConstants.HornOfBlasting_Greater)]
        [TestCase(WondrousItemConstants.PearlOfPower_TwoSpells)]
        [TestCase(WondrousItemConstants.HelmOfTeleportation)]
        [TestCase(WondrousItemConstants.GemOfSeeing)]
        [TestCase(WondrousItemConstants.RobeOfTheArchmagi)]
        [TestCase(WondrousItemConstants.MantleOfFaith)]
        [TestCase(WondrousItemConstants.CrystalBall_TrueSeeing)]
        [TestCase(WondrousItemConstants.PearlOfPower_9thLevel)]
        [TestCase(WondrousItemConstants.WellOfManyWorlds)]
        [TestCase(WondrousItemConstants.ApparatusOfKwalish)]
        [TestCase(WondrousItemConstants.MantleOfSpellResistance)]
        [TestCase(WondrousItemConstants.MirrorOfOpposition)]
        [TestCase(WondrousItemConstants.StrandOfPrayerBeads_Greater)]
        [TestCase(WondrousItemConstants.AmuletOfMightyFists)]
        [TestCase(WondrousItemConstants.EyesOfPetrification)]
        [TestCase(WondrousItemConstants.BowlOfCommandingWaterElementals)]
        [TestCase(WondrousItemConstants.BrazierOfCommandingFireElementals)]
        [TestCase(WondrousItemConstants.CenserOfControllingAirElementals)]
        [TestCase(WondrousItemConstants.StoneOfControllingEarthElementals)]
        [TestCase(WondrousItemConstants.AmuletOfThePlanes)]
        [TestCase(WondrousItemConstants.RobeOfEyes)]
        [TestCase(WondrousItemConstants.HelmOfBrilliance)]
        [TestCase(WondrousItemConstants.EfreetiBottle)]
        [TestCase(WondrousItemConstants.ChaosDiamond)]
        [TestCase(WondrousItemConstants.CubicGate)]
        [TestCase(WondrousItemConstants.IronFlask)]
        [TestCase(WondrousItemConstants.MirrorOfMentalProwess)]
        [TestCase(WondrousItemConstants.MirrorOfLifeTrapping)]
        [TestCase(WondrousItemConstants.BootsOfLevitation)]
        [TestCase(WondrousItemConstants.HarpOfCharming)]
        [TestCase(WondrousItemConstants.AmuletOfNaturalArmor)]
        [TestCase(WondrousItemConstants.HandOfGlory)]
        [TestCase(WondrousItemConstants.IounStone_DeepRedSphere)]
        [TestCase(WondrousItemConstants.IounStone_IncandescentBlueSphere)]
        [TestCase(WondrousItemConstants.IounStone_PaleBlueRhomboid)]
        [TestCase(WondrousItemConstants.IounStone_PinkAndGreenSphere)]
        [TestCase(WondrousItemConstants.IounStone_PinkRhomboid)]
        [TestCase(WondrousItemConstants.IounStone_ScarletAndBlueSphere)]
        [TestCase(WondrousItemConstants.DecanterOfEndlessWater)]
        [TestCase(WondrousItemConstants.NecklaceOfAdaptation)]
        [TestCase(WondrousItemConstants.PearlOfPower_3rdLevel)]
        [TestCase(WondrousItemConstants.TalismanOfTheSphere)]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_SerpentineOwl)]
        [TestCase(WondrousItemConstants.StrandOfPrayerBeads_Lesser)]
        [TestCase(WondrousItemConstants.BagOfHolding_IV)]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_BronzeGriffon)]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_EbonyFly)]
        [TestCase(WondrousItemConstants.GloveOfStoring)]
        [TestCase(WondrousItemConstants.IounStone_DarkBlueRhomboid)]
        [TestCase(WondrousItemConstants.StoneHorse_Courser)]
        [TestCase(WondrousItemConstants.CapeOfTheMountebank)]
        [TestCase(WondrousItemConstants.PhylacteryOfUndeadTurning)]
        [TestCase(WondrousItemConstants.GauntletOfRust)]
        [TestCase(WondrousItemConstants.BootsOfSpeed)]
        [TestCase(WondrousItemConstants.GogglesOfNight)]
        [TestCase(WondrousItemConstants.MedallionOfThoughts)]
        [TestCase(WondrousItemConstants.PipesOfPain)]
        [TestCase(WondrousItemConstants.BoccobsBlessedBook)]
        [TestCase(WondrousItemConstants.MonksBelt)]
        [TestCase(WondrousItemConstants.LyreOfBuilding)]
        [TestCase(WondrousItemConstants.CloakOfArachnida)]
        [TestCase(WondrousItemConstants.StoneHorse_Destrier)]
        [TestCase(WondrousItemConstants.BeltOfDwarvenkind)]
        [TestCase(WondrousItemConstants.PeriaptOfWoundClosure)]
        [TestCase(WondrousItemConstants.HornOfTheTritons)]
        [TestCase(WondrousItemConstants.PearlOfTheSirines)]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_OnyxDog)]
        [TestCase(WondrousItemConstants.AmuletOfHealth)]
        [TestCase(WondrousItemConstants.WingedBoots)]
        [TestCase(WondrousItemConstants.BracersOfArmor)]
        [TestCase(WondrousItemConstants.GlovesOfDexterity)]
        [TestCase(WondrousItemConstants.HeadbandOfIntellect)]
        [TestCase(WondrousItemConstants.PearlOfPower_4thLevel)]
        [TestCase(WondrousItemConstants.PeriaptOfWisdom)]
        [TestCase(WondrousItemConstants.ScabbardOfKeenEdges)]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_GoldenLions)]
        [TestCase(WondrousItemConstants.ChimeOfInterruption)]
        [TestCase(WondrousItemConstants.BroomOfFlying)]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_MarbleElephant)]
        [TestCase(WondrousItemConstants.IounStone_IridescentSpindle)]
        [TestCase(WondrousItemConstants.CarpetOfFlying_5x5)]
        [TestCase(WondrousItemConstants.HornOfBlasting)]
        [TestCase(WondrousItemConstants.IounStone_PaleLavenderEllipsoid)]
        [TestCase(WondrousItemConstants.IounStone_PearlyWhiteSpindle)]
        [TestCase(WondrousItemConstants.PortableHole)]
        [TestCase(WondrousItemConstants.StoneOfGoodLuck_Luckstone)]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_IvoryGoats)]
        [TestCase(WondrousItemConstants.RopeOfEntanglement)]
        [TestCase(WondrousItemConstants.MaskOfTheSkull)]
        [TestCase(WondrousItemConstants.MattockOfTheTitans)]
        [TestCase(WondrousItemConstants.CircletOfBlasting_Major)]
        [TestCase(WondrousItemConstants.CloakOfDisplacement_Minor)]
        [TestCase(WondrousItemConstants.HelmOfUnderwaterAction)]
        [TestCase(WondrousItemConstants.BracersOfArchery_Greater)]
        [TestCase(WondrousItemConstants.CloakOfResistance)]
        [TestCase(WondrousItemConstants.EyesOfDoom)]
        [TestCase(WondrousItemConstants.PearlOfPower_5thLevel)]
        [TestCase(WondrousItemConstants.MaulOfTheTitans)]
        [TestCase(WondrousItemConstants.StrandOfPrayerBeads)]
        [TestCase(WondrousItemConstants.CloakOfTheBat)]
        [TestCase(WondrousItemConstants.IronBandsOfBilarro)]
        [TestCase(WondrousItemConstants.CubeOfFrostResistance)]
        [TestCase(WondrousItemConstants.HelmOfTelepathy)]
        [TestCase(WondrousItemConstants.PeriaptOfProofAgainstPoison)]
        [TestCase(WondrousItemConstants.RobeOfScintillatingColors)]
        [TestCase(WondrousItemConstants.BagOfTricks_Gray)]
        [TestCase(WondrousItemConstants.HandOfTheMage)]
        [TestCase(WondrousItemConstants.PearlOfPower_1stLevel)]
        [TestCase(WondrousItemConstants.PhylacteryOfFaithfulness)]
        [TestCase(WondrousItemConstants.PipesOfTheSewers)]
        [TestCase(WondrousItemConstants.GogglesOfMinuteSeeing)]
        [TestCase(WondrousItemConstants.HatOfDisguise)]
        [TestCase(WondrousItemConstants.PipesOfSounding)]
        [TestCase(WondrousItemConstants.QuiverOfEhlonna)]
        [TestCase(WondrousItemConstants.HewardsHandyHaversack)]
        [TestCase(WondrousItemConstants.HornOfFog)]
        [TestCase(WondrousItemConstants.BagOfHolding_I)]
        [TestCase(WondrousItemConstants.BootsOfElvenkind)]
        [TestCase(WondrousItemConstants.BootsOfTheWinterlands)]
        [TestCase(WondrousItemConstants.CloakOfElvenkind)]
        [TestCase(WondrousItemConstants.EyesOfTheEagle)]
        [TestCase(WondrousItemConstants.GolembaneScarab)]
        [TestCase(WondrousItemConstants.StoneOfAlarm)]
        [TestCase(WondrousItemConstants.BagOfTricks_Rust)]
        [TestCase(WondrousItemConstants.HorseshoesOfSpeed)]
        [TestCase(WondrousItemConstants.RopeOfClimbing)]
        [TestCase(WondrousItemConstants.LensOfDetection)]
        [TestCase(WondrousItemConstants.DruidsVestments)]
        [TestCase(WondrousItemConstants.FigurineOfWondrousPower_SilverRaven)]
        [TestCase(WondrousItemConstants.CloakOfCharisma)]
        [TestCase(WondrousItemConstants.GauntletsOfOgrePower)]
        [TestCase(WondrousItemConstants.GlovesOfArrowSnaring)]
        [TestCase(WondrousItemConstants.IounStone_ClearSpindle)]
        [TestCase(WondrousItemConstants.PearlOfPower_2ndLevel)]
        [TestCase(WondrousItemConstants.CircletOfPersuasion)]
        [TestCase(WondrousItemConstants.SlippersOfSpiderClimbing)]
        [TestCase(WondrousItemConstants.BagOfHolding_II)]
        [TestCase(WondrousItemConstants.BracersOfArchery_Lesser)]
        [TestCase(WondrousItemConstants.IounStone_DustyRosePrism)]
        [TestCase(WondrousItemConstants.HelmOfComprehendLanguagesAndReadMagic)]
        [TestCase(WondrousItemConstants.VestOfEscape)]
        [TestCase(WondrousItemConstants.EversmokingBottle)]
        [TestCase(WondrousItemConstants.MurlyndsSpoon)]
        [TestCase(WondrousItemConstants.BootsOfStridingAndSpringing)]
        [TestCase(WondrousItemConstants.WindFan)]
        [TestCase(WondrousItemConstants.HorseshoesOfAZephyr)]
        [TestCase(WondrousItemConstants.PipesOfHaunting)]
        [TestCase(WondrousItemConstants.GlovesOfSwimmingAndClimbing)]
        [TestCase(WondrousItemConstants.BagOfTricks_Tan)]
        [TestCase(WondrousItemConstants.CircletOfBlasting_Minor)]
        [TestCase(WondrousItemConstants.HornOfGoodnessEvil)]
        [TestCase(WondrousItemConstants.FoldingBoat)]
        [TestCase(WondrousItemConstants.CloakOfTheMantaRay)]
        [TestCase(WondrousItemConstants.BottleOfAir)]
        [TestCase(WondrousItemConstants.BagOfHolding_III)]
        [TestCase(WondrousItemConstants.PeriaptOfHealth)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}