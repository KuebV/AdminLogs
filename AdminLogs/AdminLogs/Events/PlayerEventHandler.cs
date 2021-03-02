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
    public class PlayerEventHandler : IScript
    {

        [PlayerEvent(PlayerEventType.OnPlayerJoinFinal)]
        public static void OnJoin(PlayerJoinFinalEvent ev)
        {
            WebhookHandler wb = new WebhookHandler();
            Player player = Player.Get(ev.player);
            if (AdminLogs.Instance.Config.PlayerJoin)
            {
                wb.SendMessage("Player Joined", "Username", $"```{player.Nickname} ({player.SteamID})```");
            }
            Log.Info("Player Joined");
        }

        [PlayerEvent(PlayerEventType.OnPlayerLeave)]
        public static void OnLeave(PlayerLeaveEvent ev)
        {
            //I'm either stupid, or this plain doesnt work
            //Player player = Player.Get(ev.player);
            //WebhookHandler wb = new WebhookHandler();
            //if (AdminLogs.Instance.Config.PlayerLeave)
            //{
            //    wb.SendMessage("Player Left", "Username", $"```{player.Nickname}```");
            //}
            Log.Info("Player Left");
        }

        [PlayerEvent(PlayerEventType.OnPlayerDeath)]
        public static void OnDied(PlayerDeathEvent ev)
        {
            WebhookHandler wb = new WebhookHandler();
            Player victim = (Player)ev.victim;
            if (AdminLogs.Instance.Config.PlayerDeath)
            {
                wb.SendMessage("Played Died", "Player", $"```Player : {victim.Nickname}");
            }
            Log.Info("Player Died");
        }

        [CensusPlayerEvent(CensusPlayerEventType.SendingChatMessage)]
        public static void OnChat(SendingChatMessageEventArgs ev)
        {
            WebhookHandler wb = new WebhookHandler();
            if (AdminLogs.Instance.Config.OnChat)
            {
                wb.SendMessage("Chat Message", $"User : {ev.Player.Nickname}", ev.Message);
            }

        }
    }
}
