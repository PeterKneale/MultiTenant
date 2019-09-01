using Demo.Service.Widgets.Domain.DataContext;
using System;

namespace Demo.Service.Widgets.Domain.DataModel
{
    public class Widget : ITenantData
    {
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public string Name { get; set; }
    }
}
