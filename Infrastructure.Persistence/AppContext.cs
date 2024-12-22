using Core.Domain.Common;
using Core.Domain.Entities.Ent_Course;
using Core.Domain.Entities.Ent_Order;
using Core.Domain.Entities.Ent_Wallet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppContext : DbContext
    {

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {


        }

        #region Course
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseGroup> CourseGroups { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CourseLevel> CoursesLevel { get; set; }
        public DbSet<CourseStatus> CoursesStatus { get; set; }
        #endregion

        //---------------------------------------------
        #region Order
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<UserDiscountCode> UserDiscountCodes { get; set; }
        #endregion

        //------------------------------------------------
        #region Wallet
        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<WalletType> WalletTypes { get; set; }
        #endregion

        //--------------------------------------------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);


            #region Seed Course

            modelBuilder.Entity<CourseLevel>().HasData(
             new CourseLevel(1, "مقدماتی"),
             new CourseLevel(2, "متوسط"),
             new CourseLevel(3, "پیشرفته"),
             new CourseLevel(4, "خیلی پیشرفته "));


            modelBuilder.Entity<CourseStatus>().HasData(
             new CourseStatus(1, "در حال برگزاری"),
             new CourseStatus(2, "پایان یافته"));


            modelBuilder.Entity<CourseGroup>().HasData(
            new CourseGroup(1, "برنامه نویسی وب"),
            new CourseGroup(2, "برنامه نویسی موبایل"),
            new CourseGroup(3, "طراحی سایت"),
            new CourseGroup(4, "برنامه نویسی ویندوز"),
            new CourseGroup(5, "Asp.net core", 1),
            new CourseGroup(6, "Asp.net MVC", 1),
            new CourseGroup(7, "PHP", 1),
            new CourseGroup(8, "Xamarin", 2),
            new CourseGroup(9, "Android", 2),
            new CourseGroup(10, "HTML", 3),
            new CourseGroup(11, "React", 3),
            new CourseGroup(12, "Jquery", 3));
            #endregion
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                    entry.Entity.DateCreated = DateTime.Now;
            }


            return  await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

    }
}
