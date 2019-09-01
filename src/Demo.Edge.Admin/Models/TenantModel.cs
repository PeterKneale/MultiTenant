using System;

namespace Demo.Edge.Admin.Models
{
    public class TenantModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Domain { get; set; }

        public int TotalUsers { get; set; }

        public int TotalWidgets { get; set; }
    }
}
