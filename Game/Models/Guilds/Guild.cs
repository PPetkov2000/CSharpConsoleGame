using Game.Interfaces.Guilds;

namespace Game.Models.Guilds
{
    public class Guild : IGuild
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MembersCount { get; set; } = 0;
        public DateTime CreatedDate { get; set; }
        //public List<GuildMember>? Members { get; set; }
    }
}
