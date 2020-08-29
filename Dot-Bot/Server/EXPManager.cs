using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotBot.Server
{
    public class EXPManager
    {
        public static readonly uint[] levelRequirements = new uint[121];
        private DiscordSocketClient _client;

        public EXPManager(DiscordSocketClient client)
        {
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

        public void AddEXP()
        {

        }
    }
}
