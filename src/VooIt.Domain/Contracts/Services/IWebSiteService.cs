using VooIt.Domain.Models;

namespace VooIt.Domain.Contracts.Services;

public interface IWebSiteService
{
    Task Create(string id, RequestModel data);

    Task Update(string id, string sectionID, RequestModel request);

    Task Remove(string id, string sectionID);

    Task<RequestModel> GetById(string id);

}
