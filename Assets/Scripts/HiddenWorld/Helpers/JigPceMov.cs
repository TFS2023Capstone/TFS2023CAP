using UnityEngine;

public class JigPceMov : MonoBehaviour
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
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == gameObject.name)
        {
            transform.position = other.gameObject.transform.position;
            pieceStatus = "locked";
        }
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
