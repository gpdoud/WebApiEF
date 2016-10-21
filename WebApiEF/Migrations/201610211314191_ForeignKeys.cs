namespace WebApiEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Major_Id", "dbo.Majors");
            DropIndex("dbo.Students", new[] { "Major_Id" });
            RenameColumn(table: "dbo.Students", name: "Major_Id", newName: "MajorId");
            AlterColumn("dbo.Students", "MajorId", c => c.Int(nullable: true));
            CreateIndex("dbo.Students", "MajorId");
            AddForeignKey("dbo.Students", "MajorId", "dbo.Majors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "MajorId", "dbo.Majors");
            DropIndex("dbo.Students", new[] { "MajorId" });
            AlterColumn("dbo.Students", "MajorId", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "MajorId", newName: "Major_Id");
            CreateIndex("dbo.Students", "Major_Id");
            AddForeignKey("dbo.Students", "Major_Id", "dbo.Majors", "Id");
        }
    }
}
