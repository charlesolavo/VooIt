using Newtonsoft.Json;
using VooIt.Domain.Contracts.Services;
using VooIt.Domain.Exceptions;
using VooIt.Domain.Models;

namespace VooIt.Domain.Services;

public class WebSiteService : IWebSiteService
{
    private readonly string _basePath = @$"{Directory.GetCurrentDirectory()}/Files/";

    public async Task Create(string id, RequestModel request)
    {
        var file = $@"{_basePath}{id}.json";

        if (File.Exists(file))
        {
            throw new DomainException("Already exist");
        }

        Validate(id, request);

        WriteContentToFile(id, request);

        await Task.FromResult(Task.CompletedTask);
    }

    public async Task<RequestModel> GetById(string id)
    {
        var text = GetContent(id);

        if (string.IsNullOrWhiteSpace(text))
        {
            throw new DomainNotFoundException("not found");
        }

        if (TryParse<RequestModel>(text, out var entity))
        {
            return entity;
        }

        throw new DomainNotFoundException("not found");
    }

    public async Task Remove(string id)
    {
        
        var file = $@"{_basePath}{id}.json";

        if (!File.Exists(file))
        {
            throw new DomainNotFoundException("not found");
        }

        File.Delete(file);

        await Task.FromResult(Task.CompletedTask);
    }

    public async Task Update(string id, RequestModel request)
    {
        Validate(id, request);

        var text = GetContent(id);

        if (string.IsNullOrWhiteSpace(text))
        {
            throw new DomainNotFoundException("not found");
        }

        TryParse<RequestModel>(text, out var entity);

        WriteContentToFile(id, entity);

        await Task.FromResult(Task.CompletedTask);
    }

    private string GetContent(string id)
    {
        var fileName = $"{id.Trim().ToLower()}.json";

        var file = Directory.GetFiles($@"{_basePath}", fileName).FirstOrDefault();

        if (file is null)
        {
            return string.Empty;
        }

        return File.ReadAllText(file ?? string.Empty);
    }

    private void WriteContentToFile(string id, RequestModel request)
    {
        File.WriteAllText($@"{_basePath}{id}.json", SerializeObject(request));
    }

    private bool TryParse<TEntity>(string body, out TEntity entity)
    {
        try
        {
            entity = JsonConvert.DeserializeObject<TEntity>(body);
            return true;
        }
        catch
        {
            entity = default(TEntity);
            return false;
        }
    }

    private string SerializeObject(RequestModel body)
    {
        return JsonConvert.SerializeObject(body);
    }

    private void Validate(string id, RequestModel entity)
    {
        if (!string.Equals(id, entity.WebsiteHeader.Id, StringComparison.OrdinalIgnoreCase))
        {
            throw new DomainException("invalid operation");
        }

        if (!string.Equals(id, entity.WebsiteHeroBlock.Id, StringComparison.OrdinalIgnoreCase))
        {
            throw new DomainException("invalid operation");
        }

        if (!string.Equals(id, entity.ServicesBlock.Id, StringComparison.OrdinalIgnoreCase))
        {
            throw new DomainException("invalid operation");
        }
    }
}
