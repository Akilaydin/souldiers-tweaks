﻿using BattleDefs;
using HarmonyLib;
using System;

namespace SouldiersTweaks.Patch
{
    [HarmonyPatch(typeof(LedgeDetector), "OnTriggerEnter2D")]
    class LedgeDetectorPatch
	{
        public static bool Prefix()
        {
            var tweak = (LedgeGrabTweak)Tweaks.GetPatchTweak(typeof(LedgeGrabTweak));
            if (tweak.Active)
            {
                if (!InputManager.s_cInstance.GetInputStatus(InputManager.InputCommand.UP).Pressed && !InputManager.s_cInstance.GetInputStatus(InputManager.InputCommand.UP).Held)
                {
                    return false;
                }
            }

            return true;
        }
    }
}