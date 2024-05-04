using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bazo.Models;

namespace Bazo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Bazo.Models.Category> Category { get; set; } = default!;
        public DbSet<Bazo.Models.Product> Product { get; set; } = default!;
        public DbSet<Bazo.Models.ShoppigCart> ShoppigCart { get; set; } = default!;
        public DbSet<Bazo.Models.ApplicationUser> ApplicationUser { get; set; } = default!;
        public DbSet<Bazo.Models.Order> Order { get; set; } = default!;
        public DbSet<Bazo.Models.CartItem> CartItem { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Fantasy", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Horror", DisplayOrder = 5 },
                new Category { Id = 6, Name = "Romance", DisplayOrder = 6 },
                new Category { Id = 7, Name = "Mystery", DisplayOrder = 7 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "The Lord of the Rings",
                    Author = "J.R.R. Tolkien",
                    ISBN = "978-0-395-19395-7",
                    Description = "The Lord",
                    Price = 10.00,
                    CategoryId = 2,
                    ImageUrl = "https://cdn.kobo.com/book-images/8fcc4405-1f93-4e7b-8cdf-7516fbdd26f7/353/569/90/False/the-lord-of-the-rings-the-fellowship-of-the-ring-the-two-towers-the-return-of-the-king.jpg"
                },
                new Product
                {
                    Id = 2,
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    ISBN = "978-0-395-19395-7",
                    Description = "The Hobbit",
                    Price = 10.00,
                    CategoryId = 3,
                    ImageUrl = "https://cdn.kobo.com/book-images/8fcc4405-1f93-4e7b-8cdf-7516fbdd26f7/353/569/90/False/the-lord-of-the-rings-the-fellowship-of-the-ring-the-two-towers-the-return-of-the-king.jpg"
                },
                new Product
                {
                    Id = 3,
                    Title = "The Silmarillion",
                    Author = "J.R.R. Tolkien",
                    ISBN = "978-0-395-19395-7",
                    Description = "The Silmarillion",
                    Price = 10.00,
                    CategoryId = 4,
                    ImageUrl = "https://cdn.kobo.com/book-images/8fcc4405-1f93-4e7b-8cdf-7516fbdd26f7/353/569/90/False/the-lord-of-the-rings-the-fellowship-of-the-ring-the-two-towers-the-return-of-the-king.jpg"
                },
                new Product
                {
                    Id = 4,
                    Title = "The Children of Hurin",
                    Author = "J.R.R. Tolkien",
                    ISBN = "978-0-395-19395-7",
                    Description = "The Children of Hurin",
                    Price = 10.00,
                    CategoryId = 5,
                    ImageUrl = "https://cdn.kobo.com/book-images/8fcc4405-1f93-4e7b-8cdf-7516fbdd26f7/353/569/90/False/the-lord-of-the-rings-the-fellowship-of-the-ring-the-two-towers-the-return-of-the-king.jpg"
                },
                new Product
                {
                    Id = 5,
                    Title = "The Fall of Gondolin",
                    Author = "J.R.R. Tolkien",
                    ISBN = "978-0-395-19395-7",
                    Description = "The Fall of Gondolin",
                    Price = 10.00,
                    CategoryId = 6,
                    ImageUrl = "https://cdn.kobo.com/book-images/8fcc4405-1f93-4e7b-8cdf-7516fbdd26f7/353/569/90/False/the-lord-of-the-rings-the-fellowship-of-the-ring-the-two-towers-the-return-of-the-king.jpg"
                },
                new Product
                {
                    Id = 6,
                    Title = "The History of Middle Earth",
                    Author = "J.R.R. Tolkien",
                    ISBN = "978-0-395-19395-7",
                    Description = "The History of Middle Earth",
                    Price = 10.00,
                    CategoryId = 7,
                    ImageUrl = "https://cdn.kobo.com/book-images/8fcc4405-1f93-4e7b-8cdf-7516fbdd26f7/353/569/90/False/the-lord-of-the-rings-the-fellowship-of-the-ring-the-two-towers-the-return-of-the-king.jpg"
                }
                );               
        }

    }
}
