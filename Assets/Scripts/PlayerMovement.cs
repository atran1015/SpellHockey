using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform BoundaryHolder;

    Boundary playerBoundary;

    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();

        playerBoundary = new Boundary(BoundaryHolder.GetChild(0).position.y,
                                        BoundaryHolder.GetChild(1).position.y,
                                        BoundaryHolder.GetChild(2).position.x,
                                        BoundaryHolder.GetChild(3).position.x);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = mousePosition;
        //rb.MovePosition(mousePosition);

        Vector2 clampedMousePosition = new Vector2(Mathf.Clamp(mousePosition.x, playerBoundary.Left, playerBoundary.Right), 
            (Mathf.Clamp(mousePosition.y, playerBoundary.Down, playerBoundary.Up)));
        rb.MovePosition(clampedMousePosition);
    }
}