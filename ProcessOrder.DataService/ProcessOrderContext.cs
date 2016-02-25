﻿using System.Data.Entity;
using ProcessOrder.Data.Model;

namespace ProcessOrder.Data
{
    public class ProcessOrderContext : DbContext
    {
        public DbSet<OrderBase> Orders { get; set; }
        private const string ConnectionString = "Data Source=f2vj6ze6i0.database.windows.net;Initial Catalog=sample;User ID=test;Password=Sqlsql-1";
        public ProcessOrderContext() : base(ConnectionString) {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderBase>().ToTable("Orders");
        }
    }
}