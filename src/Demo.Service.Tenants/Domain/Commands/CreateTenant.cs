using System;

namespace Demo.Service.Profiles.Domain.Commands
{
    public static class CreateTenant
    {
        public class Command
        {
            public Command(Guid id, string name, string domain, string email)
            {
                Id = id;
                Name = name;
                Domain = domain;
                Email = email;
            }

            public Guid Id { get; }

            public string Name { get; }

            public string Domain { get; }

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
