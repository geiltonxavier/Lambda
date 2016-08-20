namespace Lambda.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbEmpresa",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 40),
                        Nome = c.String(nullable: false),
                        NomeFantasia = c.String(nullable: false),
                        CNPJ = c.String(),
                        Telefone = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        DataFundacao = c.DateTime(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbEmpresa");
        }
    }
}
