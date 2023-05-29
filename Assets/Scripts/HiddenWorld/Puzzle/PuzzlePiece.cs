using System.Collections;
using System.Collections.Generic;
using HiddenWorld.Helpers;
using Unity.VisualScripting;
using UnityEngine;

namespace HiddenWorld.Puzzle
{
    public enum pieceState
    {
        Inactive,
        Active,
        Locked
    }

    public class PuzzlePiece : MonoBehaviour, IInteractable, IPuzzlePiece
    {
        protected pieceState currentPieceState = pieceState.Inactive;
        public bool isSet = false;
        public bool isActive = false; // keep track of when a puzzle piece is being interacted with
        protected Puzzle _puzzle;
        protected PuzzleSocket currentSocket;
        

        // enum PuzzleType (Jigsaw, Sequential, etc)

        public void SetPuzzleRef(Puzzle puzzle)
        {
            _puzzle = puzzle;
        }
        public virtual bool OnStartInteract()
        {
            if (currentPieceState == pieceState.Inactive)
            {
                currentPieceState = pieceState.Active;
            }

            ////determine if the piece is set correctly or not and if it is set correctly calls AddList2Piece() in Puzzle class
            //if (isSet)
            //{
            //    _puzzle.AddList2Piece(gameObject.name);
            //}
            return isActive;
        }

        public virtual bool OnStopInteract()
        {
            if (currentPieceState == pieceState.Active)
            {
                if (currentSocket != null)
                {
                    transform.position = currentSocket.transform.position;
                    currentPieceState = pieceState.Inactive;
                    Debug.Log(currentSocket.IsCorrect);
                    if (currentSocket.IsCorrect)
                    {
                        _puzzle.AddList2Piece(gameObject.name);
                    }
                    else
                    {
                        //_puzzle.RemoveList2Piece(gameObject.name);
                    }
                }
                else
                {
                    currentPieceState = pieceState.Inactive;
                }
            }
            return isActive;
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

        public void OnSocketEnter(PuzzleSocket socket)
        {
            //isSet = true;
            currentSocket = socket;
        }
        public void OnSocketExit()
        {
            _puzzle.RemoveList2Piece(gameObject.name);
            currentSocket = null;
        }
    }
}

