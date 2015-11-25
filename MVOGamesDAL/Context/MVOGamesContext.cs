using MVOGamesDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGamesDAL.Context
{
    public class MVOGamesContext : DbContext
    {
        public MVOGamesContext(): base("MVOGamesDB")
        {
            //Add this line to make json conversin happy.
            //Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Game>().HasMany(g => g.Genres).WithMany();
            //modelBuilder.Entity<User>().HasMany(c => c.Crews).WithMany();
        }
        //OnModelCreating States exactly which lists the tables are connected as many-to-many through

        public System.Data.Entity.DbSet<Game> Games { get; set; }
        public System.Data.Entity.DbSet<Genre> Genres { get; set; }
        public System.Data.Entity.DbSet<User> Users { get; set; }
        public System.Data.Entity.DbSet<Crew> Crews { get; set; }
        public System.Data.Entity.DbSet<Role> Roles { get; set; }
        public System.Data.Entity.DbSet<Platform> Platforms { get; set; }
        public System.Data.Entity.DbSet<Order> Orders { get; set; }
        public System.Data.Entity.DbSet<Orderline> Orderlines { get; set; }
        public System.Data.Entity.DbSet<PlatformGame> PlatformGames { get; set; }


    }
}