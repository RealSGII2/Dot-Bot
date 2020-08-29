using DotBot.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Discord.WebSocket;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using Discord.Rest;

namespace DotBot.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuildsController : ControllerBase
    {
        [HttpGet("{guildID}")]
        public async Task<BasicGuildInfo> Get(ulong guildID)
        {
            SocketGuild guild = Bot.BotManager.client.GetGuild(guildID);

            RestInviteMetadata invite = (await guild.GetInvitesAsync()).Where(i => i.IsTemporary == false)?.ElementAt(0);

            BasicGuildInfo guildInfo = new BasicGuildInfo
            {
                Name = guild.Name,
                IconURL = guild.IconUrl ?? "",
                Invite = invite?.ToString() ?? "",
                Users = new Collection<JsonUser> { }
            };
            return guildInfo;
        }
    }
}
