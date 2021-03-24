using System;
using Microsoft.EntityFrameworkCore;

namespace IS413_Assignment_9.Models
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext()
        {
        }

        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
