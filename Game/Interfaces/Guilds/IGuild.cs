namespace Game.Interfaces.Guilds
{
    interface IGuild
    {
        string Name { get; set; }
        string? Description { get; set; }
        int? MembersCount { get; set; }
        DateTime CreatedDate { get; set; }
        //List<GuildMember> Members { get; set; }
    }
}
