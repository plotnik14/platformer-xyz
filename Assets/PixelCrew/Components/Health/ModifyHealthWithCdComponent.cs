﻿using PixelCrew.Utils;
using UnityEngine;

namespace PixelCrew.Components.Health
{
    public class ModifyHealthWithCdComponent : ModifyHealthComponent
    {
        [SerializeField] private Cooldown _cooldown;

        public override void ApplyHealthChange(GameObject target)
        {
            if (_cooldown.IsReady)
            {
                _cooldown.Reset();
                base.ApplyHealthChange(target);
            }
        }
    }
}