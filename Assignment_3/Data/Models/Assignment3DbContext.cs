using Microsoft.EntityFrameworkCore;

namespace Assignment_3.Data.Models
{
    public class Assignment3DbContext : DbContext
    {
        public Assignment3DbContext(DbContextOptions options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Character> Characters { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasData(
                    new Movie()
                    {
                        Id = 1,
                        Title = "Batman Begins",
                        Genre = "Superhero, Action",
                        ReleaseYear = 2005,
                        FranchiseId = 1,
                    }
                    , new Movie()
                    {
                        Id = 2,
                        Title = "The Dark Knight",
                        Genre = "Superhero, Action",
                        ReleaseYear = 2008,
                        FranchiseId = 1,
                    }
                    , new Movie()
                    {

                        Id = 3,
                        Title = "The Dark Knight Rises",
                        Genre = "Superhero, Action",
                        ReleaseYear = 2012,
                        FranchiseId = 1,
                    }, new Movie()
                    {

                        Id = 4,
                        Title = "Harry Potter And The Philosophers Stone",
                        Genre = "Fantasy",
                        ReleaseYear = 2001,
                        FranchiseId = 2,
                    }
                );

            modelBuilder.Entity<Character>()
                .HasData(
                    new Character()
                    {
                        Id = 1,
                        Name = "Batman",
                        Gender = "Male",
                    }
                    , new Character()
                    {
                        Id = 2,
                        Name = "Robin",
                        Gender = "Male",
                    }
                    , new Character()
                    {
                        Id = 3,
                        Name = "Hermione Granger",
                        Gender = "Female",
                    }
                );

            modelBuilder.Entity<Franchise>()
                .HasData(
                    new Franchise()
                    {
                        Id = 1,
                        Name = "Batman",
                    }
                    , new Franchise()
                    {
                        Id = 2,
                        Name = "Harry Potter"
                    }
                );

            modelBuilder.Entity<Movie>()
                .HasMany(movie => movie.Characters)
                .WithMany(character => character.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterMovie",
                    left => left.HasOne<Character>().WithMany().HasForeignKey("CharactersId"),
                    right => right.HasOne<Movie>().WithMany().HasForeignKey("MoviesId"),
                    jointable =>
                    {
                        jointable.HasKey("CharactersId", "MoviesId");
                        jointable.HasData(
                            new { CharactersId = 1, MoviesId = 1 },
                            new { CharactersId = 2, MoviesId = 1 },
                            new { CharactersId = 1, MoviesId = 2 },
                            new { CharactersId = 2, MoviesId = 2 },
                            new { CharactersId = 1, MoviesId = 3 },
                            new { CharactersId = 2, MoviesId = 3 },
                            new { CharactersId = 3, MoviesId = 4 }
                        );
                    }

                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
