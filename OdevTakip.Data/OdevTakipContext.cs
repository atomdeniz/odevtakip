using Microsoft.EntityFrameworkCore;
using OdevTakip.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdevTakip.Data
{
    public class OdevTakipContext : DbContext
    {

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }
        public DbSet<Homework> Homeworks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=OdevTakipDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Article> Articles { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // İlişkileri kuruyoruz one-to-many olarak.
        //    modelBuilder.Entity<Article>()
        //        .HasRequired<Category>(x => x.Category)
        //        .WithMany(x => x.Articles)
        //        .HasForeignKey(x => x.CategoryId);

        //    modelBuilder.Entity<Article>()
        //        .HasRequired<User>(x => x.User)
        //        .WithMany(x => x.Articles)
        //        .HasForeignKey(x => x.UserId);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
