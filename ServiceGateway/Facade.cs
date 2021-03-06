﻿using System;
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
        CrewGameSuggestionGateway crewGameSuggestionGW;
        SuggestionUsersGateway suggestionUsersGW;
        CrewApplicationGateway crewApplicationGW;

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
        public CrewGameSuggestionGateway GetCrewGameSuggestionGateway()
        {
            return crewGameSuggestionGW != null ? crewGameSuggestionGW : crewGameSuggestionGW = new CrewGameSuggestionGateway();
        }
        public SuggestionUsersGateway GetSuggestionUsersGateway()
        {
            return suggestionUsersGW != null ? suggestionUsersGW : suggestionUsersGW = new SuggestionUsersGateway();
        }
        public CrewApplicationGateway GetCrewApplicationGateway()
        {
            return crewApplicationGW != null ? crewApplicationGW : crewApplicationGW = new CrewApplicationGateway();
        }
    }
}
