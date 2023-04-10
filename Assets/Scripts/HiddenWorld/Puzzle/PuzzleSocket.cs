using System.Collections;
using System.Collections.Generic;
using HiddenWorld.Helpers;
using UnityEngine;

namespace HiddenWorld.Puzzle
{
    public class PuzzleSocket : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("before snappable");
            ISnappable snappable = other.GetComponent<ISnappable>();
            Debug.Log("before if snappable");
            if (snappable != null)
            {
                Debug.Log("in if snappable");
                snappable.OnSnapped(transform.position);
                Debug.Log("after onsnapped");
            }
        }
    }

}
