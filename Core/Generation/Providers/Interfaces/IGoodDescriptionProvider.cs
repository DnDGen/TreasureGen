using System;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface IGoodDescriptionProvider
    {
        String GetDescriptionFor(String valueRoll);
    }
}