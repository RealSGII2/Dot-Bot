using System;
using System.Collections.Generic;
using System.Text;

namespace DotBot.Shared
{
    public class BasicGuildInfo
    {
        public string Name { get; set; }
        public string IconURL { get; set; }
        public string Invite { get; set; }
        public IEnumerable<JsonUser> Users { get; set; }
    }
}
