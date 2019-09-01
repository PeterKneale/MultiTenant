using System;

namespace Demo.Service.Profiles.Domain.Commands
{
    public static class GetTenant
    {
        public class Query
        {
            public Query(Guid id)
            {
                Id = id;
            }

            public Query(string domain)
            {
                Domain = domain;
            }

            public Guid Id { get; }

            public string Domain { get; }
        }
        
        public class Validator
        {
            public Validator()
            {
                throw new NotImplementedException();
            }
        }

        public class Handler
        {
            public Handler()
            {
                throw new NotImplementedException();
            }
        }
    }
}
