using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{

    //needs to be a subscribable object
    // public variable isCorrect (possibly "isSet" instead in order to account for sequential vs non-sequential?)
    // inherits from IInteractable
    // public bool isActive to keep track of which puzzle piece is being interated with
    // enum PuzzleType (Jigsaw, Sequential, etc)
    // public Vector3 piecePosition; // if pieces are moveable we will have to estaablish their start position.  may be vector 2 depending on puzzle representation
    // public Quaternion puzzleRotation; // Sample puzzle mechanic variable: If puzzle can be rotated we need to set it at the start.  May be moved to puzzle subclass


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
    //


    //public void PuzzleReset() // may end up being (or calling) a puzzle sub-class dependent reset procedure
    //{

    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
