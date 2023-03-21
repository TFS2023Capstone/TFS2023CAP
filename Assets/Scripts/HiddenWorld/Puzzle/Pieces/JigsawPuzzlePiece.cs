using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using HiddenWorld.Helpers;
using Unity.VisualScripting;

namespace HiddenWorld.Puzzle.Pieces
{
    public class JigsawPuzzlePiece : PuzzlePiece
    {
        public override bool OnInteract()
        {
            base.OnInteract();
            // puzzle pieces moves closer by a few pixels
            // possible hightlight to emphasize piece
            return _isSnapped;
        }

        public override void OnSnapped(Vector3 socketPosition)
        {
            base.OnSnapped(socketPosition);
            _isSnapped = true;
            transform.position = socketPosition;
            // puzzle pieces moves to original z
            // remove hightlight to emphasize piece
            OnInteract();
        }
    }
}
