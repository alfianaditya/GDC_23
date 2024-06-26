namespace GDC.Utilities
{
    public class OnTimeAdvanced : GameEvent
    {
        public int Day { get; private set; }

        public OnTimeAdvanced(int day)
        {
            Day = day;
        }
    }



    public class OnEnergyChanged : GameEvent
    {
        public int Energy { get; private set; }
        public bool IsRising { get; private set; }

        public OnEnergyChanged(int energy, bool isRising = true)
        {
            Energy = energy;
            IsRising = isRising;
        }
    }
}
