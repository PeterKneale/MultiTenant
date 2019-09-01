namespace Demo.Service.Tenants.Infrastructure
{
    public class Constants
    {
        // signup portal
        // auth: machine        claims: create-tenant

        public const string CreateTenantPolicy = nameof(CreateTenantPolicy);
        public const string CreateTenantClaim = "create-tenant";

        // application portal
        // auth: machine        claims: read-domains
        // auth: user           claims: none
        // auth: manager        claims: manage-users
        // auth: administrator  claims: manage-users, manage-tenant

        public const string ReadDomainsPolicy = nameof(ReadDomainsPolicy);
        public const string ReadDomainsClaim = "read-domains";

        public const string ManageUsersPolicy = nameof(ManageUsersPolicy);
        public const string ManageUserClaim = "manage-users";

        public const string ManageTenantPolicy = nameof(ManageTenantPolicy);
        public const string ManageTenantClaim = "manage-tenant";

        // admin portal
        // auth: machine        claims: read-tenants
        // auth: user           claims: none
        // auth: administrator  claims: manage-tenants

        public const string ReadTenantsPolicy = nameof(ReadTenantsPolicy);
        public const string ReadTenantsClaim = "read-tenants";

        public const string ManageTenantsPolicy = nameof(ManageTenantsPolicy);
        public const string ManageTenantsClaim = "manage-tenants";
    }
}
