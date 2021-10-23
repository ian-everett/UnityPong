using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private float gain_x;

    void GoBall()
    {
        Vector2 vector;
        
        /*
         * int Range(int minInclusive, int maxExclusive); 
         * maxExcusive is exclusive, so for example Random.Range(0, 10)
         * will return a value between 0 and 9
         *
         * Return a 0 or 1 to decide which way the ball will start
         */
        float rand = Random.Range(0, 2);
        
        vector.x = (rand < 1) ? 20 : -20;
        vector.y = 15;

        /*
         * Add force should be used when using Body Type 'Dynamic'
         * where a objects phsyics is being controlled by Unity
         * It takes into account the mass of the object whereas
         * setting the velocity won't
         */
        rb.AddForce(vector);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        gain_x = 0;
    }

    public void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 2);
    }

    /*
     * In built collision function
     * Something (coll) has just collied with this object 
     */
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;

            vel.x = rb.velocity.x + gain_x;
            vel.y = (rb.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb.velocity = vel;

            /*
             * Speed up gradualy
             */
            gain_x += (vel.x > 0) ? -1.2f : 1.2f;
        }
    }
}
