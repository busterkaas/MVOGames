using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceGateway.Gateways;

namespace ServiceGateway
{
    public class Facade
    {
        GameGateway gameGW;
        CrewGateway crewGW;
        GenreGateway genreGW;
        OrderGateway OrderGW;
        OrderlineGateway OrderlineGW;
        PlatformGameGateway platformGameGW;
        PlatformGateway platformGW;
        RoleGateway roleGW;
        UserGateway userGW;

        public GameGateway GetGameGateway()
        {
            return gameGW != null ? gameGW : gameGW = new GameGateway();
        }
        public CrewGateway GetCrewGateway()
        {
            return crewGW != null ? crewGW : crewGW = new CrewGateway();
        }
        public GenreGateway GetGenreGateway()
        {
            return genreGW != null ? genreGW : genreGW = new GenreGateway();
        }
        public OrderGateway GetOrderGateway()
        {
            return OrderGW != null ? OrderGW : OrderGW = new OrderGateway();
        }
        public OrderlineGateway GetOrderlineGateway()
        {
            return OrderlineGW != null ? OrderlineGW : OrderlineGW = new OrderlineGateway();
        }
        public PlatformGameGateway GetPlatformGameGateway()
        {
            return platformGameGW != null ? platformGameGW : platformGameGW = new PlatformGameGateway();
        }
        public PlatformGateway GetPlatformGateway()
        {
            return platformGW != null ? platformGW : platformGW = new PlatformGateway();
        }
        public RoleGateway GetRoleGateway()
        {
            return roleGW != null ? roleGW : roleGW = new RoleGateway();
        }
        public UserGateway GetUserGateway()
        {
            return userGW != null ? userGW : userGW = new UserGateway();
        }
    }
}
