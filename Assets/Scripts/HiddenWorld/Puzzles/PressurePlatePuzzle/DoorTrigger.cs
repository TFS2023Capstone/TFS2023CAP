using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiddenWorld.Puzzle
{
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField]
        GameObject Door;


        private void OnTriggerEnter(Collider other)
        {
            Door.transform.position += new Vector3(0, 3, 0);
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }

}
