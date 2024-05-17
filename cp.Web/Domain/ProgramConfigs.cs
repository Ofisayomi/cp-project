namespace cp.Web.Domain;

public class ProgramConfigs : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public override string PartitionKey => "/Title";
    public List<CustomQuestions> CustomQuestions { get; set; }
}
