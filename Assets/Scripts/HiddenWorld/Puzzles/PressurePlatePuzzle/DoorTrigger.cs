using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiddenWorld.Puzzle
{
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField]
        GameObject Door;

        bool isOpen = false;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("the other collider is" + other);
            Debug.Log("Door triggered");
            if (other.transform.name == "PressurePlate")
            {
                if (!isOpen)
                {
                    Door.transform.position += new Vector3(0, 3, 0);
                    isOpen = true;
                }
            }
            
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Debug.Log("Player hit");        
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Door un-triggered");
            if (other.transform.name == "PressurePlate")
            {
                if (isOpen)
                {
                    Door.transform.position += new Vector3(0, -3, 0);
                    isOpen = false;
                }
            }
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
