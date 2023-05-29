using System.Collections;
using System.Collections.Generic;
using HiddenWorld.Helpers;
using Unity.VisualScripting;
using UnityEngine;

namespace HiddenWorld.Puzzle
{
    public class PuzzleSocket : MonoBehaviour
    {
        [SerializeField]
        private Material wrongColour;
        [SerializeField]
        private Material rightColour;

        private bool _isCorrect = false;
        private bool _isOccupied = false;
        public bool IsCorrect => _isCorrect;
        public bool IsOccupied => _isOccupied;        

        private void OnTriggerEnter(Collider other)
        {
            IPuzzlePiece pp = other.GetComponentInParent<IPuzzlePiece>();
            
            if (pp != null && !_isOccupied)
            {
                if (transform.name == other.transform.name)
                {
                    GetComponent<Renderer>().material = rightColour;
                    _isCorrect = true;
                    _isOccupied = true;
                }
                pp.OnSocketEnter(this);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            IPuzzlePiece pp = other.GetComponentInParent<IPuzzlePiece>();
            if (pp != null && _isOccupied)
            {
                _isCorrect = false;
                _isOccupied = false;
                GetComponent<Renderer>().material = wrongColour;
                pp.OnSocketExit();
            }
        }
    }

}
