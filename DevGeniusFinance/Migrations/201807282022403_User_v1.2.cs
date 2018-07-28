namespace DevGeniusFinance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_v12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Balance", "User_CPF", "User");
            DropForeignKey("MonthlyExpense", "User_CPF", "User");
            DropForeignKey("VariableExpense", "User_CPF", "User");
            DropIndex("Balance", new[] { "User_CPF" });
            DropIndex("MonthlyExpense", new[] { "User_CPF" });
            DropIndex("VariableExpense", new[] { "User_CPF" });
            DropPrimaryKey("User");
            AlterColumn("Balance", "User_CPF", c => c.String(maxLength: 128, unicode: false));
            AlterColumn("MonthlyExpense", "User_CPF", c => c.String(maxLength: 128, unicode: false));
            AlterColumn("User", "CPF", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AlterColumn("VariableExpense", "User_CPF", c => c.String(maxLength: 128, unicode: false));
            AddPrimaryKey("User", "CPF");
            CreateIndex("Balance", "User_CPF");
            CreateIndex("MonthlyExpense", "User_CPF");
            CreateIndex("VariableExpense", "User_CPF");
            AddForeignKey("Balance", "User_CPF", "User", "CPF");
            AddForeignKey("MonthlyExpense", "User_CPF", "User", "CPF");     
            AddForeignKey("VariableExpense", "User_CPF", "User", "CPF");
        }
        
        public override void Down()
        {
            DropForeignKey("VariableExpense", "User_CPF", "User");
            DropForeignKey("MonthlyExpense", "User_CPF", "User");
            DropForeignKey("Balance", "User_CPF", "User");
            DropIndex("VariableExpense", new[] { "User_CPF" });
            DropIndex("MonthlyExpense", new[] { "User_CPF" });
            DropIndex("Balance", new[] { "User_CPF" });
            DropPrimaryKey("User");
            AlterColumn("VariableExpense", "User_CPF", c => c.String(maxLength: 128));
            AlterColumn("User", "CPF", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("MonthlyExpense", "User_CPF", c => c.String(maxLength: 128));
            AlterColumn("Balance", "User_CPF", c => c.String(maxLength: 128));
            AddPrimaryKey("User", "CPF");
            CreateIndex("VariableExpense", "User_CPF");
            CreateIndex("MonthlyExpense", "User_CPF");
            CreateIndex("Balance", "User_CPF");
            AddForeignKey("VariableExpense", "User_CPF", "User", "CPF");
            AddForeignKey("MonthlyExpense", "User_CPF", "User", "CPF");
            AddForeignKey("Balance", "User_CPF", "User", "CPF");
        }
    }
}
