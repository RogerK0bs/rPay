using rPay.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ApplicationContext : DbContext
{
    public DbSet<Users> Users { get; set; }
    public DbSet<PaymentReceipt> PaymentReceipt { get; set; }
    public DbSet<RespPayment> RespPayment { get; set; }
    public DbSet<UserAction> UserActions { get; set; }
    public DbSet<PayStatus> PayStatus { get; set; }
    public DbSet<REG1> REG1 { get; set; }
    public DbSet<REG1> REG2 { get; set; }
    public DbSet<REG1> REG3 { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>().ToTable("Users");
        modelBuilder.Entity<PaymentReceipt>().ToTable("PaymentReceipt");
        modelBuilder.Entity<RespPayment>().ToTable("RespPayment");
        modelBuilder.Entity<UserAction>().ToTable("UserAction");
        modelBuilder.Entity<PayStatus>().ToTable("PayStatus");
        modelBuilder.Entity<REG1>().ToTable("REG1");
        modelBuilder.Entity<REG2>().ToTable("REG2");
        modelBuilder.Entity<REG3>().ToTable("REG3");
    }
}
