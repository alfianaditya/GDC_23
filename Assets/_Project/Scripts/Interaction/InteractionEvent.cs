namespace GDC.Utilities
{
    public class OnInteractable : GameEvent
    {
        public string InteractableName { get; private set; }

        public OnInteractable(string interactableName)
        {
            InteractableName = interactableName;
        }
    }



    public class OnInteractableExit : GameEvent
    {
        public OnInteractableExit()
        {}
    }
}
