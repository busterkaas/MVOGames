namespace BusinessLogic.CrewLogic
{
    public class CrewPermission
    {
        public bool IsFull(int crewSize)
        {
            int maxCrewSize = 10;
            if (crewSize >= maxCrewSize)
            {
                return true;
            }

            return false;
        }

        public bool CrewLimitIsFull(int crews)
        {
            int crewLimit = 3;
            if (crews >= crewLimit)
            {
                return true;
            }
            return false;
        }
    }
}