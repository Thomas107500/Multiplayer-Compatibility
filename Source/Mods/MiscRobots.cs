﻿using HarmonyLib;
using Multiplayer.API;
using System;
using Verse;

namespace Multiplayer.Compat
{
    /// <summary>Misc. Robots by HaploX1</summary>
    /// <see href="https://steamcommunity.com/sharedfiles/filedetails/?id=724602224"/>
    [MpCompatFor("Haplo.Miscellaneous.Robots")]
    class MiscRobots
    {
        public MiscRobots(ModContentPack mod) => LongEventHandler.ExecuteWhenFinished(LatePatch);
        private static void LatePatch()
        {
            Type rechargestationType = AccessTools.TypeByName("AIRobot.X2_Building_AIRobotRechargeStation");
            Type robotType = AccessTools.TypeByName("AIRobot.X2_AIRobot");

            MP.RegisterSyncMethod(rechargestationType, "Button_CallAllBotsForShutdown");
            MP.RegisterSyncMethod(rechargestationType, "Button_CallBotForShutdown");
            MP.RegisterSyncMethod(rechargestationType, "Button_RepairDamagedRobot");
            MP.RegisterSyncMethod(rechargestationType, "Button_RequestRepair4Robot");
            MP.RegisterSyncMethod(rechargestationType, "Button_ResetDestroyedRobot");
            MP.RegisterSyncMethod(rechargestationType, "Button_SpawnAllAvailableBots");
            MP.RegisterSyncMethod(rechargestationType, "Button_SpawnBot");

            //Might as well sync the arrow gizmos in case some one actually click on it, because it is accessible by users,but not affecting gameplay
            MP.RegisterSyncMethod(robotType, "Debug_ForceGotoDistance");

            MP.RegisterSyncMethod(rechargestationType, "AddRobotToContainer").SetContext(SyncContext.CurrentMap);

            PatchingUtilities.PatchPushPopRand("AIRobot.MoteThrowHelper:ThrowBatteryXYZ");
            PatchingUtilities.PatchPushPopRand("AIRobot.MoteThrowHelper:ThrowNoRobotSign");

        }

    }
}
