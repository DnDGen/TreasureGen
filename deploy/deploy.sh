 
echo "Deploying TreasureGen to NuGet"

ApiKey=$1
Source=$2

echo "Nuget Source is $Source"
echo "Nuget API Key is $ApiKey (should be secure)"

echo "Packing TreasureGen"
mono ./nuget.exe pack ./TreasureGen/TreasureGen.nuspec -Verbosity detailed

echo "Pushing TreasureGen"
mono ./nuget.exe push ./DnDGen.TreasureGen.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source $Source