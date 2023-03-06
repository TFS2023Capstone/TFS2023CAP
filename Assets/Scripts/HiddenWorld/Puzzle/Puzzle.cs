using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    // inherits from ISpyglassable

    public bool puzzleSolved; // Flag used to denote if the puzzle object is solved
    // private list of puzzle pieces that hold the puzzle piece identifier and whether it is solved/not solved
    // OnInteract hook req'd
    // private isSequential boolean variable to denote that puzzle is sequential

    // Functions:
    // IsPuzzleSolved() to check if all puzzle pieces are in their solved state
        // checks if sequential, and if so updates a queue of pieces as they are solved and then compares to the correct sequence to set puzzleSolved
        // if not sequential just checks if all puzzle pieces are solved
    // StorePuzzleState .. TBD what information will be passed regarding state at savepoint
        //public void StorePuzzleState() 
        //{

        //}
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
