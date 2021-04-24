using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using webBuy_with_Rest_API.Models;

namespace webBuy_with_Rest_API.Models
{
    public class webBuyEntities : DbContext
    {
        //1. No Parameter
        //2. Database name
        //3. using connection string name

        public webBuyEntities() : base("name=CFwebBuyContext")
        {
            //1. new CreateDatabaseIfNotExists<InventoryDbContext>();
            //2. new DropCreateDatabaseIfModelChanges<InventoryDbContext>();
            //3. new DropCreateDatabaseAlways<InventoryDbContext>();
            //4. Custom

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<webBuyEntities>());

            //For Migration
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<webBuyEntities, webBuy_with_Rest_API.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Entity Configuration
            modelBuilder.Entity<AdminDiscount>().ToTable("AdminDiscount")
                                           .HasKey<int>(k => k.adminDiscountId);
            modelBuilder.Entity<Category>().ToTable("Category")
                                           .HasKey<int>(k => k.categoryId);
            modelBuilder.Entity<Comission>().ToTable("Comission")
                                           .HasKey<int>(k => k.comissionId);
            modelBuilder.Entity<Contact>().ToTable("Contact")
                                           .HasKey<int>(k => k.contactId);
            modelBuilder.Entity<Invoice>().ToTable("Invoice")
                                           .HasKey<int>(k => k.invoiceId);
            modelBuilder.Entity<Order>().ToTable("Order")
                                           .HasKey<int>(k => k.orderId);
            modelBuilder.Entity<Payment>().ToTable("Payment")
                                           .HasKey<int>(k => k.paymentId);
            modelBuilder.Entity<Product>().ToTable("Product")
                                           .HasKey<int>(k => k.productId);
            modelBuilder.Entity<Review>().ToTable("Review")
                                           .HasKey<int>(k => k.reviewId);
            modelBuilder.Entity<Shop>().ToTable("Shop")
                                           .HasKey<int>(k => k.shopId);
            modelBuilder.Entity<ShopDiscount>().ToTable("ShopDiscount")
                                           .HasKey<int>(k => k.shopDiscountId);
            modelBuilder.Entity<User>().ToTable("User")
                                           .HasKey<int>(k => k.userId);
            modelBuilder.Entity<Withdraw>().ToTable("Withdraw")
                                           .HasKey<int>(k => k.withdrawId);



            //Property
            modelBuilder.Entity<AdminDiscount>().Property(p => p.adminDiscountId).HasColumnName("adminDiscountId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();
            modelBuilder.Entity<Category>().Property(p => p.categoryId).HasColumnName("categoryId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();
            modelBuilder.Entity<Comission>().Property(p => p.comissionId).HasColumnName("comissionId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();
            modelBuilder.Entity<Contact>().Property(p => p.contactId).HasColumnName("contactId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();
            modelBuilder.Entity<Invoice>().Property(p => p.invoiceId).HasColumnName("invoiceId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();
            modelBuilder.Entity<Order>().Property(p => p.orderId).HasColumnName("orderId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();
            modelBuilder.Entity<Payment>().Property(p => p.paymentId).HasColumnName("paymentId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.productId).HasColumnName("productId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();
            modelBuilder.Entity<Review>().Property(p => p.reviewId).HasColumnName("reviewId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();
            modelBuilder.Entity<Shop>().Property(p => p.shopId).HasColumnName("shopId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();
            modelBuilder.Entity<ShopDiscount>().Property(p => p.shopDiscountId).HasColumnName("shopDiscountId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();
            modelBuilder.Entity<User>().Property(p => p.userId).HasColumnName("userId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();
            modelBuilder.Entity<Withdraw>().Property(p => p.withdrawId).HasColumnName("withdrawId")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();



        }

        public DbSet<AdminDiscount> AdminDiscounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comission> Comissions { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopDiscount> ShopDiscounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Withdraw> Withdraws { get; set; }
    }
}