using System.Collections;
using System.Collections.Generic;
using Helpers;
using Unity.VisualScripting;
using UnityEngine;


public class PuzzlePiece : Puzzle
{
    [SerializeField] private float _startPosX;
    [SerializeField] private float _startPosY;
    [SerializeField] private float _startPosZ;
    [SerializeField] private float _startRotX;
    [SerializeField] private float _startRotY;
    [SerializeField] private float _startRotZ;
    [SerializeField] private float _startScale;
    [SerializeField] private float _endPosX;
    [SerializeField] private float _endPosY;
    [SerializeField] private float _endPosZ;
    [SerializeField] private float _endRotX;
    [SerializeField] private float _endRotY;
    [SerializeField] private float _endRotZ;
    [SerializeField] private float _endScale;

    // how to implement initial and correct position when building puzzle:
    // during dev move piece to starting position and store transform pos,rot,scale in private variables
    // during dev move piece to correct end position and store transform pos,rot,scale in private variables

    public bool isSet = false;
    public bool isActive = false; // keep track of when a puzzle piece is being interacted with

    // inherits from IInteractable
    // enum PuzzleType (Jigsaw, Sequential, etc)

    private void OnInteract()
    {
        if (isActive) 
        { isActive = false; 
        }
        else
        {
            isActive = true;
        }
        
        //determine if the piece is set correctly or not and if it is set correctly calls AddList2Piece() in Puzzle class
        if (isSet)
        {
        Puzzle:AddList2Piece("Piece1");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null && other.CompareTag("PuzzlePiece"))
        {
            // interactable.OnInteract(puzzle.interact); // need to determine what gets passed
        }
    }

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
