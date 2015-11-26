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
        GameGateway gg;

        public GameGateway GetGameGateway()
        {
            return gg != null ? gg : gg = new GameGateway();
        }
    }
}
