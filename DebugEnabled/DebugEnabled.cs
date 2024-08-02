using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.DebugEnabled;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
public class DebugEnabled : BaseUnityPlugin
{
    public const string PluginGUID = "AetharNet.Mods.ZumbiBlocks2.DebugEnabled";
    public const string PluginAuthor = "wowi";
    public const string PluginName = "DebugEnabled";
    public const string PluginVersion = "0.1.0";

    internal new static ManualLogSource Logger;

    private void Awake()
    {
        Logger = base.Logger;
        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), PluginGUID);
    }
}
