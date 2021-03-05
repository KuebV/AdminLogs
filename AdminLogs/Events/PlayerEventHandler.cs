using CensusAPI.Enums;
using CensusAPI.Features;
using CensusCore.Events.Attributes;
using CensusCore.Events.EventArgs.Player;
using PluginFramework.Attributes;
using PluginFramework.Classes;
using PluginFramework.Events.EventsArgs;
using VirtualBrightPlayz.SCP_ET.NetworkAuth;
using VirtualBrightPlayz.SCP_ET.ServerGroups;
using VirtualBrightPlayz.SCP_ET.NPCs.Interfaces;
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
                wb.SendMessage("Player Joined", "Username", $"```{api.Nickname}```", 8569950);
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
                    wb.SendMessage("Chat Message", $"User : {ev.Player.Nickname}", ev.Message, 13419610);
                }
            }
            if (AdminLogs.Instance.Config.PlayerCommands)
            {
                if (ev.Message.StartsWith("/"))
                {
                    wb.SendMessage("Player Command", $"User : {ev.Player.Nickname}", ev.Message, 13419610);
                }
            }

        }

        [PlayerEvent(PlayerEventType.OnPlayerClassChange)]
        public static void OnChangeClass(PlayerClassChangeEvent ev)
        {
            // In Locally hosted servers, often the chat would be spammed with respawns from host.
            if (ev.player.PlayerName.Equals("Host"))
                return;

            WebhookHandler wb = new WebhookHandler();
            if (ev.newClassId == 0 && ev.prevClassId == 1)
            {
                wb.SendTitle($"{ev.player.PlayerName} has died!", 12874076);
            }

            if (ev.newClassId == 1 && ev.prevClassId == 0)
            {
                wb.SendTitle($"{ev.player.PlayerName} has respawned!", 12874076);
            }
        }

        }



    }

