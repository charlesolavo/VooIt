using VooIt.Domain.Entities;

namespace VooIt.Domain.Models
{
    public class RequestModel
    {
        public string Id { get; set; }

        public WebsiteHeader WebsiteHeader { get; set; }

        public WebsiteHeroBlock WebsiteHeroBlock { get; set; }

        public ServicesBlock ServicesBlock { get; set; }
    }
}
