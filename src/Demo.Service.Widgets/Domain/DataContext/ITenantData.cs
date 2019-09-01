using System;

namespace Demo.Service.Widgets.Domain.DataContext
{
    public interface ITenantData
    {
        Guid TenantId { get; set; }
    }
}
