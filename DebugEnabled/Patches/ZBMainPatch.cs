using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.DebugEnabled.Patches;

[HarmonyPatch(typeof(ZBMain))]
public static class ZBMainPatch
{
    private static string OriginalVersionText;

    [HarmonyPostfix]
    [HarmonyPatch(nameof(ZBMain.Start))]
    [HarmonyPatch(nameof(ZBMain.OnEnteredMap))]
    [HarmonyPatch(nameof(ZBMain.CleanUp))]
    [HarmonyPriority(Priority.Last)]
    public static void UpdateVersionText(ZBMain __instance)
    {
        // Save original version text
        // This patch runs last so other mods can modify the version text
        OriginalVersionText ??= __instance.versionText.text;
        // Add debug label if debug mode is enabled
        __instance.versionText.text = (DebugController.DebugEnabled ? "[Debug] " : "") + OriginalVersionText;
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(ZBMain.DisplayConsole))]
    public static void UpdateQuickButtons(ZBMain __instance, bool show)
    {
        // If the console is being hidden, there is no need to run additional operations
        if (!show) return;
        // Otherwise, toggle the quick buttons panel based on debug mode
        __instance.console.quickButtonsPanel.SetActive(DebugController.DebugEnabled);
    }
}
