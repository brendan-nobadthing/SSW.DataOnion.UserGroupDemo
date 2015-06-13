namespace SSW.DataOnion.UserGroupDemo.VanillaEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrolments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        School_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.School_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.School_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 111),
                        LastName = c.String(maxLength: 222),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrolments", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Enrolments", "School_Id", "dbo.Schools");
            DropIndex("dbo.Enrolments", new[] { "Student_Id" });
            DropIndex("dbo.Enrolments", new[] { "School_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Schools");
            DropTable("dbo.Enrolments");
        }
    }
}
