using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DotBot.Server.Data;
using DotBot.Shared;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace DotBot.Server
{
    public class EXPManager
    {
        public static readonly uint[] levelRequirements = new uint[121];
        private DiscordSocketClient _client;
        public static LiteDatabase guildDataBase;
        public static LiteDatabase EXPDataBase;

        public EXPManager(DiscordSocketClient client)
        {
            var execPath = AppDomain.CurrentDomain.BaseDirectory;
            guildDataBase = new LiteDatabase(@$"{execPath}\GuildData.db");
            EXPDataBase = new LiteDatabase(@$"{execPath}\EXPData.db");
            _client = client;
            uint lastLevelReq = 0;
            for (int i = 0; i < 120; i++)
            {
                var newLevelReq = 5 * (i * i) + 50 * i + 100;
                uint currentLevelReq = lastLevelReq + (uint)newLevelReq;
                levelRequirements[i + 1] = currentLevelReq;
                lastLevelReq = currentLevelReq;
            }
        }

        public static async Task AddEXP(SocketCommandContext context)
        {
            var collection = EXPDataBase.GetCollection<UserEXP>(context.Guild.Id.ToLetters());
            var user = collection.FindById(context.User.Id) ?? new UserEXP();

            user.EXP += 20;
            if (user.EXP >= levelRequirements[user.Level + 1])
            {
                user.Level++;
                await context.Channel.SendMessageAsync($"Congrats {context.User.Mention} for leveling up!");
            }

            collection.Upsert(context.User.Id, user);
        }


    }

    public static class Converter
    {
        private const string letters = "ABCDEFGHIJ";

        public static string ToLetters(this ulong number)
        {
            string result = "";
            foreach (char c in number.ToString())
            {
                var digit = byte.Parse(c.ToString());
                result += letters[digit];
            }
            return result;
        }
    }
}
