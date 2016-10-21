namespace WebApiEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyAnnotations : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Majors", newName: "Major");
            RenameTable(name: "dbo.Students", newName: "Student");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Student", newName: "Students");
            RenameTable(name: "dbo.Major", newName: "Majors");
        }
    }
}
