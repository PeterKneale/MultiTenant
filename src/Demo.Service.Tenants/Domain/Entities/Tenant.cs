using System;

namespace Demo.Service.Tenants.Domain.DataModel
{
    public class Tenant
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Domain { get; set; }
    }
}
