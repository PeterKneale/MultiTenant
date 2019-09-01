using System;

namespace Demo.Service.Profiles.Domain.Commands
{
    public static class GetUser
    {
        public class Query
        {
            public Query(Guid id)
            {
                Id = id;
            }

            public Query(string email)
            {
                Email = email;
            }

            public Guid Id { get; }

            public string Email { get; }
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
