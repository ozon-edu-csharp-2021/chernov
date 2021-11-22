using FluentMigrator;
using FluentMigrator.Builders;

namespace MerchandiseService.Migrator.Migrations
{
    [Migration(1)]
    public class MerchOrderTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_orders")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("status").AsInt32().NotNullable()
                .WithColumn("employee_id").AsInt64().NotNullable()
                .WithColumn("merch_pack").AsInt32().NotNullable()
                .WithColumn("date_of_issue").AsDate().Nullable();
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists merch_orders;");
        }
    }
}