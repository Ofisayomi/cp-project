using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cp.Web.Domain;
using cp.Web.Persistence.DbClient;

namespace cp.Web.Persistence.Repository
{
    public class CustomQuestionsRepository : Respository<CustomQuestions>, ICustomQuestionRepository
    {
        public CustomQuestionsRepository(CosmosClientFactory clientFactory) : base(clientFactory)
        {
        }
    }
}