using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CensusAPI.Features;
using DSharp4Webhook;
using DSharp4Webhook.Core;
using DSharp4Webhook.Core.Constructor;

namespace AdminLogs
{
    //Thanks BuildBoy12 from Repo ErrorHandler for this. I don't understand webhook
    public class WebhookHandler
    {
        internal void SendMessage(string EmbedTitle, string FieldTitle, string FieldValue, uint Color)
        {
            AdminLogs.Instance.Webhook.SendMessage(threePartMessage(EmbedTitle, FieldTitle, FieldValue, Color).Build()).Queue((result, isSuccessful) =>
            {
                if (!isSuccessful)
                {
                    Log.Error("Unable to send webhook");
                }
            });
        }

        internal void SendTitle(string Title, uint Color)
        {
            AdminLogs.Instance.Webhook.SendMessage(onePartMessage(Title, Color).Build()).Queue((result, isSuccessful) =>
            {
                if (!isSuccessful)
                {
                    Log.Error("Unable to send webhook");
                }
            });
        }

        private static readonly EmbedBuilder EmbedBuilder = ConstructorProvider.GetEmbedBuilder();
        private static readonly EmbedFieldBuilder FieldBuilder = ConstructorProvider.GetEmbedFieldBuilder();
        private static readonly MessageBuilder MessageBuilder = ConstructorProvider.GetMessageBuilder();

        private MessageBuilder threePartMessage(string EmbedTitle, string FieldTitle, string FieldValue, uint Color)
        {
            EmbedBuilder.Reset();
            FieldBuilder.Reset();
            MessageBuilder.Reset();

            MessageBuilder.Username = AdminLogs.Instance.Config.Username;
            MessageBuilder.AvatarUrl = "https://discordapp.com/assets/1cbd08c76f8af6dddce02c5138971129.png";

            FieldBuilder.Inline = true;
            FieldBuilder.Name = FieldTitle;
            FieldBuilder.Value = FieldValue;
            EmbedBuilder.AddField(FieldBuilder.Build());

            EmbedBuilder.Color = Color;

            EmbedBuilder.Title = EmbedTitle;
            MessageBuilder.AddEmbed(EmbedBuilder.Build());
            return MessageBuilder;
        }

        private MessageBuilder onePartMessage(string Title, uint Color)
        {
            EmbedBuilder.Reset();
            FieldBuilder.Reset();
            MessageBuilder.Reset();

            MessageBuilder.Username = AdminLogs.Instance.Config.Username;
            MessageBuilder.AvatarUrl = "https://discordapp.com/assets/1cbd08c76f8af6dddce02c5138971129.png";

            EmbedBuilder.Title = Title;
            EmbedBuilder.Color = Color;
            MessageBuilder.AddEmbed(EmbedBuilder.Build());
            return MessageBuilder;
        }

    }
}
