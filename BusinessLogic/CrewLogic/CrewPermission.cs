using System;

namespace BusinessLogic.CrewLogic
{
    public class CrewPermission
    {
        public bool CrewIsFull(int crewSize)
        {
            int maxCrewSize = 10;
            if (crewSize >= maxCrewSize)
            {
                return true;
            }

            return false;
        }

        public bool MaxCrewsJoined(int crews)
        {
            int crewLimit = 3;
            if (crews >= crewLimit)
            {
                return true;
            }
            return false;
        }

        public bool IsDateValid(DateTime date, TimeSpan time)
        {
            date += time;

            DateTime minValidDate = DateTime.Now;
            TimeSpan minTime = TimeSpan.FromMinutes(5);
            minValidDate += minTime;
            if (date < minValidDate ) {
                return false;
            }
            
            return true;
        }
    }
}