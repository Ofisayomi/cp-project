using cp.Web.Domain;
using cp.Web.Persistence.DbClient;

namespace cp.Web.Persistence.Repository;

public class PersonSubmissionRepository : Respository<PersonSubmissions>, IPersonSubmissionRepository
{
    public PersonSubmissionRepository(CosmosClientFactory clientFactory) : base(clientFactory)
    {
    }
}
