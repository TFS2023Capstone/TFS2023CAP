using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using System.Linq;
using UnityEngine.ProBuilder.Shapes;

public class Puzzle : MonoBehaviour
{
    private bool _puzzleSolved = false; // Flag used to denote if the puzzle object is solved need get/private set
    public bool isSequential = false; // sets whether this puzzle is a sequential puzzle
    public List<string> list1;
    public List<string> list2;
    private bool _allPiecesCheck = false;
    private bool _sequenceGood = false;

    // Functions:

    void ListComparer()
    {
        // List compare
        bool equal = list1.SequenceEqual(list2);

        if (equal)
        {
            _sequenceGood = true;
            Debug.Log("The lists are equal.");
        }
        else
        {
            _sequenceGood = false;
            Debug.Log("The lists are not equal.");
        }
    }

    void ListChecker()
    {
        // List checker
        bool allInList2 = list1.All(elem => list2.Contains(elem));

        if (allInList2)
        {
            _allPiecesCheck = true;
            Debug.Log("All elements of List 1 are in List 2.");
        }
        else
        {
            _allPiecesCheck = false;
            Debug.Log("Not all elements of List 1 are in List 2.");
        }
    }

    void BuildPuzzleSolution()
    {
        //List1 is Solution { "Piece2", "Piece1"}
        list1 = new List<string>();
        list1.Add("Piece2");
        list1.Add("Piece1");
    }
    public void AddList2Piece(string addPiece)
    {
        //List2 is list built from puzzlePiece entries { "Piece1", "Piece2"}
        list2.Add(addPiece);
    }
    public void ResolvePuzzle()
    {

        if (list2.Count == list1.Count)
        {
            if (isSequential)
            {
                ListComparer();
                if (_sequenceGood)
                {
                    _puzzleSolved = true;
                }
                else
                {
                    _puzzleSolved = false;
                }
            }

            ListChecker();
            if (_allPiecesCheck)
            {
                _puzzleSolved = true;
            }
            else
            {
                _puzzleSolved = false;
            }
        }
    }

    // May need StorePuzzleState() TBD if information will be passed regarding state at savepoint
     
}


