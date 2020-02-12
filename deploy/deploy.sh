 
echo "Deploying DnDGen.TreasureGen to NuGet"

ApiKey=$1
Source=$2

echo "Nuget Source is $Source"
echo "Nuget API Key is $ApiKey (should be secure)"

echo "Pushing DnDGen.TreasureGen"
dotnet nuget push ./DnDGen.TreasureGen/bin/Release/DnDGen.TreasureGen.*.nupkg --api-key $ApiKey --source $Source --skip-duplicate