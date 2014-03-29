﻿using System;
using System.Collections.Generic;
using EquipmentGen.Common.Items;

namespace EquipmentGen.Generators.Interfaces.Items.Magical
{
    public interface ISpecialAbilitiesGenerator
    {
        IEnumerable<SpecialAbility> GenerateWith(IEnumerable<String> attributes, String power, Int32 magicalBonus, Int32 quantity);
    }
}