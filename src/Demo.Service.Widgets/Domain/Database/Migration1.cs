using FluentMigrator;

namespace Demo.Service.Widgets.Domain.Database
{
    [Migration(1, "Schema1")]
    public class Migration1 : Migration
    {
        public override void Up()
        {
            Create.Table("Widgets")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("TenantId").AsGuid().NotNullable()
                .WithColumn("Name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Widgets");
        }
    }
}
