using Microsoft.EntityFrameworkCore;
using OnLineStore.Entities;

namespace OnLineStore.Models
{
    public class taskDbContext :DbContext 
    {
        public taskDbContext(DbContextOptions dbContextOptions):base(dbContextOptions) 
        {

        }
     
        public virtual DbSet<Category> categories { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<CatProp> catProps { get; set; }
        public virtual DbSet<DevProp> devProps { get; set; }
        public virtual DbSet<Property> properties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Task;Trusted_Connection=True;");
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CatProp>().HasKey(sc => new { sc.categoryId, sc.propertyId });

            //many to many  Category and  Property
            modelBuilder.Entity<CatProp>()
                .HasOne<Category>(sc => sc.category)
                .WithMany(s => s.catProps)
                .HasForeignKey(sc => sc.categoryId);

            modelBuilder.Entity<CatProp>()
                .HasOne<Property>(sc => sc.property)
                .WithMany(s => s.catProps)
                .HasForeignKey(sc => sc.propertyId);


            //many to many  Device and  Property
            modelBuilder.Entity<DevProp>().HasKey(sc => new { sc.deviceId, sc.propertyId });

            modelBuilder.Entity<DevProp>()
                .HasOne<Device>(sc => sc.device)
                .WithMany(s => s.devProps)
                .HasForeignKey(sc => sc.deviceId);

            modelBuilder.Entity<DevProp>()
                .HasOne<Property>(sc => sc.property)
                .WithMany(s => s.devProps)
                .HasForeignKey(sc => sc.propertyId);

           


        }
    }
}
