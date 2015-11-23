using MVOGamesDAL.Context;
using MVOGamesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGamesDAL.Repositories
{
    public class CrewRepository : IRepository<Crew>
    {
        private MVOGamesContext ctx;
        public CrewRepository(MVOGamesContext context)
        {
            ctx = context;
        }
        public void Add(Crew t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Crew Find(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Crew> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Crew t)
        {
            throw new NotImplementedException();
        }
    }
}
