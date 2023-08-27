using VooIt.Domain.Models;

namespace VooIt.Domain.Contracts.Services;

public interface IWebSiteService
{
    Task Create(string id, RequestModel data);

    Task Update(string id, RequestModel data);

    Task Remove(string id);

    Task<RequestModel> GetById(string id);

}
