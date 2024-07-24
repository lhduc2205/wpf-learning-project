using InventoryManagement.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Core.Context
{
    internal class ApplicationContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=lhduc-3\MSSQLSERVER01;Initial Catalog=inventory_management;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasOne(d => d.ParentDepartment)
                .WithMany(d => d.ChildrenDepartments)
                .HasForeignKey(d => d.ParentDepartmentId);

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Sku)
                .IsUnique(true);
        }

        public override int SaveChanges()
        {
            UpdateBeforeSaveChanges();
            return base.SaveChanges();
        }

        private void UpdateBeforeSaveChanges()
        {
            var entities = ChangeTracker.Entries();

            foreach (var entity in entities)
            {
                if (entity.Entity is BaseEntity baseEntity)
                {
                    bool isNewCreated = entity.State == EntityState.Added;
                    UpdateModifiedBaseEntityDateTime(baseEntity, isNewCreated);
                }

                if (entity.State == EntityState.Deleted)
                {
                    SoftDelete();
                }
            }
        }

        private static void UpdateModifiedBaseEntityDateTime(BaseEntity baseEntity, bool IsCreated)
        {
            DateTime now = DateTime.UtcNow;

            if (IsCreated)
            {
                baseEntity.CreatedAt = now;
            }

            baseEntity.UpdatedAt = now;
        }

        private void SoftDelete()
        {

        }
    }
}
