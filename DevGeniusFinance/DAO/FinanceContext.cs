namespace DevGeniusFinance.DAO
{
    using DevGeniusFinance.Entidades;
    using System.Data.Entity;
    

    public partial class FinanceContext : DbContext
    {
        public FinanceContext()
            : base("name=Finance")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Balance> Balance { get; set; }
        public virtual DbSet<ExpenseCategory> ExpenseCategory { get; set; }
        public virtual DbSet<FormOfPayment> FormOfPayment { get; set; }
        public virtual DbSet<MonthlyExpense> MonthlyExpense { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<VariableExpense> VariableExpense { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Properties<string>()
            //    .Configure(s => s.HasColumnType("varchar"));

            modelBuilder.Entity<Balance>()
                .HasMany(e => e.FormOfPayment)
                .WithOptional(e => e.Balance)
                .HasForeignKey(e => e.Balance_Id);

            modelBuilder.Entity<ExpenseCategory>()
                .HasMany(e => e.MonthlyExpense)
                .WithOptional(e => e.ExpenseCategory)
                .HasForeignKey(e => e.ExpenseCategory_Id);

            modelBuilder.Entity<FormOfPayment>()
                .HasMany(e => e.MonthlyExpense)
                .WithOptional(e => e.FormOfPayment)
                .HasForeignKey(e => e.FormOfPayment_Id);

            modelBuilder.Entity<FormOfPayment>()
                .HasMany(e => e.VariableExpense)
                .WithOptional(e => e.FormOfPayment)
                .HasForeignKey(e => e.FormOfPayment_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Balance)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_CPF);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MonthlyExpense)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_CPF);

            modelBuilder.Entity<User>()
                .HasMany(e => e.VariableExpense)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_CPF);
        }
    }
}
