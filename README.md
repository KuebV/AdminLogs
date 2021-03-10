# AdminLogs
## Uses Discord Webhooks to log information about the ongoing game
### Some methods do not work! OnChat will show errors, but it does work
Config Example:

```json
{
  "IsEnabled": true,
  "WebhookURL": "https://discord.com/api/webhooks/",
  "Username": "Admin Logger",
  "PlayerJoin": true,
  "RoundStart": true,
  "RoundEnd": true,
  "OnChat": true,
  "PlayerCommands": true
}
```
### Supported Features:
- On Join
- On Round End
- On Player Command
- On Chat Message
- On Round Start
- On Player Death

### To be added:
- On Leave
- On Ban & Kick

### Required Dependencies: (You can find these in the release.tar.gz)
`DSharp4Webhook.dll`

`Newtonsoft.Json.dll`
