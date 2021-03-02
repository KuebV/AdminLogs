using CensusAPI.Enums;
using CensusAPI.Features;
using CensusCore.Events.Attributes;
using CensusCore.Events.EventArgs.Player;
using PluginFramework.Attributes;
using PluginFramework.Classes;
using PluginFramework.Events.EventsArgs;
using System.IO;
using System;
using DSharp4Webhook;
namespace AdminLogs.Events
{
    public class WorldEventHandlers
    {
        [WorldEvent(WorldEventType.OnRoundStart)]
        public static void OnStart()
        {
            WebhookHandler wb = new WebhookHandler();
            if (AdminLogs.Instance.Config.RoundStart)
            {
                wb.SendMessage("Round Started", "Max Players", Server.MaxPlayers.ToString());
            }
        }

        [WorldEvent(WorldEventType.OnRoundEnd)]
        public static void OnEnd(RoundEndEvent ev)
        {
            WebhookHandler wb = new WebhookHandler();
            if (AdminLogs.Instance.Config.RoundStart)
            {
                wb.SendMessage("Round Ended", "Round Results", $"```# of people escaped : {ev.EscapedPlayers}\nForce Ended? : {ev.ForceEnded}```");
            }
        }
    }
}
