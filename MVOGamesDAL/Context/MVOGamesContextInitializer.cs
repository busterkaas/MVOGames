
using MVOGamesDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGamesDAL.Context
{
    public class MVOGamesContextInitializer : DropCreateDatabaseAlways<MVOGamesContext>
    {
        protected override void Seed(MVOGamesContext context)
        {
            Platform platform = context.Platforms.Add(new Platform() {Id = 1, Name = "Playstation 4"});
            Platform platform1 = context.Platforms.Add(new Platform() { Id = 2, Name = "XBOX One" });
            Platform platform2 = context.Platforms.Add(new Platform() { Id = 3, Name = "PC" });

            Genre genre1 = context.Genres.Add(new Genre() { Id = 1, Name = "FPS" });
            Genre genre2 = context.Genres.Add(new Genre() { Id = 2, Name = "Action" });
            Genre genre3 = context.Genres.Add(new Genre() { Id = 3, Name = "Adventure" });

            Role role1 = context.Roles.Add(new Role() { Id = 1, RoleName = "admin" });
            Role role2 = context.Roles.Add(new Role() { Id = 2, RoleName = "user" });



            User user = new User { Username = "buster", City = "Esbjerg", Email = "bulle@gmail.com", FirstName = "Buster", LastName = "Jensen", HouseNr = "175 C, 2th", StreetName = "Ingemanns Allé", ZipCode = 6700, Crews = new List<Crew> { }, Role=role1 };
            user.SetPassword("buster");
            User user2 = new User { Username = "shane", City = "Oslo", Email = "shalle@gmail.com", FirstName = "Shane", LastName = "Jensen", HouseNr = "1", StreetName = "Olso Allé", ZipCode = 7070, Crews = new List<Crew> { }, Role=role2 };
            user2.SetPassword("shane");
            context.Users.Add(user);
            context.Users.Add(user2);

            Crew crew = context.Crews.Add(new Crew() { Id = 1, Name = "SOB", Users = new List<User>() { user2 } });

            IList<Game> games = new List<Game>();

            games.Add(new Game
                 {
                Title = "GTA V",
                ReleaseDate = new DateTime(2014, 09, 28),
                Price = 150,
                CoverUrl = "http://blog.moviepostershop.com/wp-content/uploads/2011/03/Thor-movie-poster.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",
                
                Genres = new List<Genre>() { genre2 },
                Description = "Go crazy ín los santos!! The city of oppotunities.",
            });
            games.Add(new Game
            {
                Title = "Rainbow Six - Siege",
                ReleaseDate = new DateTime(2015, 01, 28),
                Price = 150,
                CoverUrl = "http://blog.moviepostershop.com/wp-content/uploads/2011/03/Thor-movie-poster.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre2, genre1 },
                Description = "Become an terrorist or fight the terrorrists in this new and exiting FPS game.",
            });
            foreach (Game g in games)
            {
                context.Games.Add(g);
            }

            base.Seed(context);
           
        }
    }
}
