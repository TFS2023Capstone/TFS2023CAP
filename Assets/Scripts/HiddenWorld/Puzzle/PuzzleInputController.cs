using System.Collections;
using System.Collections.Generic;
using HiddenWorld.Helpers;
using UnityEditor.PackageManager;
using UnityEngine;

namespace HiddenWorld
{
    public class PuzzleInputController : MonoBehaviour
    {
        public IInteractable selectedObject;
        Vector3 offset;
        private bool _isSet = false;
        public Transform selectedObjectTransform;
        private Vector3 _mousePosition;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            // Use the camera's position as a reference for the zDistance
            float zDistance = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);

            // Convert the mouse position to a world position with the correct z-distance
            _mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo;
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

                IInteractable interactable = hitInfo.transform.gameObject.GetComponent<IInteractable>();

                if (hit && interactable != null)
                {
                    selectedObject = interactable;
                    Debug.Log("selected object is " + selectedObject);
                    selectedObjectTransform = hitInfo.transform;
                    offset = selectedObjectTransform.position - _mousePosition;
                    _isSet = interactable.OnInteract();
                }
            }
            if (selectedObjectTransform)
            {
                selectedObjectTransform.position = _mousePosition + offset;
            }
            if (Input.GetMouseButtonUp(0) && selectedObject != null)
            {
                Debug.Log("Mouse up detected");
                selectedObject = null;
                selectedObjectTransform = null;
            }

        }
        void FixedUpdate()
        {
            if (selectedObject != null)
            {
                selectedObjectTransform.GetComponent<Rigidbody>().MovePosition(_mousePosition + offset);
            }
        }
    }

}

