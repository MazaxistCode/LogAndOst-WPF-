﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogAndOst_WPF_.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LogAndOstEntities : DbContext
    {
        private static LogAndOstEntities _context;
        public LogAndOstEntities()
            : base("name=LogAndOstEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public static LogAndOstEntities GetContext()
        {
            if (_context == null)
                _context = new LogAndOstEntities();
            return _context;
        }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
