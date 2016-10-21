namespace WebApiEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Major : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        MinSat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "Sat", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Major_Id", c => c.Int());
            CreateIndex("dbo.Students", "Major_Id");
            AddForeignKey("dbo.Students", "Major_Id", "dbo.Majors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Major_Id", "dbo.Majors");
            DropIndex("dbo.Students", new[] { "Major_Id" });
            DropColumn("dbo.Students", "Major_Id");
            DropColumn("dbo.Students", "Sat");
            DropTable("dbo.Majors");
        }
    }
}
