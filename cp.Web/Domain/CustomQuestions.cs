using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace cp.Web.Domain;

public class CustomQuestions : BaseEntity
{
    [Required(AllowEmptyStrings = false)]
    public string QuestionType { get; set; }
    [Required(AllowEmptyStrings = false)]
    public string Question { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<string>? QuestionValues { get; set; }
    public override string PartitionKey => "/QuestionType";
}
