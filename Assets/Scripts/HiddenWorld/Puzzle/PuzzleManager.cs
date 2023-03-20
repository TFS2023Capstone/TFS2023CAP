using UnityEngine;

namespace HiddenWorld.Puzzle
{
    public class PuzzleManager : MonoBehaviour
    {
        public int puzzleID; // If puzzles are organized by a numerical identifier
        public Vector3 puzzlePosition; // if puzzles "appear" we will have to estaablish their start position
        public Quaternion puzzleRotation; // Sample puzzle mechanic variable: If puzzle can be rotated we need to set it at the start.  May be moved to puzzle subclass
        public bool puzzleSolved; // Flag used to denote if the puzzle object is solved

        public void RotateTo(Quaternion newRotation)
        {
            transform.rotation = newRotation;
        }

        public void StorePuzzleState() // TBD what information will be passed regarding state at savepoint
        {

        }

        public void PuzzleReset() // may end up being (or calling) a puzzle sub-class dependent reset procedure
        {

        }

        // May require a UI interface method for things like puzzle: progress, timer, orientation, etc.
        // May require a puzzle completion save method

        private void OnTriggerEnter(Collider other)
        {
            IInteractable interactable = other.GetComponent<IInteractable>();
            if (interactable != null && other.CompareTag("Puzzle"))
            {
                // interactable.OnInteract(puzzle.interact); // need to determine what gets passed
            }
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
