using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Vector3 originalPos;
    bool moveBack = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.name == "Boulder")
        {
            transform.Translate(0, -0.001f, 0);
            moveBack = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player" || collision.transform.name == "Boulder")
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name == "Boulder")
        {
            moveBack = true;
            collision.transform.parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveBack)
        {
            if (transform.position.y < originalPos.y)
            {
                transform.Translate(0, 0.001f, 0);
            }
            else
            {
                moveBack = false;
            }
        }
    }
}
