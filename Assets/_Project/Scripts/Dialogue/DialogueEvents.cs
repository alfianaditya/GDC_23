namespace GDC.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public class OnDialogue : GameEvent
    {
        public bool isOnDialogue;

        public OnDialogue(bool isOnDialogue)
        {
            this.isOnDialogue = isOnDialogue;
        }
    }
}
