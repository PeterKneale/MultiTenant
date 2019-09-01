using System;

namespace Demo.Service.Common.Context
{
    public interface IUserContext
    {
        bool IsAuthenticated { get; }

        Guid UserId { get; }
    }
}
