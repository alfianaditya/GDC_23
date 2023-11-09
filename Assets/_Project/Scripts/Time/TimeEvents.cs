namespace GDC.Utilities
{
    public class OnTimeAdvanced : GameEvent
    {
        public int Day { get; private set; }
        public int Hours { get; private set; }
        public int Minutes { get; private set; }

        public OnTimeAdvanced(int day, int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
            Day = day;
        }
    }
}
