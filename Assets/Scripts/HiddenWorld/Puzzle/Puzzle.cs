using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    private bool _puzzleSolved; // Flag used to denote if the puzzle object is solved need get/private set
    private bool _isSequential = false; // private isSequential boolean variable to denote that puzzle is sequential, need get/private set

    // Functions:

    public void ResolvePuzzle()
    {
    if (_isSequential == true)
        {
            //has to hold the proper sequence(list 1)
            //has to update a dynamic list as each puzzle piece is interacted with to set it's state set/notset (list2)
            //call ListComparer() helper to check
            //if returns true then puzzleSolved = true
        }
    
    else
        {
            //holds list 1 which is all puzzle pieces required to be set
            //holds list 2 which is all the puzzle pieces that are set
            //call ListChecker()
            //if all puzzle pieces are set then puzzleSolved = true
        }
    }
   
    // StorePuzzleState() TBD if information will be passed regarding state at savepoint



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
