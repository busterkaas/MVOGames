using MVOGamesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGamesDAL.Context;
using System.Data.Entity.Infrastructure;

namespace MVOGamesDAL.Repositories
{
    class GameRepository : IRepository<Game>
    {
        private MVOGamesContext ctx;
        public GameRepository(MVOGamesContext context)
        {
            ctx = context;
        }
        public void Add(Game t)
        {
                ctx.Games.Add(t);
                ctx.SaveChanges();
        }

        public void Delete(int? id)
        {
            Game game = Find(id);
            try
            {
                    ctx.Games.Attach(game);
                    ctx.Games.Remove(game);
                    ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
        }

        public Game Find(int? id)
        {
            foreach (var item in ReadAll())
            {
                if (item.Id == id)
                {
                    return item;
                }

            }
            return null;
        }

        public List<Game> ReadAll()
        {
            try
            {
                    return ctx.Games.Include("Genres").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Update(Game t)
        {
                foreach (var gameDB in ctx.Games.ToList())
                {
                    if (t.Id == gameDB.Id)
                    {
                        gameDB.Title = t.Title;
                        gameDB.ReleaseDate = t.ReleaseDate;
                        gameDB.Price = t.Price;
                        gameDB.TrailerUrl = t.TrailerUrl;
                        gameDB.CoverUrl = t.CoverUrl;
                        gameDB.Description = t.Description;
                        gameDB.Genres = t.Genres;
                        ctx.Games.Attach(gameDB);
                    }
                }
        }
    }
}
