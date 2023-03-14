using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using System.Linq;
using UnityEngine.ProBuilder.Shapes;

namespace HiddenWorld.Puzzle
{
    public class Puzzle : MonoBehaviour
    {
        private bool _puzzleSolved = false; // Flag used to denote if the puzzle object is solved need get/private set
        public bool isSequential = false; // sets whether this puzzle is a sequential puzzle
        public List<string> solutionList;
        public List<string> currSolvedList;
        [SerializeField]
        private List<PuzzlePiece> _piecesList;
        private bool _allPiecesCheck = false;
        private bool _sequenceGood = false;

        // Functions:
        private void Start()
        {
            foreach (var piece in _piecesList)
            {
                piece.SetPuzzleRef(this);
            }
        }
        void ListComparer()
        {
            // List compare
            bool equal = solutionList.SequenceEqual(currSolvedList);

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
            bool allInList2 = solutionList.All(elem => currSolvedList.Contains(elem));

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

        public void AddList2Piece(string addPiece)
        {
            //List2 is list built from puzzlePiece entries { "Piece1", "Piece2"}
            currSolvedList.Add(addPiece);
            ResolvePuzzle();
        }
        public void ResolvePuzzle()
        {

            if (currSolvedList.Count == solutionList.Count)
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
                else
                {
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
        }

        // May need StorePuzzleState() TBD if information will be passed regarding state at savepoint

    }



}
