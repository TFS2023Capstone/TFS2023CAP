using UnityEngine;
using UnityEngine.InputSystem;

namespace HiddenWorld.Puzzle.Pieces
{
    public class JigsawPuzzlePiece : PuzzlePiece
    {
        public string pieceStatus = "Idle";


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (pieceStatus == "moving")
            {
                Vector3 mousePosition = Mouse.current.position.ReadValue();
                Vector3 objPosition = new Vector3(Camera.main.ScreenToWorldPoint(mousePosition).x, Camera.main.ScreenToWorldPoint(mousePosition).y, transform.position.z);
                transform.position = objPosition;
            }
        }

        public override void OnInteract()
        {
            pieceStatus = "locked";
            isSet = true;
            base.OnInteract();
        }

        private void OnMouseDown()
        {
            pieceStatus = "moving";
        }

        private void OnMouseUp()
        {
            pieceStatus = "idle";
        }

    }

}
