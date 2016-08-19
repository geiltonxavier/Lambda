namespace Lambda.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbUsuario",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 40),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Login = c.String(nullable: false, maxLength: 100),
                        Senha = c.String(nullable: false, maxLength: 50),
                        Grupo = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbUsuario");
        }
    }
}
