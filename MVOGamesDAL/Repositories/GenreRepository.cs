using MVOGamesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGamesDAL.Context;

namespace MVOGamesDAL.Repositories
{
    class GenreRepository : IRepository<Genre>
    {
        private MVOGamesContext ctx;
        public GenreRepository(MVOGamesContext context)
        {
            ctx = context;
        }
        public void Add(Genre t)
        {
            //using (var ctx = new MVOGamesContext())
            //{
                ctx.Genres.Add(t);
                ctx.SaveChanges();
            //}
        }

        public void Delete(int? id)
        {
            //Genre genre = FindGenre(id);
            //try
            //{
            //    using (var ctx = new MovieShopContext())
            //    {
            //        ctx.Genres.Attach(genre);
            //        ctx.Genres.Remove(genre);
            //        ctx.SaveChanges();
            //    }
            //}
            //catch (DbUpdateConcurrencyException)
            //{

            //}
        }

        public Genre Find(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Genre> ReadAll()
        {
            //using (var ctx = new MVOGamesContext())
            //{
                return ctx.Genres.ToList();
            //}
        }

        public void Update(Genre t)
        {
            throw new NotImplementedException();
        }
    }
}
