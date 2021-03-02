using CensusAPI.Features;
using System;
using DSharp4Webhook.Core;
using CensusCore;

namespace AdminLogs
{
    public class AdminLogs : Plugin<AdminLogConfig>
    {
        public override string Name => "AdminLogs";

        public override Version Version => new Version(1, 0, 0);

        public override string Author => "KuebV";

        public static AdminLogs Instance { get; private set; }

        public IWebhook Webhook;

        public override void Disable()
        {
            Instance = null;
        }

        public override void Enable()
        {
            Instance = this;

            CensusCore.CensusCore.InjectEvents();

            Webhook = WebhookProvider.CreateStaticWebhook(Config.WebhookURL);
            Log.Info($"Config Value : " +
                $"\nURL : {Instance.Config.WebhookURL}");
        }
    }
}
