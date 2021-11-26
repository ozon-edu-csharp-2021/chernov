using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
    [Migration(2)]
    public class EmployeeTable : Migration {
        public override void Up()
        {
            Create
                .Table("employees")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("first_name").AsString().NotNullable()
                .WithColumn("last_name").AsString().NotNullable()
                .WithColumn("middle_name").AsString().NotNullable()
                .WithColumn("email").AsString().NotNullable()
                .WithColumn("clothing_size").AsInt32().NotNullable();
        }
    
        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists employees;");
        }
    }
}