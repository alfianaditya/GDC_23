namespace GDC.Interaction
{
    /// <summary>
    /// Interface for interactable objects.
    /// </summary>
    public interface IInteractable
    {
        string InteractableName { get; }
        void Interact();
    }
}
