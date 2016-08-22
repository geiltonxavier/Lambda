namespace Lambda.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6DB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbEmpresa", "DataFundacao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbEmpresa", "DataFundacao", c => c.DateTime());
        }
    }
}
