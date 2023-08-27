using VooIt.Domain.Enums;

namespace VooIt.Domain.Entities;

public class WebsiteHeader : BaseEntity
{
    public string BusinessName { get; set; }

    public bool Logo { get; set; }

    public string Navigation { get; set; }

    public CtaButton CtaButton { get; set; }
}
