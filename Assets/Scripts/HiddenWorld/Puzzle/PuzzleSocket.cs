using HiddenWorld.Helpers;
using UnityEngine;

namespace HiddenWorld.Puzzle
{
    public class PuzzleSocket : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            IInteractable interactable = other.GetComponent<IInteractable>();
            if (interactable != null && other.gameObject.name.Equals(this.gameObject.name))
            {
                other.transform.position = transform.position;
                interactable.OnInteract();
            }
        }
    }

}
