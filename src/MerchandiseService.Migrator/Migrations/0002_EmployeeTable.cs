using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
    [Migration(2)]
    public class EmployeeTable : Migration {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists employees(
                    id BIGSERIAL PRIMARY KEY,
                    first_name TEXT NOT NULL,
                    last_name TEXT NOT NULL,
                    middle_name TEXT NOT NULL,
                    email TEXT NOT NULL,
                    clothing_size INT NOT NULL
                );");
        }
    
        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists employees;");
        }
    }
}