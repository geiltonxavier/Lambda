namespace Lambda.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4DB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbEmpresa", "DataExclusao", c => c.DateTime(nullable: false));
            AddColumn("dbo.tbUsuario", "DataExclusao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbUsuario", "DataExclusao");
            DropColumn("dbo.tbEmpresa", "DataExclusao");
        }
    }
}
