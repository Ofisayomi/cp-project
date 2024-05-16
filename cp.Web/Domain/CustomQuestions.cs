using Newtonsoft.Json;

namespace cp.Web.Domain;

public class CustomQuestions:BaseEntity
{
    public string QuestionType {get; set;}
    public string Question {get;set;}
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<string>? QuestionValues {get;set;}
    public override string PartitionKey => "/QuestionType";
}
