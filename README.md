# AdminLogs
## Uses Discord Webhooks to log information about the ongoing game
### Some methods do not work! OnChat will show errors, but it does work
Config Example:

```json
{
  "IsEnabled": true,
  "WebhookURL": "https://discord.com/api/webhooks/",
  "Username": "Logger",
  "PlayerJoin": true,
  "PlayerDeath": true,
  "RoundStart": true,
  "RoundEnd": true,
  "OnChat": true
}
```

### Required Dependencies: (You can find these in the release.tar.gz)
`DSharp4Webhook.dll`

`Newtonsoft.Json.dll`
