namespace ArjavWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnquiryStatusChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnquiryStatus", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EnquiryStatus", "CreatedDate");
        }
    }
}
