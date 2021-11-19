using FluentMigrator;
using FluentMigrator.Builders;

namespace MerchandiseService.Migrator.Migrations
{
    [Migration(1)]
    public class MerchOrderTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists merch_orders(
                    id BIGSERIAL PRIMARY KEY,
                    status INT NOT NULL,
                    employee_id INT NOT NULL,
                    merch_pack INT NOT NULL,
                    date_of_issue date
                );");
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists merch_orders;");
        }
    }
}