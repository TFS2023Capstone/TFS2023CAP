using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Vector3 upPosition;
    public Vector3 downPosition;
    public float lerpDuration = 1f;

    private bool isMoving = false;
    private bool isGoingUp = true;

    private void Start()
    {
        upPosition = transform.position;
        downPosition = upPosition + new Vector3(0, -0.2f, 0); // Adjust the offset as needed
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Boulder"))
        {
            MovePlateDown();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Boulder"))
        {
            MovePlateUp();
        }
    }

    private void MovePlateDown()
    {
        if (!isMoving && isGoingUp)
        {
            isGoingUp = false;
            StartCoroutine(MovePlate(downPosition));
        }
    }

    private void MovePlateUp()
    {
        if (!isMoving && !isGoingUp)
        {
            isGoingUp = true;
            StartCoroutine(MovePlate(upPosition));
        }
    }

    // Coroutine function for the LERP movement.
    private IEnumerator MovePlate(Vector3 targetPosition)
    {
        isMoving = true;

        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < lerpDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / lerpDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }
}
