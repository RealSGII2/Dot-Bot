using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotBot.Server.Bot
{
    public class CommandModule : ModuleBase<SocketCommandContext>
    {
        [Command("withexp")]
        public async Task WithEXP(uint EXP)
        {

        }

        [Command("withlevel")]
        public async Task WithLevel(ushort level)
        {
            await ReplyAsync($"You should need {DataManager.levelRequirements[level]} EXP for level {level}");
        }

        [Command("ListLevels")]
        public async Task Listlevels()
        {
            var embed = new EmbedBuilder();
            for (int i = 0; i < 5; i++)
            {
                embed.AddField("Level " + i, DataManager.levelRequirements[i]);
            }
            embed.WithTitle("EXP requirements");
            await ReplyAsync(embed: embed.Build());
        }
    }
}
