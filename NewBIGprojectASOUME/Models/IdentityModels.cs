﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NewBIGprojectASOUME.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Liking> Likeses { get; set; }
        public ICollection<Liking> Likees { get; set; }

        public ApplicationUser()
        {
            Likeses = new Collection<Liking>();
            Likees = new Collection<Liking>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Band> Bands { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<ArtistsBandsConnection> ArtistsBandsConnections { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Liking> Likings { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtistsBandsConnection>()
                .HasRequired(u => u.Artist)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Likeses)
                .WithRequired(f => f.Likee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Likees)
                .WithRequired(f => f.Likes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ArtistsBandsConnection>()
                .HasRequired(a => a.Band)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Like>()
                .HasRequired(a => a.Band)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}