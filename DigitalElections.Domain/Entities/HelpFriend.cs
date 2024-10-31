using DigitalElections.Domain.Entities;
using DigitalElections.Domain.Entities.Base;

namespace DigitalElections.Domain.Entities;

public class HelpFriend : BaseEntity
{
    public long PersonId { get; set; }
    public long UserId { get; set; }
    public string WhyHelp { get; set; } = string.Empty;

    public Users Users { get; set; }
    public Person Person { get; set; }
}