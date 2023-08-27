using VooIt.Domain.Enums;

namespace VooIt.Domain.Entities;

public class ServicesBlock : BaseEntity
{
    public string HeadlineText { get; set; }

    public ServiceCard ServiceCard { get; set; }
}
