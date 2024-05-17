using Newtonsoft.Json;

namespace cp.Web.Domain;

public abstract class BaseEntity
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [JsonIgnore]
    public abstract string PartitionKey { get; }
}
