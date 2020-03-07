namespace Voerum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publicRecipe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "IsPublic", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "IsPublic", c => c.Byte(nullable: false));
        }
    }
}
