using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckMovement : MonoBehaviour
{
    public float MaxSpeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "DestroyTrigger")
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            StartCoroutine(FadeOutAndDestroy(5));
        }
    }
    IEnumerator FadeOutAndDestroy(float time)
    {
        float elapsedTime = 0;
        Color startingColor = transform.GetComponent<Renderer>().material.color;
        Color finalColor = new Color(startingColor.r, startingColor.g, startingColor.b, 0);
        while (elapsedTime < time)
        {
            transform.GetComponent<Renderer>().material.color = Color.Lerp(startingColor, finalColor, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
    
}
