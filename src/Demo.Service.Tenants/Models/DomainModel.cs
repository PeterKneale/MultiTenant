using System;

namespace Demo.Service.Tenants.Models
{
    public class DomainModel
    {
        public Guid TenantId { get; set; }

        public string TenandName { get; set; }

        public string Domain { get; set; }
    }
}
