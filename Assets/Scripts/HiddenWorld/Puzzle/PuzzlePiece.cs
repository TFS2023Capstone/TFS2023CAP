using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{

    //needs to be a subscribable object
    // public boolean isSet
    //
    //  Puzzle types:
    //      positional and combinational: each piece will know it's start position and it's correct position to make isSet true
    //      sequential: Piece will know if it has been interacted with and will toggle between not-set and set and vice-versa

    // inherits from IInteractable
    // public bool isActive to keep track of when a puzzle piece is being interacted
    // enum PuzzleType (Jigsaw, Sequential, etc)
    // public transform piecePosition, rotation, scale; // if pieces are moveable we will have to establish their start position.  may be vector 2 depending on puzzle representation
    // public Quaternion puzzleRotation; // Sample puzzle mechanic variable: If puzzle can be rotated we need to set it at the start.  May be moved to puzzle subclass

    // how to implement initial and correct position when building puzzle:
        // move piece to starting position and store transform pos,rot,scale in private variable
        // move piece to correct end position and store transform pos,rot,scale in private variable


    // Functions:
    // OnInteract: if the item being interacted with then sent isActive
    //private void OnTriggerEnter(Collider other)
    //{
    //    IInteractable interactable = other.GetComponent<IInteractable>();
    //    if (interactable != null && other.CompareTag("PuzzlePiece"))
    //    {
    //        // interactable.OnInteract(puzzle.interact); // need to determine what gets passed
    //    }
    //}

    // depending on PuzzleType will have different interactions and will call the appropriate method(s) (puzzle piece will be moveable and rotatable)
    // Rotate: rotates the PuzzlePiece
    //    public void RotateTo(Quaternion newRotation)
    //{
    //    transform.rotation = newRotation;
    //}

    //public void PuzzleReset() // may end up being (or calling) a puzzle sub-class dependent reset procedure
    //{

    //}

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
