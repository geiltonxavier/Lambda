namespace Lambda.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7DB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbEmpresa", "DataExclusao", c => c.DateTime());
            AlterColumn("dbo.tbUsuario", "DataExclusao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbUsuario", "DataExclusao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbEmpresa", "DataExclusao", c => c.DateTime(nullable: false));
        }
    }
}
