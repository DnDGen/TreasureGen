 
echo "Deploying TreasureGen to NuGet"

ApiKey=$1
Source=$2

echo "Nuget Source is $Source"
echo "Nuget API Key is $ApiKey (should be secure)"

echo "Packing TreasureGen"
nuget pack ./TreasureGen/TreasureGen.nuspec -Verbosity detailed

echo "Packing TreasureGen.Domain"
nuget pack ./TreasureGen.Domain/TreasureGen.Domain.nuspec -Verbosity detailed

echo "Pushing TreasureGen"
nuget push ./DnDGen.TreasureGen.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source $Source

echo "Pushing TreasureGen.Domain"
nuget push ./DnDGen.TreasureGen.Domain.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source $Source