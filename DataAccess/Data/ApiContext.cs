
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccess.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
           : base(options)
        {

        }
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Producer> Producer { get; set; } = default!;
        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Warehouse> Warehouse { get; set; } = default!;
        public DbSet<ProductProducer> ProductProducer { get; set; } = default!;
        public DbSet<ProductCostumer> ProductCostumer { get; set; } = default!;
        public DbSet<Purchase> Purchase { get; set; } = default!;
        public DbSet<ProducerOrder> ProducerOrder { get; set; } = default!;
        public DbSet<Entry> Entry { get; set; } = default!;
        public DbSet<Sale> Sale { get; set; } = default!;
        public DbSet<CostumerOrder> CostumerOrder { get; set; } = default!;
        public DbSet<StockReport> StockReport { get; set; } = default!;
        //public DbSet<User> users { get; set; } = default!;
        public DbSet<User> user { get; set; } = default!;
        public DbSet<Review> review { get; set; } = default!;
        public DbSet<Role> role{ get; set; } = default!;
        public DbSet<Foresight> foresight { get; set; } = default!;
        public DbSet<ForesightProducer> foresightProducer { get; set; } = default!;
        public DbSet<Costumer> costumers { get; set; } = default!;
        public DbSet<CostumersContact> costumersContacts { get; set; } = default!;
        public DbSet<Employee> employee { get; set; } = default!;
        

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                //Avoid duplicated key values //

            //Avoid duplicated emails
            modelBuilder.Entity<User>().HasIndex(user => user.Email).IsUnique();
            //Avoid duplicated cedulas
            modelBuilder.Entity<Costumer>().HasIndex(costumer => costumer.cedulaJuridica).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(employee => employee.cedula).IsUnique();
            modelBuilder.Entity<Producer>().HasIndex(producer => producer.Cedula).IsUnique();

            //Avoid duplicated codes for products
            modelBuilder.Entity<Product>().HasIndex(product => product.Code).IsUnique();

            //Avoid duplicated codes for warehouses
            modelBuilder.Entity<Warehouse>().HasIndex(warehouse => warehouse.Code).IsUnique();

                // Relations //
              //One to one
            //Employee user
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.user)
                .WithOne(u => u.employee)
                .HasForeignKey<Employee>(e => e.idUser);

            //Costumer user
            modelBuilder.Entity<Costumer>()
                .HasOne(c => c.user)
                .WithOne(u => u.costumer)
                .HasForeignKey<Costumer>(c => c.userId);

              //One to many
            //Costumer contacts
            modelBuilder.Entity<Costumer>()
                .HasMany(c => c.costumersContacts)
                .WithOne(cc => cc.costumer)
                .HasForeignKey(cc => cc.costumerId);

            modelBuilder.Entity<CostumersContact>()
                .HasOne(cc => cc.costumer)
                .WithMany(c => c.costumersContacts)
                .HasForeignKey(cc => cc.costumerId);

            //User
            modelBuilder.Entity<User>()
                .HasOne(u => u.role)
                .WithMany(r => r.users)
                .HasForeignKey(u => u.idRole);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.users)
                .WithOne(u => u.role)
                .HasForeignKey(u => u.idRole);

            //Product

            modelBuilder.Entity<Product>()
            .HasOne(product => product.Category)
            .WithMany(category => category.products)
            .HasForeignKey(k => k.CategoryId);

            //Review

            modelBuilder.Entity<Review>()
            .HasOne(review => review.product)
            .WithMany(product => product.reviews)
            .HasForeignKey(k => k.ProductId);

            modelBuilder.Entity<Review>()
            .HasOne(review => review.costumer)
            .WithMany(costumer => costumer.reviews)
            .HasForeignKey(k => k.CostumerId);

            modelBuilder.Entity<Review>()
           .Property(a => a.ReviewDate)
           .HasColumnType("date");

            //StockReport

            modelBuilder.Entity<StockReport>()
                .HasOne(stockReport => stockReport.Product)
                .WithMany(product => product.stocks)
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<StockReport>()
            .Property(a => a.CambioFecha)
            .HasColumnType("date");

            //ProducerOrder

            modelBuilder.Entity<ProducerOrder>()
            .HasOne(producerorder => producerorder.Producer)
            .WithMany(producer => producer.producersorders)
            .HasForeignKey(k => k.ProducerId);

            modelBuilder.Entity<ProducerOrder>()
            .Property(e => e.ConfirmedDate)
            .HasColumnType("date");

            modelBuilder.Entity<ProducerOrder>()
            .Property(a => a.PaidDate)
            .HasColumnType("date");

            modelBuilder.Entity<ProducerOrder>()
            .Property(a => a.DeliveredDate)
            .HasColumnType("date");

            //Foresight
            modelBuilder.Entity<Foresight>()
                .HasOne(foresight => foresight.product)
                .WithMany(product => product.foresights)
                .HasForeignKey(k=>k.IdProduct);

            //ForesightProducer
            modelBuilder.Entity<ForesightProducer>()
                .HasOne(foresightP => foresightP.foresight)
                .WithMany(foresight => foresight.Foresightproducers)
                .HasForeignKey(k => k.ForesightId);

            modelBuilder.Entity<ForesightProducer>()
                .HasOne(ForesightP => ForesightP.producer)
                .WithMany(producer => producer.foresightProducers)
                .HasForeignKey(k => k.ProducerId);

            //Purchase

            modelBuilder.Entity<Purchase>()
            .HasOne(purchase => purchase.ProducerOrder)
            .WithMany(producerorder => producerorder.purchases)
            .HasForeignKey(k => k.ProducerOrderId);

            modelBuilder.Entity<Purchase>()
            .HasOne(purchase => purchase.Product)
            .WithMany(product => product.purchases)
            .HasForeignKey(k => k.ProductId);

            //Entry

            modelBuilder.Entity<Entry>()
            .HasOne(entry => entry.ProducerOrder)
            .WithMany(producerorder => producerorder.entries)
            .HasForeignKey(k => k.ProducerOrderId);

            modelBuilder.Entity<Entry>()
           .HasOne(entry => entry.Product)
           .WithMany(product => product.entries)
           .HasForeignKey(k => k.ProductId);

            modelBuilder.Entity<Entry>()
           .HasOne(entry => entry.Warehouse)
           .WithMany(warehouse => warehouse.entries)
           .HasForeignKey(k => k.WarehouseId);

            modelBuilder.Entity<Entry>()
            .Property(e => e.EntryDate)
            .HasColumnType("date");


            //CostumerOrder

            modelBuilder.Entity<CostumerOrder>()
            .HasOne(costumerorder => costumerorder.Costumer)
            .WithMany(costumer => costumer.costumersorders)
            .HasForeignKey(k => k.CostumerId);

            modelBuilder.Entity<CostumerOrder>()
            .Property(e => e.ConfirmedDate)
            .HasColumnType("date");

            modelBuilder.Entity<CostumerOrder>()
            .Property(a => a.PaidDate)
            .HasColumnType("date");

            modelBuilder.Entity<CostumerOrder>()
            .Property(a => a.DeliveredDate)
            .HasColumnType("date");

            //Sale

            modelBuilder.Entity<Sale>()
            .HasOne(sale => sale.CostumerOrder)
            .WithMany(costumerorder => costumerorder.sales)
            .HasForeignKey(k => k.CostumerOrderId);

            modelBuilder.Entity<Sale>()
            .HasOne(sale => sale.Product)
            .WithMany(product => product.sales)
            .HasForeignKey(k => k.ProductId);


            //User

            modelBuilder.Entity<User>()
            .HasOne(user => user.role)
            .WithMany(role => role.users)
            .HasForeignKey(k => k.idRole);

              //Many to many

            //ProductProducer

            modelBuilder.Entity<ProductProducer>()
            .HasKey(ch => new { ch.ProductId, ch.ProducerId });

            modelBuilder.Entity<ProductProducer>()
                .HasOne(ch => ch.Product)
                .WithMany(c => c.productsproducers)
                .HasForeignKey(ch => ch.ProductId);

            modelBuilder.Entity<ProductProducer>()
                .HasOne(ch => ch.Producer)
                .WithMany(h => h.productsproducers)
                .HasForeignKey(ch => ch.ProducerId);

            //ProductCostumer

            modelBuilder.Entity<ProductCostumer>()
            .HasKey(ch => new { ch.ProductId, ch.CostumerId });

            modelBuilder.Entity<ProductCostumer>()
                .HasOne(ch => ch.Product)
                .WithMany(c => c.productscostumers)
                .HasForeignKey(ch => ch.ProductId);

            modelBuilder.Entity<ProductCostumer>()
                .HasOne(ch => ch.Costumer)
                .WithMany(h => h.productscostumers)
                .HasForeignKey(ch => ch.CostumerId);

        }


     }
}
