using CensusAPI.Enums;
using CensusAPI.Features;
using CensusCore.Events.Attributes;
using CensusCore.Events.EventArgs.Player;
using PluginFramework.Attributes;
using PluginFramework;
using PluginFramework.Classes;
using PluginFramework.Events.EventsArgs;
using System.IO;
using System;
using DSharp4Webhook;
using Mirror;

namespace AdminLogs.Events
{
    public class WorldEventHandlers : IScript
    {

        [WorldEvent(WorldEventType.OnRoundEnd)]
        public static void OnEnd(RoundEndEvent ev)
        {
            WebhookHandler wb = new WebhookHandler();
            if (AdminLogs.Instance.Config.RoundEnd)
            {
                wb.SendMessage("Round Ended", "Round Results", $"```# of people escaped : {ev.EscapedPlayers}\nForce Ended? : {ev.ForceEnded}```");
            }
        }
    }
}

