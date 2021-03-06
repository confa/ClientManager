﻿using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BinaryStudio.ClientManager.DomainModel.DataAccess
{
    public class EfDataContext : DbContext
    {
        public EfDataContext()
#if DEBUG
            : base("ClientManager")
#endif
        {
            collections = new Dictionary<Type, object>
                {
                    {typeof(Entities.MailMessage), MailMessages},
                    {typeof(Entities.Person), Persons},
                    {typeof(Entities.Inquiry), Inquiries}
                };
        }

        public DbSet<Entities.Person> Persons { get; set; }

        public DbSet<Entities.MailMessage> MailMessages { get; set; }

        public DbSet<Entities.Inquiry> Inquiries { get; set; }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            return collections[typeof(T)] as DbSet<T>;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        //    EfConnectionFactory.Enable(true);

#if DEBUG
            Database.SetInitializer(new CreateDatabaseIfNotExists<EfDataContext>());
#endif
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<EfDataContext, EfMigrationConfiguration>());
        }

        private readonly IDictionary<Type, object> collections;
    }
}