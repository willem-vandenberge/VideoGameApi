using Microsoft.EntityFrameworkCore;
using VideoGameApi.Model.Models;

namespace VideoGameAPI.Repository.Core
{
    /**
     * EntityFrameworkcCore gebruiken: package downloaden & importeren
     * => Ef tools gebruiken (Microsoft.EntityFrameworkCore.Tools
     * - Add-Migration initial // maakt een migration-file aan (up & down: rollback migration)
     */
    public class VideoGameDBContext(DbContextOptions<VideoGameDBContext> options) : DbContext(options)
    {

        // dbset resulteerd in een table in database
        // best practise om de set direct te initializeren ook
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        public DbSet<Developer> Developers => Set<Developer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data toevoegen aan de database bij eenvolgende migratie
            modelBuilder.Entity<VideoGame>().HasData(
                 new VideoGame
                 {
                     Id = 1,
                     Title = "Spider-Man 1",
                     Platform = "PS5",
                     Developer = "Insomniac Games",
                     Publisher = "Sony Interactive Entertainment"
                 },
                new VideoGame
                {
                    Id = 2,
                    Title = "Spider-Man 2",
                    Platform = "PS5",
                    Developer = "Insomniac Games",
                    Publisher = "Sony Interactive Entertainment"
                },
                new VideoGame
                {
                    Id = 3,
                    Title = "Spider-Man 3",
                    Platform = "PS5",
                    Developer = "Insomniac Games",
                    Publisher = "Sony Interactive Entertainment"
                },
                new VideoGame
                {
                    Id = 4,
                    Title = "Spider-Man 4",
                    Platform = "PS5",
                    Developer = "Insomniac Games",
                    Publisher = "Sony Interactive Entertainment"
                }

             );
            modelBuilder.Entity<Developer>().HasData(
                 new Developer
                 {
                     Id = 1,
                     FirstName = "Melliw",
                     LastName = "De la Montange",
                     Email = "melliw.delamontagne@gmail.com"
                 },
                new Developer
                {
                    Id = 2,
                    FirstName = "Alexander",
                    LastName = "De la Mer",
                    Email = "alexander.delamer@gmail.com"

                },
                new Developer
                {
                    Id = 3,
                    FirstName = "Mik",
                    LastName = "Treaccab",
                    Email = "Mik.Treaccab@gmail.com"

                }
            );
        }
    }

    
}
