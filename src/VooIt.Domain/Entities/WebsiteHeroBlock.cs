using VooIt.Domain.Enums;

namespace VooIt.Domain.Entities;

public class WebsiteHeroBlock : BaseEntity
{
    public string Headline { get; set; }

    public string Description { get; set; }

    public CtaButton CtaButton { get; set; }

    public string HeroImage { get; set; }

    public decimal ImageAlignement { get; set; }

    public decimal ContentAlignment { get; set; }

}
