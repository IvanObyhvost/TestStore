namespace TestStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class P : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PhotoForGalleries", "ImageMimeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhotoForGalleries", "ImageMimeType", c => c.String());
        }
    }
}
