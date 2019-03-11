namespace GraphApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GraphDatas",
                c => new
                    {
                        SessionID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 128),
                        Color = c.String(),
                        height = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SessionID, t.Name });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GraphDatas");
        }
    }
}
