using System;
using CensusAPI.Interfaces;

namespace AdminLogs
{
    public class AdminLogConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public string WebhookURL { get; set; } = "https://discord.com/api/webhooks/";
        public string Username { get; set; } = "Admin Logger";
        public bool PlayerJoin { get; set; } = true;
        public bool PlayerDeath { get; set; } = true;
        public bool RoundStart { get; set; } = true;
        public bool RoundEnd { get; set; } = true;
        public bool OnChat { get; set; } = true;


    }
}
