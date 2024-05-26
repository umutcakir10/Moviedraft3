using Microsoft.EntityFrameworkCore;
using Moviegram.Models.Domain;

namespace Moviegram.Data
{
	public class MoviegramDbContext: DbContext
	{
		public MoviegramDbContext(DbContextOptions<MoviegramDbContext> options) : base(options) 
		{
		}

        public DbSet<MoviePost> MoviePosts { get; set; }

		public DbSet<Tag> Tags { get; set; }

        public DbSet<MoviePostLike> MoviePostLike { get; set; }
    }
}
