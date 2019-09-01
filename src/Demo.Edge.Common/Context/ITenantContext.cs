using System;

namespace Demo.Edge.Common.Context
{
    public interface ITenantContext
    {
        Guid TenantId { get; }
    }
}
