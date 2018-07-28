namespace DevGeniusFinance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserCPF = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("devgeniusadm.User", t => t.UserCPF)
                .Index(t => t.UserCPF);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Account", "UserCPF", "devgeniusadm.User");
            DropIndex("Account", new[] { "UserCPF" });
            DropTable("Account");
        }
    }
}
