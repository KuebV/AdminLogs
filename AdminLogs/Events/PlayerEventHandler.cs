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
            IPlayer player = ev.player;
            Player api = new Player(player);
            if (AdminLogs.Instance.Config.PlayerJoin)
            {
                wb.SendMessage("Player Joined", "Username", $"```{api.Nickname}({api.SteamID})```");
            }
            Log.Info("Player Joined");
        }

        [CensusPlayerEvent(CensusPlayerEventType.SendingChatMessage)]
        public static void OnChat(SendingChatMessageEventArgs ev)
        {
            WebhookHandler wb = new WebhookHandler();
            if (AdminLogs.Instance.Config.OnChat)
            {
                if (!ev.Message.StartsWith("/"))
                {
                    wb.SendMessage("Chat Message", $"User : {ev.Player.Nickname}", ev.Message);
                }
            }
            if (AdminLogs.Instance.Config.PlayerCommands)
            {
                if (ev.Message.StartsWith("/"))
                {
                    wb.SendMessage("Player Command", $"User : {ev.Player.Nickname}", ev.Message);
                }
            }

        }

    }
}
