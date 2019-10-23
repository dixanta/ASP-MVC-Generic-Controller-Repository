namespace ArjavWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enquiries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        ContactNo = c.String(),
                        EnquiryDate = c.DateTime(nullable: false),
                        EnquiryStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EnquiryStatus", t => t.EnquiryStatusId, cascadeDelete: true)
                .Index(t => t.EnquiryStatusId);
            
            CreateTable(
                "dbo.EnquiryStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enquiries", "EnquiryStatusId", "dbo.EnquiryStatus");
            DropIndex("dbo.Enquiries", new[] { "EnquiryStatusId" });
            DropTable("dbo.EnquiryStatus");
            DropTable("dbo.Enquiries");
        }
    }
}
