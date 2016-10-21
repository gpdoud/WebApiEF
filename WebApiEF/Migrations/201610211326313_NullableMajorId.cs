namespace WebApiEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableMajorId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "MajorId", "dbo.Majors");
            DropIndex("dbo.Students", new[] { "MajorId" });
            AlterColumn("dbo.Students", "Sat", c => c.Int());
            AlterColumn("dbo.Students", "MajorId", c => c.Int());
            CreateIndex("dbo.Students", "MajorId");
            AddForeignKey("dbo.Students", "MajorId", "dbo.Majors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "MajorId", "dbo.Majors");
            DropIndex("dbo.Students", new[] { "MajorId" });
            AlterColumn("dbo.Students", "MajorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Sat", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "MajorId");
            AddForeignKey("dbo.Students", "MajorId", "dbo.Majors", "Id", cascadeDelete: true);
        }
    }
}
