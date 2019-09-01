using System;

namespace Demo.Service.Profiles.Domain.Commands
{
    public static class GetUsers
    {
        public class Query
        {
            public Query(Guid tenantId)
            {
                TenantId = tenantId;
            }

            public Guid TenantId { get; }
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
