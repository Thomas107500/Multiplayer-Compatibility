﻿using System;
using Verse;
using HarmonyLib;
using Multiplayer.API;

namespace Multiplayer.Compat
{
    /// <summary>RunAndGun by roolo</summary>
    /// <see href="https://steamcommunity.com/sharedfiles/filedetails/?id=1204108550"/>
    [MpCompatFor("roolo.RunAndGun")]
    class RunandGun
    {
        Type type = AccessTools.TypeByName("RunAndGun.Harmony.Pawn_DraftController_GetGizmos_Patch");
        public RunandGun(ModContentPack mod)
            {
                MP.RegisterSyncDelegate(type, "<>c__DisplayClass0_0", "<Postfix>b__1");
            }
    }
}
