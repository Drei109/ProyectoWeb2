namespace ProyectoWeb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedColumnsRestauranteEmpresa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.empresa", "ruc", c => c.String(nullable: false, maxLength: 11));
            DropColumn("dbo.restaurante", "ruc");
        }
        
        public override void Down()
        {
            DropColumn("dbo.empresa", "ruc");
        }
    }
}
