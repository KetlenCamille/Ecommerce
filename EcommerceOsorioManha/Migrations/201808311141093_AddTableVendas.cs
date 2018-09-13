namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableVendas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Endereco = c.String(),
                        CarrinhoId = c.String(),
                    })
                .PrimaryKey(t => t.VendaId);
            
            AddColumn("dbo.ItemVendas", "Venda_VendaId", c => c.Int());
            CreateIndex("dbo.ItemVendas", "Venda_VendaId");
            AddForeignKey("dbo.ItemVendas", "Venda_VendaId", "dbo.Vendas", "VendaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVendas", "Venda_VendaId", "dbo.Vendas");
            DropIndex("dbo.ItemVendas", new[] { "Venda_VendaId" });
            DropColumn("dbo.ItemVendas", "Venda_VendaId");
            DropTable("dbo.Vendas");
        }
    }
}
