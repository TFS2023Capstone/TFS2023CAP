using HiddenWorld.Helpers;
using UnityEngine;

namespace HiddenWorld.Puzzle
{
    public class PuzzlePiece : MonoBehaviour, IInteractable
    {
        public bool isSet = false;
        public bool isActive = false; // keep track of when a puzzle piece is being interacted with
        private Puzzle _puzzle;


        // enum PuzzleType (Jigsaw, Sequential, etc)

        public void SetPuzzleRef(Puzzle puzzle)
        {
            _puzzle = puzzle;
        }
        public virtual void OnInteract()
        {
            if (isActive)
            {
                isActive = false;
            }
            else
            {
                isActive = true;
            }

            //determine if the piece is set correctly or not and if it is set correctly calls AddList2Piece() in Puzzle class
            if (isSet)
            {
                _puzzle.AddList2Piece(gameObject.name);
            }
        }



        // inherits from ISpyglassable
        // OnSpyglassed() to display augmented/different sprite/graphic/etc.

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

