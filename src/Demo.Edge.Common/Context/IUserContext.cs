using System;

namespace Demo.Edge.Common.Context
{
    public interface IUserContext
    {
        bool IsAuthenticated { get; }

        Guid UserId { get; }
    }
}
