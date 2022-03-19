//using UnityEngine.Random.Range;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float MaxMovementSpeed;
    private Rigidbody2D rb;
    private Vector2 startingPosition;

    public Rigidbody2D Puck;

    public Transform PlayerBoundaryHolder;
    private Boundary playerBoundary;

    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary;

    private Vector2 targetPosition;

    private bool inOpponentsHalf = true;
    private float offsetFromTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;

        Debug.Log(string.Format("starting POS: {0}", startingPosition));

        playerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.y,
                                        PlayerBoundaryHolder.GetChild(1).position.y,
                                        PlayerBoundaryHolder.GetChild(2).position.x,
                                        PlayerBoundaryHolder.GetChild(3).position.x);

        puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y,
                                        PuckBoundaryHolder.GetChild(1).position.y,
                                        PuckBoundaryHolder.GetChild(2).position.x,
                                        PuckBoundaryHolder.GetChild(3).position.x);

    }

    private void FixedUpdate()
    {
        float movementSpeed;

        Debug.Log(string.Format("Puck POS: {0}", Puck.position.x));
        Debug.Log(string.Format("Puck Bounday: {0}", puckBoundary.Right));
        // if puck is not in opponent's half, puck is in my half
        if (Puck.position.x > puckBoundary.Right)
        {
            if (inOpponentsHalf)
            {
                inOpponentsHalf = false;
                offsetFromTarget = Random.Range(-1f, 1f);
            }

            movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
            Debug.Log(string.Format("This is moveSpeed in IF: {0}", movementSpeed));

            targetPosition = new Vector2(Mathf.Clamp(Puck.position.x + offsetFromTarget, playerBoundary.Right, playerBoundary.Left), startingPosition.y);
            Debug.Log(string.Format("This is targetPOS in IF: {0}", targetPosition));
        }
        // else puck is in opponent's half
        else
        {
            inOpponentsHalf = true;

            //movementSpeed = MaxMovementSpeed * Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
            movementSpeed = MaxMovementSpeed * Random.Range(0.5f, 0.7f);
            Debug.Log(string.Format("This is moveSpeed in ELSE: {0}", movementSpeed));


            
            targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, playerBoundary.Left, playerBoundary.Right),
                                           Mathf.Clamp(Puck.position.y, playerBoundary.Down, playerBoundary.Up));

            // targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, playerBoundary.Left, playerBoundary.Right),
            //      Mathf.Clamp(Puck.position.y, playerBoundary.Down, playerBoundary.Up));

            Debug.Log(string.Format("This is targetPOS in ELSE: {0}", targetPosition));
            Debug.Log(string.Format("starting POS in ELSE: {0}", startingPosition));
        }

        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime));

        
    }
   
}
