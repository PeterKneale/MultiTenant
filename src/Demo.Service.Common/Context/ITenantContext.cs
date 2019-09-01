using System;

namespace Demo.Service.Common.Context
{
    public interface ITenantContext
    {
        Guid TenantId { get; }
    }
}
