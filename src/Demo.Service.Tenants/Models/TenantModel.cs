using System;

namespace Demo.Service.Tenants.Models
{
    public class TenantModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Domain { get; set; }
    }
}
