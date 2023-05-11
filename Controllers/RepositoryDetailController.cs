using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class RepositoryDetailController : ControllerBase
{

    private readonly ILogger<RepositoryDetailController> _logger;

    public RepositoryDetailController(ILogger<RepositoryDetailController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetRepositoryDetail")]
    public IEnumerable<RepositoryDetail> Get()
    {
        List<RepositoryDetail> items = new List<RepositoryDetail>();

        using (StreamReader r = new StreamReader("RepositoryDatabase.json"))
        {
            string json = r.ReadToEnd();
            items = JsonConvert.DeserializeObject<List<RepositoryDetail>>(json);
        }

        return Enumerable.Range(0, 5).Select(index => new RepositoryDetail
        {
            Name = items[index].Name,
            Language = items[index].Language,
            CreatedDate = items[index].CreatedDate,
            NumberOfBranches = items[index].NumberOfBranches
        })
        .ToArray();
    }
}
