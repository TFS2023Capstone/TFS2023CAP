using UnityEngine;

namespace HiddenWorld.Helpers
{
    public interface IInteractable
    {
        bool OnStartInteract();
        bool OnStopInteract();
    }
}
