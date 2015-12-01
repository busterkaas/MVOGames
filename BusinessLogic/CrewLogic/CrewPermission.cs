namespace BusinessLogic.CrewLogic
{
    public class CrewPermission
    {
        public bool IsFull(int crewSize)
        {
            if (crewSize > 9) { return true; }
                
            return false;
        }
    }
}