namespace DevGeniusFinance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account_v11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Account", "Name", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("Account", "Name");
        }
    }
}
