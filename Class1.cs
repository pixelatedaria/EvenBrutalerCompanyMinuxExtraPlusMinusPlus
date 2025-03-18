using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using HarmonyLib;
using GameNetcodeStuff;

[BepInPlugin("EvenBrutalerCompanyMinusExtraPlusExtraMinusPlus", "EvenBrutalerCompanyMinusExtraPlusExtraMinusPlus", "1.0.2")]
public class EvenBrutalerCompanyMinusExtraPlusExtraMinusPlus : BaseUnityPlugin
{
    internal new static ManualLogSource logger;

    public void Awake()
    {
        logger = base.Logger;
        Harmony.CreateAndPatchAll(typeof(PlayerPatch));
        Debug.Log(" _           _             _     _ _     _ _   \r\n| |__   ___ | |_   _   ___| |__ (_) |_  (_) |_ \r\n| '_ \\ / _ \\| | | | | / __| '_ \\| | __| | | __|\r\n| | | | (_) | | |_| | \\__ \\ | | | | |_  | | |_ \r\n|_| |_|\\___/|_|\\__, | |___/_| |_|_|\\__| |_|\\__|\r\n _             |___/          _                \r\n| | ___   __ _  __| | ___  __| |               \r\n| |/ _ \\ / _` |/ _` |/ _ \\/ _` |               \r\n| | (_) | (_| | (_| |  __/ (_| |               \r\n|_|\\___/ \\__,_|\\__,_|\\___|\\__,_| ");
    }

    public class PlayerPatch
    {
        [HarmonyPatch(typeof(PlayerControllerB), nameof(PlayerControllerB.Update))]
        [HarmonyPostfix]
        private static void PlayerControllerB_Update(PlayerControllerB __instance)
        {
            if (!__instance) return;

            if (__instance.isExhausted)
            {
                __instance.DamagePlayer(10);
            }

            if (__instance.isUnderwater)
            {
                __instance.BroadcastMessage("someone touched W*ter");
                __instance.DamagePlayer(10);
            }

            if (__instance.isCrouching)
            {
                
                
                
                __instance.drunkness = __instance.drunkness + 1;
                __instance.DropAllHeldItems();
            }
            else
            {
                __instance.drunkness = 0;
            }
                

            if (__instance.drunkness >= 300)
            {
                __instance.KillPlayer(Vector3.zero);
            }
                
        }
    }
}
