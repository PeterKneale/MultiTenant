using System;

namespace Demo.Service.Tenants.Domain.DataModel
{
    public class User
    {
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
