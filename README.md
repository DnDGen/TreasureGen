# TreasureGen

Generate random Dungeons & Dragons treasure, equipment, and items

[![Build Status](https://dev.azure.com/dndgen/DnDGen/_apis/build/status/DnDGen.TreasureGen?branchName=master)](https://dev.azure.com/dndgen/DnDGen/_build/latest?definitionId=15&branchName=master)

### Use

To use TreasureGen, simply generate from the generator you wish to use.  Levels are from 1 to 20, and powers can be Mundane, Minor, Medium, and Major.

```C#
var treasure = treasureGenerator.GenerateAtLevel(6);
var mundaneArmor = mundaneArmorGenerator.Generate();
var magicalWeapon = magicalWeaponGenerator.GenerateAtPower(PowerConstants.Major);
```

### Getting the Generators

You can obtain generators from the bootstrapper project.  Because the generators are very complex and are decorated in various ways, there is not a (recommended) way to build these generator manually.  Please use the Module Loader in the IoC domain.  **Note:** This will also load the dependencies for TreasureGen, including RollGen and Infrastructure

```C#
var kernel = new StandardKernel();
var treasureGenModuleLoader = new TreasureGenModuleLoader();

treasureGenModuleLoader.LoadModules(kernel);
```

Your particular syntax for how the Ninject injection should work will depend on your project (class library, web site, etc.)

### Installing TreasureGen

The project is on [Nuget](https://www.nuget.org/packages/DnDGen.TreasureGen). Install via the NuGet Package Manager.

    PM > Install-Package DnDGen.TreasureGen
