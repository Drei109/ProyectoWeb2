namespace ProyectoWeb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnEstado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.pedido_cabecera", "estado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.pedido_cabecera", "estado");
        }
    }
}
