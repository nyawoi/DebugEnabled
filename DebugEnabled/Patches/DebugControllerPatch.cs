using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.DebugEnabled.Patches;

[HarmonyPatch(typeof(DebugController))]
public static class DebugControllerPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(DebugController.DebugEnabled), MethodType.Getter)]
    public static void EnableDebugMode(ref bool __result)
    {
        // Only enable debug mode if not in-game, or if hosting a game
        __result = !ZBMain.instance.mapIsLoaded || ZBMain.instance.multiplayer.IsServer();
    }
}
