using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckMovement : MonoBehaviour
{
    public float MaxSpeed;
    private Rigidbody2D rb;

    private Color originalColor;
    //Scoring here
    public scoring_system score;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalColor = transform.GetComponent<Renderer>().material.color;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "redgoal")
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;

            StartCoroutine(FadeOut(2));
            score.updateBluescore(1);

            StartCoroutine(ResetPuck());
        }

        else if (col.gameObject.tag == "bluegoal")
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            StartCoroutine(FadeOut(2));
            score.updateRedscore(1);
            StartCoroutine(ResetPuck());

        } 
    }
    IEnumerator FadeOut(float time)
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


    }


    private IEnumerator ResetPuck()
    {

        yield return new WaitForSecondsRealtime(2);
        rb.velocity = rb.position = new Vector2(0, 0);
        rb.isKinematic = false;
        transform.GetComponent<Renderer>().material.color = originalColor;

    }

}
