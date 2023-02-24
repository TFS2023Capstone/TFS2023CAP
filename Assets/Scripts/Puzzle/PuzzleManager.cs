using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int puzzleID;  // If puzzles are organized by a numerical identifier
    public Vector3 startPosition; // If puzzles "appear" we will have to establish their start position
    public Quaternion startRotation; // Sample puzzle mechanic variable: If puzzle can be rotated then this will establish the initial view of it.  This may end up in a sub-class
    public static bool puzzleSolved; // Flag used to denote if the puzzle object is solved

    public void RotateTo(Quaternion newRotation) // sample puzzle mechanic if puzzle needs to rotate.  This may end up in a sub-class
    {
        transform.rotation = newRotation; 
    }

    public void StorePuzzleState()  // need to determine what inforamtion will be passed regarding puzzle states
    {

    }

    public void PuzzleReset() // puzzle sub-class dependent reset procedure?
    {

    }

    // Other fundamental puzzle mechanics common to all puzzle types may need to be added.
    // May need a method that deals with UI interaction: puzzle progress, puzzle timer, etc.
}
