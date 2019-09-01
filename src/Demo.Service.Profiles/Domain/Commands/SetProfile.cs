using System;

namespace Demo.Service.Profiles.Domain.Commands
{
    public static class SetProfile
    {
        public class Command
        {
            public Command(Guid id, string biography)
            {
                Id = id;
                Biography = biography;
            }

            public Guid Id { get; }

            public string Biography { get; }
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
