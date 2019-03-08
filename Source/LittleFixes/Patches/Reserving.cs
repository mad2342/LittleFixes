﻿using System;
using Harmony;

namespace LittleFixes.Patches
{
    // Enable Reserve for AI
    [HarmonyPatch(typeof(BehaviorTree), "GetBehaviorVariableValue")]
    public static class BehaviorTree_GetBehaviorVariableValue_Patch
    {
        public static bool Prepare()
        {
            return LittleFixes.Settings.ReserveEnable;
        }

        public static void Postfix(BehaviorTree __instance, ref BehaviorVariableValue __result, BehaviorVariableName name)
        {
            try
            {
                if (name == BehaviorVariableName.Bool_ReserveEnabled)
                {
                    Logger.LogLine("[BehaviorTree_GetBehaviorVariableValue_POSTFIX] Overriding BehaviorVariableName.Bool_ReserveEnabled: true");
                    __result.BoolVal = true;
                }
                else if (name == BehaviorVariableName.Float_ReserveBasePercentage)
                {
                    Logger.LogLine("[BehaviorTree_GetBehaviorVariableValue_POSTFIX] Overriding BehaviorVariableName.Bool_ReserveEnabled: 25f");
                    __result.FloatVal = LittleFixes.Settings.ReserveBasePercentage;
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e);
            }
        }
    }
}
