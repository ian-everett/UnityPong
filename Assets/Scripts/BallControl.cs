using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float gain_x;

    void GoBall(){
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
        rb2d.AddForce(vector);
    }

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();

        /*
         * Start game by launching ball after 2 seconds
         */
        Invoke("GoBall", 2);  
    }

    void ResetBall(){
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        gain_x = 0;
    }

    void RestartGame(){
        ResetBall();
        Invoke("GoBall", 1);
    }

    /*
     * In built collision function
     * Something (coll) has just collied with this object 
     */
    void OnCollisionEnter2D(Collision2D coll){
        if (coll.collider.CompareTag("Player")){
            Vector2 vel;

            vel.x = rb2d.velocity.x + gain_x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;

            /*
             * Speed up gradualy
             */
            gain_x += (vel.x > 0) ? -2 : 2;
        }
    }
}
