using Sample.DataAccess.Context;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sample.DataAccess.Context.SampleEntities>
    {
        private SampleEntities _context;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SampleEntities context)
        {
            _context = context;

            var user = CreateUser("Roberto", "Pindado");

            var movie = CreateMovie("The Grand Budapest Hotel", new DateTime(2014, 6, 1));
            CreateMovieRate(user, movie, "Just fine", new DateTime(2014, 7, 1), 7);

            movie = CreateMovie("Guardians of the Galaxy", new DateTime(2014, 8, 1));
            CreateMovieRate(user, movie, "Awesome!!", new DateTime(2014, 8, 1), 9);

            movie = CreateMovie("X-Men: Days of Future Past", new DateTime(2014, 7, 1));
            CreateMovieRate(user, movie, "Not bad", new DateTime(2014, 7, 11), 6);

            movie = CreateMovie("Godzilla", new DateTime(2014, 6, 1));
            CreateMovieRate(user, movie, "Boring", new DateTime(2014, 6, 1), 4);

            movie = CreateMovie("Teenage Mutant Ninja Turtles", new DateTime(2014, 8, 11));
            CreateMovieRate(user, movie, "Good only for kids", new DateTime(2014, 8, 15), 5);

            movie = CreateMovie("The Amazing Spider-Man 2", new DateTime(2014, 6, 1));
            CreateMovieRate(user, movie, "Decent", new DateTime(2014, 6, 15), 6);

            movie = CreateMovie("Neighbors", new DateTime(2014, 6, 1));
            CreateMovieRate(user, movie, "Another regular comedy", new DateTime(2014, 6, 15), 6);

            movie = CreateMovie("Captain America: The Winter Soldier", new DateTime(2014, 7, 1));
            CreateMovieRate(user, movie, "Great!", new DateTime(2014, 7, 15), 8);

            movie = CreateMovie("Need for Speed", new DateTime(2014, 8, 1));
            CreateMovieRate(user, movie, "Just good cars", new DateTime(2014, 8, 24), 5);

            user = CreateUser("Guest", "");

            movie = CreateMovie("Robocop", new DateTime(2014, 8, 1));
            CreateMovieRate(user, movie, "Awful", new DateTime(2014, 8, 5), 3);

            movie = CreateMovie("Generation War", new DateTime(2014, 6, 1));
            CreateMovieRate(user, movie, "Too dramatic", new DateTime(2014, 6, 19), 5);

            movie = CreateMovie("Labor Day", new DateTime(2014, 7, 1));
            CreateMovieRate(user, movie, "Regular", new DateTime(2014, 7, 15), 5);

            movie = CreateMovie("The Expendables 3", new DateTime(2014, 8, 1));
            CreateMovieRate(user, movie, "Love it", new DateTime(2014, 8, 17), 8);
        }

        private void CreateMovieRate(User user, Movie movie, string comments, DateTime date, int rate)
        {
            var movieRate = new MovieRate() { Id = Guid.NewGuid(), Date = date, Comments = comments, Rate = rate, UserId = user.Id, MovieId = movie.Id };
            _context.MovieRates.AddOrUpdate(movieRate);
        }

        private Movie CreateMovie(string title, DateTime date)
        {
            var movie = new Movie() { Id = Guid.NewGuid(), Title = title, Date = date };
            _context.Movies.AddOrUpdate(movie);
            return movie;
        }

        private User CreateUser(string firstname, string lastname)
        {
            var user = new User() { Id = Guid.NewGuid(), Firstname = firstname, Lastname = lastname };
            _context.Users.AddOrUpdate(user);
            return user;
        }
    }
}
