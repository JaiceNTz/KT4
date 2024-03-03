
namespace EIOS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EiosEntities : DbContext
    {
        public static EiosEntities _context;
        internal object Items;
        public EiosEntities()
            : base("name=EiosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public static EiosEntities GetContext()
        {
            if (_context == null)
                _context = new EiosEntities();
            return _context;
        }

        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
