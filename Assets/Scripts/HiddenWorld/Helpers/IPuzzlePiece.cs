using HiddenWorld.Puzzle;
using UnityEngine;

namespace HiddenWorld.Helpers
{
    public interface IPuzzlePiece
    {
        public void OnSocketEnter(PuzzleSocket PuzzleSocket);
        public void OnSocketExit();
    }
}
