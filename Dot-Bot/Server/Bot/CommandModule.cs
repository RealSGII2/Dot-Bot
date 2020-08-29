using Discord;
using Discord.Commands;
using DotBot.Shared;
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
            await ReplyAsync($"You should need {EXPManager.levelRequirements[level]} EXP for level {level}");
        }

        [Command("ListLevels")]
        public async Task Listlevels()
        {
            var embed = new EmbedBuilder();
            for (int i = 0; i < 5; i++)
            {
                embed.AddField("Level " + i, EXPManager.levelRequirements[i]);
            }
            embed.WithTitle("EXP requirements");
            await ReplyAsync(embed: embed.Build());
        }

        [Command("Myexp")]
        [RequireContext(ContextType.Guild)]
        public async Task ListEXP()
        {
            var collection = EXPManager.EXPDataBase.GetCollection<UserEXP>(Context.Guild.Id.ToLetters());
            var user = collection.FindById(Context.User.Id);

            if (user == null)
            {
                await ReplyAsync("You have no data");
                return;
            }

            await ReplyAsync($"You are level {user.Level} with {user.EXP} XP and {EXPManager.levelRequirements[user.Level + 1] - user.EXP} XP needed to level up!");
        }
    }
}
