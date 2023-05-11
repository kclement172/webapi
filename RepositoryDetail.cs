namespace webapi;

public class RepositoryDetail
{
    public string Name { get; set; }

    public string Language { get; set; }

    public DateOnly CreatedDate { get; set; }

    public int NumberOfBranches { get; set; }
}
